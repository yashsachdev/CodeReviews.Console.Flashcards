using System.Diagnostics;

namespace FlashcardApp;

internal class FlashcardManager
{
    public Databasecontext _context { get; set; }
    public string _connectionString { get; set; }
    public FlashcardManager(string Connectionstring)
    {
        _context = new Databasecontext(Connectionstring);
        _connectionString = Connectionstring;
    }
    public void CreateFlashcard(int stackId, string question, string answer)
    {
        var query = "USE [flashcardapp] INSERT INTO flashcards(stack_id,prompt,answer) VALUES(@stackId,@question,@answer)";
        var parameter = new List<SqlParameter>
        {
            new SqlParameter("@stackId",stackId),
            new SqlParameter("@question",question),
            new SqlParameter("@answer",answer),
        };
        _context.ExecuteQuery(query, parameter.ToArray());
    }
    public int CreateStack(string name)
    {
        var query = "USE [flashcardapp] INSERT INTO stacks(name) OUTPUT INSERTED.Id VALUES (@Name)";
        using (var connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Name", name);
                return (int)command.ExecuteScalar();
            }
        }
    }
    public int GetId(string stackname)
    {
        var query = " use [flashcardapp] SELECT id FROM stacks WHERE name = @name";
        var parameter = new List<SqlParameter>
        {
              new SqlParameter("@name", stackname)
        };
        return _context.ExecuteScalar(query,parameter.ToArray());
    }
    public void RemoveStack(string stackName)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var stackId = GetId(stackName);
            if (stackId != null)
            {
                DeleteFlashcard_Stack(stackId);
                DeleteStack(stackId);
            }
        }
    }

    private void DeleteStack(int id)
    {
        var query = "USE [flashcardapp] DELETE FROM stacks WHERE id = @id ";
        var parameter = new SqlParameter("@id", id);
        _context.ExecuteQuery(query, parameter);
    }

    public void DeleteFlashcard_Stack(int id)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("USE [flashcardapp] DELETE FROM flashcards WHERE stack_id = @id ");
        sb.Append("IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'new_flashcards') ");
        sb.Append("BEGIN SELECT id, stack_id, prompt, answer INTO new_flashcards FROM flashcards; END ");
        sb.Append("DELETE FROM flashcards ");
        sb.Append("SET IDENTITY_INSERT flashcards ON; ");
        sb.Append("DBCC CHECKIDENT('flashcards', RESEED, 0);");
        sb.Append("INSERT INTO flashcards (id, stack_id, prompt, answer) SELECT id,stack_id,prompt,answer FROM new_flashcards ORDER BY id ASC; ");
        sb.Append("SET IDENTITY_INSERT flashcards OFF; "); 
        var query = sb.ToString();
        var parameter = new SqlParameter("@id", id);
        _context.ExecuteQuery(query, parameter);

    }
    public List<FlashcardDTO> GetAllFlashcards()
    {
        List<FlashcardDTO> flashcardDTOs = new List<FlashcardDTO>();
        var query = "USE [flashcardapp] SELECT flashcards.prompt,flashcards.answer FROM flashcards JOIN stacks ON flashcards.stack_id = stacks.id";
        using (SqlDataReader reader = _context.ExecuterReader(query))
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var question = reader["prompt"];
                    var answer = reader["answer"];
                    flashcardDTOs.Add(new FlashcardDTO
                    {
                        Question = (string)question,
                        Answer = (string)answer
                    });
                }
            }
        }
        return flashcardDTOs;
    }
    public void DisplayAllFlashcard()
    {
        var query = "USE [flashcardapp] SELECT stacks.id,stacks.name,flashcards.prompt,flashcards.answer FROM flashcards JOIN stacks ON flashcards.stack_id = stacks.id";
        using (SqlDataReader reader = _context.ExecuterReader(query))
        {
                while (reader.Read())
                {
                    Flashcard flashcard = null;
                    var stackid = (int)reader["id"];
                    var stackname = (string)reader["name"];
                    var question = (string)reader["prompt"];
                    var answer = (string)reader["answer"];
                    if (flashcard == null || flashcard.Name != stackname)
                {
                    flashcard = new Flashcard(stackname, stackid);
                    flashcard.Question = question;
                    flashcard.Answer = answer;
                    flashcard.Display();
                    }
                }
 
        }
    }
    internal void AddFlashcard(string stackName,string question, string answer)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var stackId = GetId(stackName);
            if (stackId == null || stackId == 0)
            {
                stackId = CreateStack(stackName);
            }
            CreateFlashcard(stackId, question, answer);
        }
    }
}
