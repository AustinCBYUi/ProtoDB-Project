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

        public ProgramPlanner(string progName, string frameUsed, string featText, string appType)
        {
            _programName = progName;
            _frameWorkUsed = frameUsed;
            _featuresText = featText;
            _applicationType = appType;
        }


        /// <summary>
        /// Displays info that is pre-estabilished by user to the console.
        /// </summary>
        public void ProgramInfo()
        {
            Console.WriteLine($"Name: {_programName}");
            Console.WriteLine($"Frameworks: {_frameWorkUsed}");
            Console.WriteLine($"Features: {_featuresText}");
            Console.WriteLine($"Application Type: {_applicationType}");
        }


        public List<ProgramClass> GetClasses()
        {
            return _classes;
        }


        /// <summary>
        /// Gets general details of a program that is in planning.
        /// </summary>
        /// <param name="mainPlanner">Main planner as a parameter.</param>
        public void StartPlanner(ProgramPlanner mainPlanner)
        {
            bool userQuit = false;
            while (userQuit != true)
            {
                Console.WriteLine("1: Create New Program Plan");
                Console.WriteLine("2: View Program Plan");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        setColor.WriteColor("Class Planner Module", ConsoleColor.Cyan);
                        setColor.WriteColor("This module is used to plan the application..\n", ConsoleColor.Cyan);
                        Console.WriteLine("What is the name of the program/application?: ");
                        string progName = Console.ReadLine();
                        Console.WriteLine("What frameworks will you use?: ");
                        string frameworks = Console.ReadLine();
                        Console.WriteLine("What are planned features?: ");
                        string features = Console.ReadLine();
                        Console.WriteLine("What is the application type?(WinForms/Web App/CLI?): ");
                        string appType = Console.ReadLine();

                        mainPlanner.AddToPlanner(progName, frameworks, features, appType, mainPlanner);
                        break;
                    case 2:
                        mainPlanner.ProgramInfo();
                        break;
                }
            }
        }


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
        protected void ExportProgram()
        {

        }


        /// <summary>
        /// Imports the entire program for editing?
        /// </summary>
        protected void ImportProgram() 
        {
        }
    }
}
