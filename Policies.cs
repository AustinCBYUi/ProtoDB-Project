using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project
{
    internal class Policies
    {
        private string _userName;
        private string _password;
        private int _policy;


        public Policies(string userName, string password, int policy)
        {
            CreateNewUser(userName, password, policy);
        }


        private void CreateNewUser(string userName, string password, int policy)
        {
            _userName = userName;
            _password = password;
            _policy = policy;
        }

        private string Login(string userName, string password)
        {
            string loginSuccess = $"Welcome back {userName} ({_policy})";
            string loginFailure = $"That password or username combo does not exist or is incorrect, please try again.";
            return _userName;
        }
    }
}
