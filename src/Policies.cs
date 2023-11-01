using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Principal;
using System.Security;
using static System.Net.Http.HttpMessageInvoker;
using System.Xml.Linq;

namespace ProtoDB_Project
{
    /// <summary>
    /// References the policies each user may have.
    /// </summary>
    internal class Policies
    {
        //Currently not using the policies class
        protected string _userName { get; set; }
        protected string _password { get; set; }
        protected int _policy;

        static readonly HttpClient client = new HttpClient();

        public Policies(string dec)
        {
            if (dec == "run-main")
            {
                Main();
            }
        }


        public Policies() { }



        /// <summary>
        /// Property to get password? This will not be a wise decision.
        /// </summary>
        public string password { get { return _password; } }

        /// <summary>
        /// Property to get policy user policy
        /// </summary>
        public int policy { get { return _policy; } }



        static async Task Main()
        {
            Policies getUser = new Policies();
            string link = @"https://raw.githubusercontent.com/AustinCBYUi/APIsAndStuff/main/administrator";
            try
            {
                using HttpResponseMessage response = await client.GetAsync(link);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                string[] parts = responseBody.Split("|");

                //Works
                //Todo: Create a encryption / decryption for public webpage.
                //Create a login to access the application.
                foreach (string part in parts)
                {
                    getUser._userName = parts[0];
                    getUser._password = parts[1];
                    getUser._policy = int.Parse(parts[2]);
                    Console.WriteLine(getUser._userName + " " + getUser._password);
                }
            }
            catch (HttpRequestException e) 
            {
                Console.WriteLine("\nException Discovered");
                Console.WriteLine("Message :{0}", e.Message);
            }
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
