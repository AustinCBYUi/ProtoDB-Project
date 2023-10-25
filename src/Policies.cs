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
    /// <summary>
    /// References the policies each user may have.
    /// </summary>
    internal class Policies
    {
        //Currently not using the policies class
        private string _userName;
        private string _password;
        private int _policy;


        public Policies()
        {
            CreateNewUser();
        }


        /// <summary>
        /// Property to get username
        /// </summary>
        public string GetUserName { get { return _userName; } }

        /// <summary>
        /// Property to get policy user policy
        /// </summary>
        public int GetPolicy { get { return _policy; } }

        /// <summary>
        /// Property to get password? This will not be a wise decision.
        /// </summary>
        public string GetPassword { get { return _password; } }


        /// <summary>
        /// Creates a new user.
        /// </summary>
        private void CreateNewUser()
        {
            Console.Write("UserName: ");
            _userName = Console.ReadLine();
            Console.Write("Password: ");
            _password = Console.ReadLine();
            _policy = 0;
        }


        /// <summary>
        /// Login message, deprecated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string Login(string userName, string password)
        {
            string loginSuccess = $"Welcome back {userName} ({_policy})";
            string loginFailure = $"That password or username combo does not exist or is incorrect, please try again.";
            return _userName;
        }
    }
}
