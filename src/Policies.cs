using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Principal;

namespace ProtoDB_Project
{
    internal class Policies
    {
        private string _userName;
        private string _password;
        private int _policy;


        public Policies()
        {
            CreateNewUser();
        }


        public string GetUserName() { return _userName; }
        public int GetPolicy() { return _policy; }

        public string GetPassword() { return _password;}


        private void CreateNewUser()
        {
            Console.Write("UserName: ");
            _userName = Console.ReadLine();
            Console.Write("Password: ");
            _password = Console.ReadLine();
            _policy = 0;
        }


        private string Login(string userName, string password)
        {
            string loginSuccess = $"Welcome back {userName} ({_policy})";
            string loginFailure = $"That password or username combo does not exist or is incorrect, please try again.";
            return _userName;
        }
    }
}
