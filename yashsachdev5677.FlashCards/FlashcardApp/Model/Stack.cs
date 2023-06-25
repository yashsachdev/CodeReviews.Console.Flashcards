using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardApp.Model
{
    internal class Stack : FlashcardStackSystem
    {
        public List<FlashcardStackSystem> cardItems = new List<FlashcardStackSystem>();
        public Stack(string name)
        {
            Name = name;
        }
        public void AddFlashcard(FlashcardDTO flashcarddto)
        {
            Flashcard flashcard = new Flashcard(flashcarddto);
            cardItems.Add(flashcard);
        }
        public void RemoveFlashcard(FlashcardStackSystem card)
        {
            cardItems.Remove(card);
        }

        public override void Display()
        {
            Console.WriteLine("Stack: " + Name);
            Console.WriteLine("------------------------------");
            foreach (var flashcard in cardItems)
            {
                flashcard.Display();
                Console.WriteLine("------------------------------");
            }
        }
    }
}
