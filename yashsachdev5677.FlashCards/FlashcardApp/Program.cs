// See https://aka.ms/new-console-template for more information
using FlashcardApp;
using FlashcardApp.Model;
/*
Console.WriteLine("Hello, World!");
var MainStack = new Stack("Studies", 1);
var Subject = new Stack("Science", 1);
var Topic = new Flashcard("organic chemistry", 1);

MainStack.Insert(Subject);
MainStack.Insert(Topic);

var topic1 = new Flashcard("thrmodynamics",2);
MainStack.Insert(topic1);

Console.WriteLine( $"Id of thremodynamics:{topic1.Id}");
Console.WriteLine($"Id of organic chemistry:{Topic.Id}");
Console.WriteLine($"count is :{MainStack.count()}");*/
string projectFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
var connectionString = DatabaseClass.GetConnectionStringByName("Flashcard");
DatabaseClass databaseClass = new DatabaseClass(connectionString);
/*databaseClass.CreateTable();*/
Databasecontext context = new Databasecontext(connectionString);
var flashcardmanager = new FlashcardManager(connectionString);
flashcardmanager.AddFlashcard("Stack 1","Question 1","Answer 1");
flashcardmanager.AddFlashcard("Stack 1", "Question 2", "Answer 2");
flashcardmanager.AddFlashcard("Stack 2", "Question 1", "Answer 1");
flashcardmanager.DisplayAllFlashcard();

var flashcards = flashcardmanager.GetAllFlashcards();
foreach (var flashcard in flashcards)
{
    Console.WriteLine("Question: " + flashcard.Question);
    Console.WriteLine("Answer: " + flashcard.Answer);
    Console.WriteLine("------------------------------");
}
Console.ReadKey();
