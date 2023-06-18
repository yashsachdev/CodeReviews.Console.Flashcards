namespace FlashcardApp;

internal class DatabaseClass
{
    public Databasecontext _context { get; set; }
    public string connectionString { get; set; }
    public DatabaseClass(string Connectionstring)
    {
        _context = new Databasecontext(Connectionstring);
        connectionString = Connectionstring;
    }
    public static string GetConnectionStringByName(string name)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        Console.WriteLine(baseDirectory);
        AppDomain.CurrentDomain.SetData("DataDirectory", baseDirectory);
        string returnValue = null;
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
        if (settings != null)
            returnValue = settings.ConnectionString;
        return returnValue;
    }
    public  void CreateTable()
    {
        string sql_file_name = "Flashcard_table.txt";
        string projectFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        string script = File.ReadAllText(Path.Combine(projectFolder,sql_file_name));
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            Console.WriteLine("Database Created!");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        string sql_table_name = "create-table.txt";
        script = File.ReadAllText(Path.Combine(projectFolder, sql_table_name));
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            Console.WriteLine("Table Created!");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    }
}

