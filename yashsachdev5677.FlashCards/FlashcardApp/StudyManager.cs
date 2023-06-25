
namespace FlashcardApp;

internal class StudyManager
{
    public Databasecontext _context { get; set; }
    public string _connectionString { get; set; }
    public StudyManager(string connectionString)
    {
        _context = new Databasecontext(connectionString);
        _connectionString = connectionString;
    }

}
