// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SQLite;
using ProtoDB_Project;
using ProtoDB_Project.src;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

var RED = ConsoleColor.Red;
var MAGENTA = ConsoleColor.Magenta;
var CYAN = ConsoleColor.Cyan;
var GREEN = ConsoleColor.Green;


Menu newMenu = new Menu();
BillPayReminder newMainReminder = new BillPayReminder();
ProgramPlanner newPlanner = new ProgramPlanner();

WriteColor($"{newMenu.Title}", RED);
WriteColor("Author: Austin Campbell", CYAN);
WriteColor("** Type -h, --help, or /? for additional commands **", CYAN);
WriteColor("** type -quit to quit **", CYAN);
WriteColor(newMenu.cmds, CYAN);
bool exitProgram = false;

while (exitProgram != true)
{
    //TopLine Constructors

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
        newMainReminder.ImportBillReminder(newMainReminder);
        switch (userInput)
        {
            case "-quit":
                exitProgram = true;
                Environment.Exit(0);
                break;
            //create user
            case "-createuser":
                Policies newUser = new Policies();
                string userName = newUser.GetUserName();
                string password = newUser.GetPassword();
                int policy = newUser.GetPolicy();
                break;
            //create bill to pay
            case "-createbp":
                Console.WriteLine("Bill name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Due Date (MM/DD/YYYY: ");
                string date = Console.ReadLine();
                Console.WriteLine("Amount: ");
                double amount = double.Parse(Console.ReadLine());
                Console.WriteLine("Is bill paid?: ");
                string paidOrNot = Console.ReadLine().ToLower();

                CreateBillPay newBill = new CreateBillPay(name, date, amount, paidOrNot);
                newMainReminder.AddBillToList(newBill);
                break;
            //view bills to pay
            case "-viewbp":
                newMainReminder.ViewBills(newMainReminder);
                break;
            case "-savebp":
                newMainReminder.ExportBillReminder(newMainReminder);
                WriteColor("Wrote File to Data", GREEN);
                break;

            case "-notes":
                Notepad newNotepad = new Notepad();
                newNotepad.Start(newNotepad);
                break;
            case "-pd":
                newPlanner.StartPlanner(newPlanner);
                break;
            //ClassDesignerEditor
            case "cde":
                newPlanner.RunClassMaker(newPlanner);
                break;
            //FieldsDesigner
            case "fd":
                break;
            

                //Tester case
            case "-test":
                CreateBillPay newBillTest = new CreateBillPay("eh", "10/26/2023", 55, "yes");
                string test = newBillTest.IsBillDue();
                Console.WriteLine(test);
                break;
        }
    }
}


static void Clear()
{
    Console.Clear();
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