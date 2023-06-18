namespace FlashcardApp.Model;

internal abstract class FlashcardStackSystem 
{
    public string Name { get; set; }
    public int Id { get; set; }
    public abstract void Insert(FlashcardStackSystem itemToAdd);
    public abstract void Remove(FlashcardStackSystem itemToRemove);
    public abstract void clear();
    public abstract int count();
    public abstract void peek();
    public abstract void search(int indexofItem);
    public abstract void Display();
    public FlashcardStackSystem(string name,int id)
    {
        Name = name;
        Id = id;
    }
}
