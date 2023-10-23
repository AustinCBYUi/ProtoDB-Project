using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Primary planner / parent class. Controls all primary behaviors.
    /// </summary>
    internal abstract class ProgramPlanner
    {
        private string _programName;
        private bool _isInheritedClass;
        private List<ProgramClass> _classes = new List<ProgramClass>();
        private string _frameWorkUsed;
        private string _featuresText;
        private string _applicationType;

        Menu setColor = new Menu();

        protected virtual void ProgramInfo()
        {
            Console.WriteLine($"Name: {_programName}");
            Console.WriteLine($"Frameworks: {_frameWorkUsed}");
            Console.WriteLine($"Features: {_featuresText}");
            Console.WriteLine($"Application Type: {_applicationType}");
        }


        protected void StartPlanner(ProgramPlanner mainPlanner)
        {
            setColor.WriteColor("Class Planner Module", ConsoleColor.Cyan);
            setColor.WriteColor("This module is used to plan the application..", ConsoleColor.Cyan);
            Console.WriteLine("What is the name of the program/application?: ");
            string progName = Console.ReadLine();
            Console.WriteLine("What frameworks will you use?: ");
            string frameworks = Console.ReadLine();
            Console.WriteLine("What are planned features?: ");
            string features = Console.ReadLine();
            Console.WriteLine("What is the application type?(WinForms/Web App/CLI?): ");
            string appType = Console.ReadLine();
        }


        protected abstract void CreateNewClass();



        /// <summary>
        /// Adds a new Class to the _classes List.
        /// </summary>
        /// <param name="addClass">New class entry</param>
        protected virtual void AddClassToList(ProgramClass addClass)
        {
            _classes.Add(addClass);
        }
    }
}
