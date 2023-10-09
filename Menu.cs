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
    1) Program Designer | 2) Fields Designer | 3) Policy Editor | 4) Notepad
    5) Export notepad   | 6) Export program  | 7) Export Fields | 8) Create User
    9) Quit Program     | 10) PayLogger      | 11) DebtLogger   | 12) BillPay Reminder
";

        public string GetTitle { get { return _title; } }

        public string GetMenu { get { return _menuOptions; } }
    }
}
