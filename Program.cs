// See https://aka.ms/new-console-template for more information
using ProtoDB_Project;
using System.Reflection;

var RED = ConsoleColor.Red;
var MAGENTA = ConsoleColor.Magenta;
var CYAN = ConsoleColor.Cyan;

Console.ForegroundColor = ConsoleColor.Red;

Menu newMenu = new Menu();
bool exitProgram = false;

while (exitProgram != true)
{
    Console.WriteLine($"{newMenu.GetTitle}");

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("Author: Austin Campbell", CYAN);
    Console.WriteLine("** Type /help for additional commands **", CYAN);
    Console.WriteLine("** Press Escape button to exit program or type 15 **", CYAN);



    Console.WriteLine(newMenu.GetMenu, CYAN);
    Console.Write(">> ", MAGENTA);
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Does this work?");
            break;

        case "15":
            exitProgram = true;
            Environment.Exit(0);
            break;
    }
}