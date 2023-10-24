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
        private List<ProgramFields> _attribute = new List<ProgramFields>();
        private List<ProgramFields> _constructor = new List<ProgramFields>();
        private List<ProgramFields> _method = new List<ProgramFields>();


        public void StartPF(ProgramPlanner mainPlanner)
        {
            bool userQuit = false;

            while (userQuit != true)
            {
                Console.Write(@"
                Options:
                1: Fetch Class to Edit Fields
                2: Exit
                ");
                int choice1 = int.Parse(Console.ReadLine());

                switch (choice1)
                {
                    case 1:
                        ClassFieldsEditorLoop();
                        break;
                    case 2:
                        userQuit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry..");
                        break;
                }

            }
        }



        private void ClassFieldsEditorLoop(ProgramPlanner mainPlanner)
        {
            string cName = LoopThroughClasses(mainPlanner);
            bool userExitClass = false;

            //Instantiate the object now so we don't forget.
            ProgramFields newClassFields = new ProgramFields();

            while (userExitClass == false)
            {
                Console.WriteLine($"Options for {cName} class");
                Console.Write(@"
                        1: Modify Attributes
                        2: Modify Constructors
                        3: Modify Methods
                        4: Exit
                        ");
                int choice2 = int.Parse(Console.ReadLine());

                switch (choice2)
                {
                    case 1:
                        //Run attributes meth
                        //TODO: Add newly created attributes to the list!
                        break;
                    case 2:
                        //TODO: Constructor
                        //Run it, then add it!
                        break;
                    case 3:
                        //TODO: Methods
                        //Run it, then add it.
                        break;
                    case 4:
                        userExitClass = true;
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
            foreach (ProgramClass c in mainPlanner.GetClasses())
            {
                count++;
                Console.WriteLine($"{count} - {c}");
            }
            Console.Write("Which class would you like to add fields to?: ");
            int selection = int.Parse(Console.ReadLine());

            string className = "";
            Action getTheOne = () =>
            {
                ProgramClass getClass = mainPlanner.GetClasses()[selection - 1];
                className = getClass.GetClassnameString();
            };
            getTheOne();
            return className;
        }


        protected override ProgramFields CreateNewAttribute(string attrName)
        {
            throw new NotImplementedException();
        }


        protected override ProgramFields CreateNewConstructor(string conName, string optionalparam = "None")
        {
            throw new NotImplementedException();
        }


        protected override ProgramFields CreateNewMethod(string methName, string optionalparam = "None", string optionalreturn = "void")
        {
            throw new NotImplementedException();
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
