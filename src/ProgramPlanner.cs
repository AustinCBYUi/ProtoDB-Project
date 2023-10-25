using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Primary planner / parent class. Controls all primary behaviors. Used to manage.
    /// </summary>
    internal class ProgramPlanner
    {
        private string _programName;
        private bool _isInheritedClass;
        protected List<ProgramClass> _classes = new List<ProgramClass>();
        private string _frameWorkUsed;
        private string _featuresText;
        private string _applicationType;

        Menu setColor = new Menu();



        public ProgramPlanner() { }


        /// <summary>
        /// Property to return the program's name.
        /// </summary>
        public string ProgramName { get { return _programName; } }

        /// <summary>
        /// Property to return the list of ProgramClasses
        /// </summary>
        public List<ProgramClass> IsClasses { get { return _classes; } }


        /// <summary>
        /// Displays info that is pre-estabilished by user to the console.
        /// </summary>
        public void ProgramInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {_programName}");
            Console.WriteLine($"Frameworks: {_frameWorkUsed}");
            Console.WriteLine($"Features: {_featuresText}");
            Console.WriteLine($"Application Type: {_applicationType}");
            Console.ResetColor();
        }


        /// <summary>
        /// Getter for returning the classes list, should be a property instead.
        /// </summary>
        /// <returns></returns>
        public List<ProgramClass> GetClasses { get { return _classes; } }


        /// <summary>
        /// Gets general details of a program that is in planning.
        /// </summary>
        /// <param name="mainPlanner">Main planner as a parameter.</param>
        public void StartPlanner(ProgramPlanner mainPlanner)
        {
            bool userQuit = false;
            while (userQuit != true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1: Create New Program Plan");
                Console.WriteLine("2: View Program Plan");
                Console.WriteLine("3: Exit to Menu");
                int userChoice = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (userChoice)
                {
                    case 1:
                        setColor.WriteColor("Class Planner Module", ConsoleColor.Cyan);
                        setColor.WriteColor("This module is used to plan the application..\n", ConsoleColor.Cyan);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("What is the name of the program/application?: ");
                        string progName = Console.ReadLine();
                        Console.WriteLine("What frameworks will you use?: ");
                        string frameworks = Console.ReadLine();
                        Console.WriteLine("What are planned features?: ");
                        string features = Console.ReadLine();
                        Console.WriteLine("What is the application type?(WinForms/Web App/CLI?): ");
                        string appType = Console.ReadLine();
                        Console.ResetColor();

                        mainPlanner.AddToPlanner(progName, frameworks, features, appType, mainPlanner);
                        break;
                    case 2:
                        mainPlanner.ProgramInfo();
                        break;
                    case 3:
                        userQuit = true;
                        break;
                }
            }
        }


        /// <summary>
        /// Adds the details to the instantiated planner, controls flow to being inside the ProgramPlanner.cs instead of the
        /// main program file.
        /// </summary>
        /// <param name="prog">Program name as a string</param>
        /// <param name="framework">Program framework used, as a string.</param>
        /// <param name="feat">Features of the program as a string</param>
        /// <param name="app">Application type as a string</param>
        /// <param name="mainPlanner">Required parameter which transfers the instance</param>
        protected void AddToPlanner(string prog, string framework, string feat, string app, ProgramPlanner mainPlanner)
        {
            _programName = prog;
            _frameWorkUsed = framework;
            _featuresText = feat;
            _applicationType = app;
        }


        /// <summary>
        /// Starts the child class's StartClassMaker function to start creating classes.
        /// </summary>
        /// <param name="mainPlanner">Required parameter as the primary planner manager.</param>
        public void RunClassMaker(ProgramPlanner mainPlanner)
        {
            ProgramClass startClassPlanner = new ProgramClass();
            startClassPlanner.StartClassMaker(mainPlanner);
        }


        /// <summary>
        /// Starts the fields class maker to start editing the fields of classes.
        /// </summary>
        /// <param name="mainPlanner">Required parameter as the primary planner manager</param>
        public void RunClassFieldsMaker(ProgramPlanner mainPlanner)
        {
            ProgramFields startClassFieldsPlanner = new ProgramFields();
            startClassFieldsPlanner.StartPF(mainPlanner);
        }


        /// <summary>
        /// Adds a new Class to the _classes List.
        /// </summary>
        /// <param name="addClass">New class entry</param>
        public void AddClassToList(ProgramClass addClass)
        {
            _classes.Add(addClass);
        }


        /// <summary>
        /// Exports the entire program, should only be used once completely finished.
        /// </summary>
        public void ExportProgram(ProgramPlanner mainPlanner)
        {
            try
            {
                using (StreamWriter output = new StreamWriter($"{_programName}.txt"))
                {
                    output.WriteLine($">>> Program Name: {_programName} <<<");
                    output.WriteLine($"Frameworks: {mainPlanner._frameWorkUsed}");
                    output.WriteLine($"Features: \n      {mainPlanner._featuresText}");
                    output.WriteLine($"Application Type: {mainPlanner._applicationType}\n\n");
                    foreach (ProgramClass pClass in _classes)
                    {
                        output.WriteLine($"{pClass.DisplayClassName()}");
                        foreach (ProgramFields field in pClass.getClassFields)
                        {
                            output.WriteLine("** Attributes **");
                            foreach (string attributes in field.GetAttributes)
                            {
                                output.WriteLine($"         {attributes}");
                            }
                            output.WriteLine("** Constructors **");
                            foreach (string constructors in field.GetConstructor)
                            {
                                output.WriteLine($"         {constructors}");
                            }
                            output.WriteLine("** Methods **");
                            foreach (string methods in field.GetMethod)
                            {
                                output.WriteLine($"         {methods}");
                            }
                        }
                        output.WriteLine("             ");
                    }
                }
                setColor.WriteColor("Program has been written!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                setColor.WriteColor($"{ex.Message}", ConsoleColor.Red);
            }
        }


        /// <summary>
        /// Imports the entire program for editing?
        /// </summary>
        protected void ImportProgram() 
        {
        }
    }
}
