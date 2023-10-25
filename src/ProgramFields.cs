using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Reference to the individual fields in a planned program like attributes, constructors and methods.
    /// </summary>
    internal class ProgramFields : PlannerParent
    {
        private string _className;
        private ProgramClass _parentClass;
        private List<string> _attributes = new List<string>();
        private List<string> _constructor = new List<string>();
        private List<string> _method = new List<string>();


        Menu setColor = new Menu();

        public List<string> GetAttributes { get { return _attributes; } }
        public List<string> GetConstructor { get {  return _constructor; } }
        public List<string> GetMethod { get {  return _method; } }

        /// <summary>
        /// Starts the ProgramField Editor
        /// </summary>
        /// <param name="mainPlanner">Requires the main planner as a parameter to work.</param>
        public void StartPF(ProgramPlanner mainPlanner)
        {
            bool userQuit = false;

            while (userQuit != true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(@"
                Options:
                1: Fetch Class to Edit Fields
                2: View Classes Fields
                3: Exit
                ");
                int choice1 = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (choice1)
                {
                    //Fetch classes
                    case 1:
                        ClassFieldsEditorLoop(mainPlanner);
                        break;
                    case 2:
                        ProgramClass getSelection = SelectDisplayClasses(mainPlanner);
                        ViewClassFields(getSelection);
                        break;
                    //Exit
                    case 3:
                        userQuit = true;
                        break;
                    //Default
                    default:
                        Console.WriteLine("Invalid Entry..");
                        break;
                }

            }
        }


        /// <summary>
        /// Loops through each created class and allows you to add fields to it.
        /// </summary>
        /// <param name="mainPlanner"></param>
        private void ClassFieldsEditorLoop(ProgramPlanner mainPlanner)
        {
            string cName = LoopThroughClasses(mainPlanner);
            bool userExitClass = false;

            //Instantiate the object now so we don't forget.
            ProgramFields newClassFields = new ProgramFields();

            while (userExitClass == false)
            {
                setColor.WriteColor($"Options for {cName} class", ConsoleColor.Green);
                setColor.WriteColor("Once finished editing, use the exit to return to menus.", ConsoleColor.Green);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(@"
            1: Modify Attributes
            2: Modify Constructors
            3: Modify Methods
            4: Exit
            ");
                int choice2 = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (choice2)
                {
                    case 1:
                        CreateAttributes(newClassFields);
                        break;
                    case 2:
                        CreateConstructor(newClassFields);
                        break;
                    case 3:
                        CreateMethod(newClassFields);
                        break;
                    case 4:
                        _parentClass.AddToClassFields(mainPlanner, newClassFields);
                        userExitClass = true;
                        break;
                }
            }
        }


        /// <summary>
        /// Displays all classes so the user can choose one to add fields to.
        /// </summary>
        /// <param name="mainPlanner"></param>
        /// <returns></returns>
        private ProgramClass SelectDisplayClasses(ProgramPlanner mainPlanner)
        {
            int count = 0;
            foreach (ProgramClass c in mainPlanner.GetClasses)
            {
                count++;
                setColor.WriteColor($"{count} - {c.DisplayClassName()}", ConsoleColor.Blue);
            }
            setColor.WriteColor("Which class would you like to view the fields of?", ConsoleColor.Yellow);
            int selection = int.Parse(Console.ReadLine());

            ProgramClass getClass = mainPlanner.GetClasses[selection - 1];

            return getClass;
        }


        /// <summary>
        /// Displays all classes and class fields that are part of the class.
        /// </summary>
        /// <param name="selectedClass">The selected class</param>
        private void ViewClassFields(ProgramClass selectedClass)
        {
            setColor.WriteColor($"{selectedClass.GetClassnameString} Fields", ConsoleColor.Cyan);
            setColor.WriteColor("Attributes: ", ConsoleColor.DarkYellow);
            //This doesn't really make sense now that I'm looking at it, but it works..
            foreach (ProgramFields tryThis in selectedClass.getClassFields)
            {
                //Attributes
                int countA = 0;
                foreach (string a in tryThis._attributes)
                {
                    countA++;
                    setColor.WriteColor($"{countA}: {a}", ConsoleColor.Yellow);
                }
                //Constructors
                setColor.WriteColor("Constructors: ", ConsoleColor.DarkYellow);
                int countC = 0;
                foreach (string c in tryThis._constructor)
                {
                    countC++;
                    setColor.WriteColor($"{countC}: {c}", ConsoleColor.Yellow);
                }
                //Methods
                setColor.WriteColor("Methods: ", ConsoleColor.DarkYellow);
                int countM = 0;
                foreach (string m in tryThis._method)
                {
                    countM++;
                    setColor.WriteColor($"{countM}: {m}", ConsoleColor.Yellow);
                }
            }
        }
        


        /// <summary>
        /// Creates attributes using parameter ProgramFields Object
        /// </summary>
        /// <param name="newFields"></param>
        protected override void CreateAttributes(ProgramFields newFields)
        {
            bool userExit = false;
            
            while (userExit != true)
            {
                setColor.WriteColor("1: Create New Attribute", ConsoleColor.Cyan);
                setColor.WriteColor("2: Exit", ConsoleColor.Cyan);
                int userTyped = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (userTyped)
                {
                    case 1:
                        Console.Write("Attribute protection(Private/Public/Etc..): ");
                        string protection = Console.ReadLine().ToLower();
                        Console.Write("Attribute type(String/Int/Etc..): ");
                        string type = Console.ReadLine().ToLower();
                        Console.Write("Attribute Name: ");
                        string attrName = Console.ReadLine();
                        string formatAttribute = $"{protection} _{attrName} : {type}";

                        newFields._attributes.Add(formatAttribute);
                        break;
                    case 2:
                        userExit = true;
                        Console.ResetColor();
                        break;
                }
            }
        }


        /// <summary>
        /// Creates a constructor using parameter ProgramFields Object and adds it to the Constructor list.
        /// </summary>
        /// <param name="newFields">Program Fields Object.</param>
        protected override void CreateConstructor(ProgramFields newFields)
        {
            bool userExit = false;

            while (userExit != true)
            {
                setColor.WriteColor("1: Create Constructor", ConsoleColor.Cyan);
                setColor.WriteColor("2: Exit", ConsoleColor.Cyan);
                int userTyped = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (userTyped)
                {
                    case 1:
                        Console.Write("Protection Level(Private/Public): ");
                        string protection = Console.ReadLine();
                        Console.Write("Constructor Params: ");
                        string parameters = Console.ReadLine();
                        string formatConstructor = $"{protection} {_className}({parameters})";

                        newFields._constructor.Add(formatConstructor);
                        break;
                    case 2:
                        userExit = true;
                        Console.ResetColor();
                        break;
                }
            }
        }


        /// <summary>
        /// Creates a new method and adds it to the Methods list.
        /// </summary>
        /// <param name="newFields">Program Fields Object</param>
        protected override void CreateMethod(ProgramFields newFields)
        {
            bool userExit = false;

            while (userExit != true)
            {
                setColor.WriteColor("1: Create Method", ConsoleColor.Cyan);
                setColor.WriteColor("2: Exit", ConsoleColor.Cyan);
                int userTyped = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (userTyped)
                {
                    case 1:
                        Console.Write("Method Protection Level: ");
                        string protect = Console.ReadLine().ToLower();
                        Console.Write("Method Return type: ");
                        string returns = Console.ReadLine().ToLower();
                        Console.Write("Method Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Method Parameters?: ");
                        string parameters = Console.ReadLine();
                        string formatMethod = $"{protect} {name}({parameters}) : {returns}";

                        newFields._method.Add(formatMethod);
                        break;

                    case 2:
                        userExit = true;
                        Console.ResetColor();
                        break;
                }
            }
        }


        /// <summary>
        /// Gets the class the user would like to add data fields to.
        /// </summary>
        /// <param name="mainPlanner">Required parameter as the main instance.</param>
        /// <returns>Classname as a string.</returns>
        private string LoopThroughClasses(ProgramPlanner mainPlanner)
        {
            int count = 0;
            foreach (ProgramClass c in mainPlanner.GetClasses)
            {
                count++;
                
                Console.WriteLine($"{count} - {c.DisplayClassName()}");
            }
            Console.Write("Which class would you like to add fields to?: ");
            int selection = int.Parse(Console.ReadLine());

            ProgramClass getClass = mainPlanner.GetClasses[selection - 1];
            _parentClass = getClass;
            string className = getClass.GetClassnameString;

            return className;
        }




        /*
         * This segment is not used by this class! *
         * Only placed in here to avoid *
        */

        protected override ProgramClass CreateNewClass(string className)
        {
            throw new NotImplementedException();
        }
        protected override ProgramClass CreateNewInheritedClass(string parentClass, string childClass)
        {
            throw new NotImplementedException();
        }
    }
}
