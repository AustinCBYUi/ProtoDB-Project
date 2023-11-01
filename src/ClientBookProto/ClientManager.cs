using MongoDB.Bson;
using ProtoDB_Project.src.APIs_Dbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.ClientBookProto
{
    /// <summary>
    /// Manages all data and functionality of managing clients. Essentially references a client book.
    /// </summary>
    internal class ClientManager
    {
        private double _managerVersion = 0.11;
        Menu setcolor = new Menu();

        public void Start()
        {
            bool userQuit = false;

            while (userQuit == false)
            {
                //FORMATTED MENU BELOW
                setcolor.WriteColor(@$"
            --> Client Manager V{_managerVersion} <--
- Prototype reserved for RTInteractive, created by Austin Campbell
- All Rights Reserved -
    
* Please choose an option below *
        1: Create New Client
        2: Create New Lead
        3: View Clients
        4: Quit
"
, ConsoleColor.DarkBlue);
                //FORMATTED MENU ABOVE

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        NewClient createNewCl = new NewClient();
                        createNewCl.CreateNewClient();
                        break;
                    case 2:
                        break;
                    case 3:
                        Database init = new Database();
                        var collection = "Clients";
                        List<BsonDocument> hi = init.LoadAllDocuments<BsonDocument>(collection);
                        foreach (BsonDocument doc in hi)
                        {
                            //This is working
                            //TODO: Expand on DB stuff
                            var name = doc.GetValue("name");
                            var website = doc.GetValue("website");
                            var business = doc.GetValue("businessName");
                            Console.WriteLine($"{name} | {website} | {business}");
                        }

                        break;
                    case 4:
                        userQuit = true;
                        break;
                }
            }
        }
    }
}
