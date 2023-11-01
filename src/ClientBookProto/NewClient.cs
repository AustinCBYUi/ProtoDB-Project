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
    /// Reference to controlling active clients or creating new ones.
    /// </summary>
    internal class NewClient : Client
    {

        public override void CreateNewClient()
        {
            NewClient newCL = new NewClient();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Name: ");
            _name = Console.ReadLine();
            Console.WriteLine("Website: ");
            _website = Console.ReadLine();
            Console.WriteLine("Business Name: ");
            _businessName = Console.ReadLine();
            Console.WriteLine("SVC Completion (MM/DD/YYYY): ");
            string completionDate = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            _phoneNumber = Console.ReadLine();
            Console.WriteLine("Email Address: ");
            _email = Console.ReadLine();
            Console.WriteLine("Additonal Notes?: ");
            _additionalNotes = Console.ReadLine();

            Console.WriteLine("Currently Active Client? Y/N: ");
            string getActive = Console.ReadLine().ToLower();
            _isActiveClient = GetBoolFromResponse(getActive);
            Console.WriteLine("Price of SVC: ");
            _priceOfService = double.Parse(Console.ReadLine());

            CreateDocumentForMongo(newCL);
        }


        private void CreateDocumentForMongo(NewClient client)
        {
            Database addData = new Database();
            var document = new BsonDocument
                {
                  { "name", _name },
                  { "website", _website },
                  { "businessName", _businessName },
                  { "phoneNumber", _phoneNumber },
                  { "email", _email },
                  { "additionalNotes", _additionalNotes },
                  { "isActiveClient", client.GetStringFromBool() },
                  { "priceOfSVC", _priceOfService }
                };

            addData.InsertDocument("Clients", document);
        }
    }
}
