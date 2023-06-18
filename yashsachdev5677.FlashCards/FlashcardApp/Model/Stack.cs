using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardApp.Model
{
    internal class Stack : FlashcardStackSystem
    {
        private List<FlashcardStackSystem> cardItems = new List<FlashcardStackSystem>(); 
        public Stack(string name, int id):base(name,id)
        {
        }
        public override void Insert(FlashcardStackSystem itemToAdd)
        {
            cardItems.Add(itemToAdd);  
        }
        public override void Remove(FlashcardStackSystem itemToRemove)
        {
            cardItems.Remove(itemToRemove);
        }
        public override void clear()
        {
            cardItems.Clear();
        }
        public override int count()
        {
           return cardItems.Count;
        }
        public override void peek()
        {
            if (cardItems.Count > 0)
            {
                FlashcardStackSystem topItem = cardItems.Last();
                if (topItem is Flashcard flashcard)
                {
                    Console.WriteLine($"Question: {flashcard.Question}, Answer: {flashcard.Answer}");
                }
            }
        }
        public override void search(int indexofItem)
        {
            if (indexofItem >= 0 && indexofItem < cardItems.Count)
            {
                FlashcardStackSystem item = cardItems[indexofItem];
                if (item is Flashcard flashcard)
                    {
                    Console.WriteLine($"Question: {flashcard.Question}, Answer: {flashcard.Answer}");
                }
            }
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
