namespace FlashcardApp.Model;

internal class StudySession
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public Stack<Flashcard> Flashcardstack { get; set; }
    public StudySession(Stack<Flashcard> flashcards)
    {
        Date = DateTime.Now;
        Score = 0;
        Flashcardstack = flashcards;
    }
}
