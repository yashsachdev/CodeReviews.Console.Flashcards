namespace FlashcardApp.Model;

internal abstract class FlashcardStackSystem 
{
    public string Name { get; set; }
    public int Id { get; set; }
    public abstract void Display();
    public FlashcardStackSystem()
    {
        
    }
}
