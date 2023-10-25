using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Reference to the classes in a planned program.
    /// </summary>
    internal class ProgramClass : PlannerParent
    {
        private List<ProgramFields> _classFields = new List<ProgramFields>();
        private string _className;
        private string _inheritedClass;
        private bool _isInherit;

        /// <summary>
        /// Constructor to create a new ProgramClass with a classname only, no inheritance.
        /// </summary>
        /// <param name="className">Must have a class name to create a class!</param>
        private ProgramClass(string className)
        {
            _className = className;
        }


        /// <summary>
        /// Property that recieves the _classFields list from the ProgramClass.
        /// </summary>
        public List<ProgramFields> getClassFields { get { return _classFields; } }


        /// <summary>
        /// Gets the class name of the created class as a string.
        /// </summary>
        /// <returns>String version of the classname</returns>
        public string GetClassnameString {  get { return _className; } }


        /// <summary>
        /// Adds the ProgramFields object to the ProgramClass 'classes' list.
        /// </summary>
        /// <param name="mainPlanner">Required parameter</param>
        /// <param name="newFields">Newly created field</param>
        public void AddToClassFields(ProgramPlanner mainPlanner, ProgramFields newFields)
        {
            _classFields.Add(newFields);
        }


        /// <summary>
        /// Constructor to create a new inherited program class.
        /// </summary>
        /// <param name="inheritedClass">Must have a class that will be inheriting from a parent.</param>
        private ProgramClass(bool inherited, string inheritedClass)
        {
            _isInherit = inherited;
            _inheritedClass = inheritedClass;
        }


        /// <summary>
        /// Used to instantiate and access the StartClassMaker
        /// </summary>
        public ProgramClass() { }



        /// <summary>
        /// Starts the primary logic of the ProgramClassMaker
        /// </summary>
        /// <param name="planner"></param>
        public void StartClassMaker(ProgramPlanner planner)
        {
            Menu setColor = new Menu();

            bool didQuit = false;

            while (didQuit != true)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("CreateAClass Options: \n");
                Console.WriteLine("1: Create New Parent Class");
                Console.WriteLine("2: Create New Child Class");
                Console.WriteLine("3: Display Classes");
                Console.WriteLine("4: Quit");
                int userInput = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Please type a new parent classname.");
                        Console.Write("-> ");
                        string newUserClassName = Console.ReadLine();
                        ProgramClass creation = new ProgramClass(newUserClassName);
                        planner.AddClassToList(creation);
                        break;
                    case 2:
                        Console.WriteLine("Please choose a class to add as parent.");
                        string getParent = LoopThruClasses(planner);
                        Console.WriteLine("What is the child's classname?: ");
                        string child = Console.ReadLine();
                        ProgramClass inheritedCreation = CreateNewInheritedClass(getParent, child);
                        planner.AddClassToList(inheritedCreation);
                        break;
                    case 3:
                        DisplayClasses(planner);
                        break;
                    case 4:
                        didQuit = true;
                        break;
                    default:
                        setColor.WriteColor("Invalid Entry..", ConsoleColor.Red);
                        StartClassMaker(planner);
                        break;
                }
            }


        }


        /// <summary>
        /// Displays all classes in the planner.
        /// </summary>
        /// <param name="mainPlanner">Required parameter</param>
        private void DisplayClasses(ProgramPlanner mainPlanner)
        {
            foreach (ProgramClass cClass in mainPlanner.GetClasses)
            {
                Console.WriteLine(cClass.DisplayClassName());
            }
        }


        /// <summary>
        /// Displays a formatted className. Uses a conditional to check if the class is Inherited.
        /// </summary>
        /// <returns>The formatted classname as a string.</returns>
        public string DisplayClassName()
        {
            string str = "";
            if (_isInherit == true)
            {
                str = $"Inherited Class: {_inheritedClass}";
            }
            else
            {
                str = $"Class: {_className}";
            }
            return str;
        }


        /// <summary>
        /// Iterates through created Classes, allows user to select a created class to attach a child class to.
        /// </summary>
        /// <param name="planner">Required parameter.</param>
        /// <returns>The parent classname.</returns>
        protected string LoopThruClasses(ProgramPlanner planner)
        {
            int counter = 0;
            foreach (ProgramClass cName in planner.GetClasses)
            {
                counter++;
                Console.WriteLine($"{counter}. {cName.DisplayClassName()}");
            }
            Console.WriteLine("Which class do you choose?: ");
            int selection = int.Parse(Console.ReadLine());

            string parent = "";
            //Well, turns out this lambda is actually kind of useless. I suppose it is
            //slightly more organized..
            Action getSelection = () =>
            {
                ProgramClass getClass = planner.GetClasses[selection - 1];
                parent = getClass._className;
            };
            getSelection();
            return parent;
        }


        /// <summary>
        /// Creates a new classname object.
        /// </summary>
        /// <param name="className">ClassName as a string.</param>
        /// <returns>A ProgramClass object.</returns>
        protected override ProgramClass CreateNewClass(string className)
        {
            return new ProgramClass(className);
        }


        /// <summary>
        /// Creates a new child class by attaching the new child class to a parent class
        /// </summary>
        /// <param name="parent">Required to attach the new child classname to the parent.</param>
        /// <param name="child">Required, this is the new classname that gets attached to the parent.</param>
        protected override ProgramClass CreateNewInheritedClass(string parent, string child)
        {
            child = $"{child} : {parent}";
            return new ProgramClass(true, child);
        }





        /*
         * This segment is only used to satisfy the abstract class * 
         * 
        */

        protected override void CreateAttributes(ProgramFields field)
        {
        }

        protected override void CreateConstructor(ProgramFields field)
        {
        }

        protected override void CreateMethod(ProgramFields field)
        {
        }
    }
}
