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
        private static string EnteredVal = "";
        protected int _policy;
        private bool _isLoggedIn { get; set; }

        static readonly HttpClient client = new HttpClient();


        public Policies() { }



        /// <summary>
        /// Property to get password? This will not be a wise decision.
        /// </summary>
        public string password { get { return _password; } }

        /// <summary>
        /// Property to get policy user policy
        /// </summary>
        public int policy { get { return _policy; } }


        public void RunMain(Policies user)
        {
            Main(user);
        }


        static async Task Main(Policies getUser)
        {
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
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Discovered");
                Console.WriteLine("Message :{0}", e.Message);
            }
        }


        /// <summary>
        /// User login functionality.
        /// </summary>
        /// <param name="user">Requires a user's information to login.</param>
        /// <returns>true or false for is user logged in.</returns>
        public bool Login(Policies user) //May need to add a parameter to get a user in the future if I have multiple logins / users.
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Username: ");
            string enterUsername = Console.ReadLine();
            if (enterUsername == _userName)
            {
                Console.WriteLine("Password: ");
                HidePassword();
                if (EnteredVal == _password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\nWelcome back {_userName}! (Level: {_policy} policy)\n\n");
                    _isLoggedIn = true;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-LOGIN FAILURE-: That username or password is incorrect, please try again!");
                    _isLoggedIn = false;
                    Console.ResetColor();
                    Login(user);
                }
            }
            else if (enterUsername != _userName)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-LOGIN FAILURE-: That username or password is incorrect, please try again!");
                _isLoggedIn = false;
                Console.ResetColor();
                Login(user);
            }
            return _isLoggedIn;
        }


        public bool Logout(Policies user)
        {
            return _isLoggedIn = false;
        }



        /// <summary>
        /// Hides password text in the form as a astericks.
        /// </summary>
        private void HidePassword()
        {
            try
            {
                EnteredVal = "";
                do
                {
                    ConsoleKeyInfo keyEntered = Console.ReadKey(true);
                    //Backspace shouldn't work here
                    if (keyEntered.Key != ConsoleKey.Backspace && keyEntered.Key != ConsoleKey.Enter)
                    {
                        EnteredVal += keyEntered.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyEntered.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                        {
                            EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (keyEntered.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(EnteredVal))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Empty Value Not Accepted.");
                                HidePassword();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }
    }
}
