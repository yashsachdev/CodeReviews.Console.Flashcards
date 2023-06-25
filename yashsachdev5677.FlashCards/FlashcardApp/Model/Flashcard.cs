using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace FlashcardApp.Model;
internal class Flashcard : FlashcardStackSystem
{
    public Flashcard(FlashcardDTO flashcarddto)
    {
       Question = flashcarddto.Question;
        Answer = flashcarddto.Answer;
    }
    public Flashcard(string name, int id)
    {
        Name = name;
        Id = id;
    }
    public string Question { get; set; }
    public string Answer { get; set; }
    public override void Display()
    {
        Console.WriteLine("Question: " + Question);
        Console.WriteLine("Answer: " + Answer);
    }
}
