using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.ClientBookProto
{
    /// <summary>
    /// Parent class that controls two different types of clients. Current clients and leads.
    /// </summary>
    internal class Client
    {
        protected string _name;
        protected string _website;
        protected string _businessName;
        protected DateTime _completionDate;
        protected DateTime _lastService;
        protected DateTime _nextServiceDate;
        protected string _phoneNumber;
        protected string _email;
        protected string _additionalNotes;
        protected bool _isActiveClient;
        protected double _priceOfService;
        //Lead Clients
        protected bool _isLead;
        protected string _leadBusinessNotes;
        protected string _leadWebsiteNotes;
        protected string _leadSoftwareNotes;

        public Client DeliverClient(string name, string website, string businessName, string completionDate, string phoneNumber, string email, string additionalNotes, string isActiveClient, double priceOfService)
        {
            Client ncl = new Client();
            ncl._name = name;
            ncl._website = website;
            ncl._businessName = businessName;
            //_completionDate = completionDate;
            ncl._phoneNumber = phoneNumber;
            ncl._email = email;
            ncl._additionalNotes = additionalNotes;
            //_isActiveClient = isActiveClient;
            ncl._priceOfService = priceOfService;

            return ncl;
        }




        /// <summary>
        /// Method to create a new client. Not implemented in main class.
        /// </summary>
        public virtual void CreateNewClient() {}


        protected bool GetBoolFromResponse(string response)
        {
            if (response == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected string GetStringFromBool()
        {
            if (_isActiveClient == true)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }



        /// <summary>
        /// Displays ALL the client information formatted.
        /// </summary>
        /// <returns>A formatted string of all the client's information</returns>
        protected virtual string DisplayClientInfo()
        {
            string longInfo = $@"
                               - Client Information -
            POC Name: {_name} | Website: {_website} | Business Name: {_businessName}
                               - Dates of Service -
            Completion: {_completionDate} | Last Service: {_lastService} | Next Service: {_nextServiceDate}
                               - Contact Information -
                    Phone: {_phoneNumber} | Email: {_email}
                               - Active Client? -
                               {_isActiveClient}
                             - Price of OG Service -
                                ${_priceOfService}
                               - Additional Notes -
            Notes: {_additionalNotes}
            ";

            return longInfo;
        }


        /// <summary>
        /// Displays a short amount of client information that is formatted.
        /// Should be used for displaying as a selectedable list.
        /// </summary>
        /// <returns>A short string dispaying some of the client info.</returns>
        protected virtual string DisplayShortClientInfo()
        {
            string shortInfo = $"{_name} | {_businessName} | {_completionDate} | {_nextServiceDate}";

            return shortInfo;
        }
    }
}
