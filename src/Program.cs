// See https://aka.ms/new-console-template for more information
using System;
using ProtoDB_Project;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ProtoDB_Project.src;
using ProtoDB_Project.src.Notepad;
using ProtoDB_Project.src.FinancialTools;
using System.Data;
using MongoDB;
using ProtoDB_Project.src.APIs_Dbs;
using MongoDB.Driver;
using MongoDB.Bson;
using ProtoDB_Project.src.ClientBookProto;

var RED = ConsoleColor.Red;
var MAGENTA = ConsoleColor.Magenta;
var CYAN = ConsoleColor.Cyan;
var GREEN = ConsoleColor.Green;


Menu newMenu = new Menu();
BillPayReminder newMainReminder = new BillPayReminder();
ProgramPlanner newPlanner = new ProgramPlanner();

//Fetch data
Policies newPolicy = new Policies();
newPolicy.RunMain(newPolicy);

//Login section
bool userIsLoggedIn = false;


//By default for a local MongoDB instance connectionString = "mongodb://localhost:27017" 
var connectionString = "mongodb+srv://infrareddayz:YZDCRMy7WDExazW3@cluster0.mrf2h5w.mongodb.net/?retryWrites=true&w=majority";

const string databaseName = "RTI_Client";
const string collectionName = "Clients";

//Database database = new Database(connectionString, databaseName);

GetUserLoggedIn();


//Start Main menu
WriteColor($"{newMenu.Title}", RED);
WriteColor("Author: Austin Campbell", CYAN);
WriteColor("** Type -h, --help, or /? for additional commands **", CYAN);
WriteColor("** type -quit to quit **", CYAN);
WriteColor(newMenu.cmds, CYAN);

//Pre-establish bool for while loop
bool exitProgram = false;

//While exit program is false and user is logged in
while (exitProgram != true && userIsLoggedIn)
{
    WriteColor(">> ", MAGENTA);
    string userInput = Console.ReadLine();

    //This condition is for -help, -h, or /? commands
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
    //If you didn't type -help, you'll start the switch
    else
    {
        //Imports every time so you can quickly see what's due or whateva!
        //This idea might bring me to make a legitimate dedicated financial CLI which is what this probably
        //should have been focused on.
        newMainReminder.ImportBillReminder(newMainReminder);
        switch (userInput)
        {
            case "-quit":
                exitProgram = true;
                Environment.Exit(0);
                break;

            //create user
            case "-logout":
                userIsLoggedIn = newPolicy.Logout(newPolicy);
                GetUserLoggedIn();
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

            //Save bill pay
            case "-savebp":
                newMainReminder.ExportBillReminder(newMainReminder);
                WriteColor("Wrote File to Data", GREEN);
                break;

            //Notes section
            case "-notes":
                Notepad newNotepad = new Notepad();
                newNotepad.Start(newNotepad);
                break;

            //Program Designer / Program Planner
            case "-pd":
                newPlanner.StartPlanner(newPlanner);
                break;

            //ClassDesignerEditor
            case "-cde":
                //Makes use of properties in ProgramPlanner
                if (newPlanner.ProgramName == null)
                {
                    newMenu.WriteColor("You should use -pd to plan the program first!", RED);
                }
                else
                {
                    newPlanner.RunClassMaker(newPlanner);
                }
                break;

            //FieldsDesigner
            case "-fd":
                //Makes use of properties in ProgramPlanner
                if (newPlanner.IsClasses == null)
                {
                    newMenu.WriteColor("You should use -cde to create classes first!", RED);
                }
                else
                {
                    newPlanner.RunClassFieldsMaker(newPlanner);
                }
                break;

            //Export Program Designer
            case "-exportpd":
                if (newPlanner.IsClasses == null)
                {
                    newMenu.WriteColor("You should create a program plan before exporting.", RED);
                }
                else
                {
                    newPlanner.ExportProgram(newPlanner);
                }
                break;

            //Client Manager
            case "-cm":
                if (newPolicy.policy == 3)
                {
                    ClientManager newManager = new ClientManager();
                    newManager.Start();
                }
                else
                {
                    Console.WriteLine("Your policy is insufficient to access this command.");
                    break;
                }
                break;
        }
    }
}


//Logs a user in.
void GetUserLoggedIn()
{
    Clear();
    WriteColor($"{newMenu.Title}", RED);
    WriteColor($"           ---> Program contains sensitive information and requires login <---", ConsoleColor.DarkGray);
    userIsLoggedIn = newPolicy.Login(newPolicy);

    if (userIsLoggedIn)
    {
        //Shows success message for 2000 seconds
        Thread.Sleep(2000);
        Clear();
    }
    else
    {
        userIsLoggedIn = newPolicy.Login(newPolicy);
    }
}



//Clears the console.
static void Clear()
{
    Console.Clear();
}


//WriteColor
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