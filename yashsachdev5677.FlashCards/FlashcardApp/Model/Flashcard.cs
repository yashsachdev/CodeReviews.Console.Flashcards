using System.Xml.Linq;

namespace FlashcardApp.Model;
internal class Flashcard : FlashcardStackSystem
{
    public Flashcard(string name, int id) : base(name, id)
    {
    }
    public string Question { get; set; }
    public string Answer { get; set; }
    public override void Insert(FlashcardStackSystem itemToAdd)
    {
        throw new NotImplementedException();
    }
    public override void Remove(FlashcardStackSystem itemToRemove)
    {
        throw new NotImplementedException();
    }
    public override void clear()
    {
        throw new NotImplementedException();
    }
    public override int count()
    {
        throw new NotImplementedException();
    }
    public override void peek()
    {
        throw new NotImplementedException();

    }
    public override void search(int indexofItem)
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        Console.WriteLine("Question: " + Question);
        Console.WriteLine("Answer: " + Answer);
    }
}
