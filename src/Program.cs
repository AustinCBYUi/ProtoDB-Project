// See https://aka.ms/new-console-template for more information
using ProtoDB_Project;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

var RED = ConsoleColor.Red;
var MAGENTA = ConsoleColor.Magenta;
var CYAN = ConsoleColor.Cyan;
var GREEN = ConsoleColor.Green;


Menu newMenu = new Menu();
WriteColor($"{newMenu.Title}", RED);
WriteColor("Author: Austin Campbell", CYAN);
WriteColor("** Type -h, --help, or /? for additional commands **", CYAN);
WriteColor("** type -quit to quit **", CYAN);
WriteColor(newMenu.cmds, CYAN);
bool exitProgram = false;

while (exitProgram != true)
{
    WriteColor(">> ", MAGENTA);
    string userInput = Console.ReadLine();

    if (userInput.Length >= 2 && HelpRequired(userInput))
    {
        //Kind of ridiculous..
        //if inputs length is greaterthan or equal to 3 and HelpRequired with user input as param is true AND
        //user input contains a space, then we will perform the following.
        if (userInput.Length >= 3 && HelpRequired(userInput) && userInput.Contains(" "))
        {
            string[] splits = userInput.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string getCmd = newMenu.Help(splits[1]);
            WriteColor(getCmd, GREEN);
            newMenu.ShowSpinner(1);
        }
        else
        {
            WriteColor(newMenu.cmds, GREEN);
            newMenu.ShowSpinner(1);
        }
    }
    else
    {
        switch (userInput)
        {
            case "-quit":
                exitProgram = true;
                Environment.Exit(0);
                break;
        }
    }
}



static void WriteColor(string msg, ConsoleColor color)
{
    if (msg.StartsWith(">> "))
    {
        Console.ForegroundColor = color;
        Console.Write($"{msg} ");
    }
    else
    {
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}


//Should be used to match first initial part and then help find whatever is after.
static bool HelpRequired(string param)
{
    if (param.StartsWith("-h") || param.StartsWith("--help") || param.StartsWith("/?"))
    {
        return true;
    }
    return param == "-h" || param == "--help" || param == "/?";
}