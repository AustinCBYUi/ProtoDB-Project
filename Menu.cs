using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project
{
    internal class Menu
    {
        private string _title = @"
                ██████╗░██████╗░░█████╗░████████╗░█████╗░░░░░░░██████╗░██████╗░
                ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗░░░░░░██╔══██╗██╔══██╗
                ██████╔╝██████╔╝██║░░██║░░░██║░░░██║░░██║█████╗██║░░██║██████╦╝
                ██╔═══╝░██╔══██╗██║░░██║░░░██║░░░██║░░██║╚════╝██║░░██║██╔══██╗
                ██║░░░░░██║░░██║╚█████╔╝░░░██║░░░╚█████╔╝░░░░░░██████╔╝██████╦╝
                ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░░╚════╝░░░░░░░╚═════╝░╚═════╝░
        ";

        private string _menuOptions = @"
    Commands: | -pd - Opens Product Designer Module | -fd - Opens Fields Designer Module
              | -pe - Opens Policy Editor Module    | -notes - Opens Notepad Module 
              | -exnotes - Extracts notes in format | -expd - Extracts Program Design
              | -exfd - Extracts Fields Design      | -newuser - Creates a new user
              | -quit - Quits the program           | -createbp - creates billpay reminder
              | -bpremind - Shows upcoming bills    | -paylog - Opens paycheck logger module
              | -debtlog - Opens Debt Logger Module | -login - Opens form to login w/ user/pass
";
        //fd is field designer, pe is policy editor

        public string Title { get { return _title; } }

        public string cmds { get { return _menuOptions; } }




        public void ShowSpinner(int optionalSecs = 5)
        {
            List<string> animatedStrings = new List<string>{
            "|", "/", "-", "\\", "|", "/", "-", "\\"
            };

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(optionalSecs);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string animations = animatedStrings[i];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(animations);
                Thread.Sleep(100);
                Console.Write("\b \b");

                //Increment
                i++;

                //If i is greater than or equal to the count of list (8), reset i to 0 to
                //restart the images to keep the spinner spinning.
                if (i >= animatedStrings.Count)
                {
                    i = 0;
                }
            }
            Console.ResetColor();
        }



        /// <summary>
        /// Method to retrieve command descriptions that are built in to the command line interface.
        /// </summary>
        /// <param name="cmd">Parameter cmd is the command name after the initial help command.</param>
        /// <returns>Command description as a string.</returns>
        public string Help(string cmd)
        {
            string helper = "";
            switch (cmd)
            {
                case "pd":
                    helper = "pd/Program Designer - A module to design programs which is exported in a specific and easy-to-read way.";
                    return helper;
                case "fd":
                    helper = "Field Designer is a module to design fields for the program that is made in pd(Program Designer).";
                    return helper;
                case "pe":
                    helper = "Policy Editor is a module to edit policies of users stored in a database?";
                    return helper;
                case "notes":
                    helper = "Notes is a notepad that allows you to write easily formatted notes that are named and either quick exported or exported via command.";
                    return helper;
                case "exnotes":
                    helper = "Extract notes: Extracts created notes with a specific file name in the Notes directory.";
                    return helper;
                case "expd":
                    helper = "expd is Extract Program Design, it's meant to extract a program outline in a specific and easy to read way.";
                    return helper;
                case "exfd":
                    helper = "exfd is Extract Field Design, only used to extract fields if the program";
                    return helper;
                case "newuser":
                    helper = "New user is a module to create a new user with a username, password and policy number.";
                    return helper;
                case "quit":
                    helper = "Quits the program";
                    return helper;
                case "paylog":
                    helper = "Pay logger is a module to calculate and/or store paychecks for use in the financial calculator module. Will be stored in a database.";
                    return helper;
                case "debtlog":
                    helper = "Debt logger is a module designed to help motivate the power of paying down debts. Will be stored in a database.";
                    return helper;
                case "createbp":
                    helper = "Creates a billpay reminder with bills that can be re-used. Saved in a database.";
                    return helper;
                case "bpremind":
                    helper = "Bill pay reminder is a quick look at upcoming bills just in case you're forgetful!";
                    return helper;
                case "login":
                    helper = "Allows user to login with previously created / assigned credentials.";
                    return helper;
            }
            return helper;
        }
    }
}
