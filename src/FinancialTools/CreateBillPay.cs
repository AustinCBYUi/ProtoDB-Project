using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.FinancialTools
{
    /// <summary>
    /// References an individual bill. Accepts bill name, due date, payment amount and is bill paid or not.
    /// </summary>
    internal class CreateBillPay
    {
        private string _billName;
        private string _dateDue;
        private double _paymentAmount;
        private bool _isPaid;



        /// <summary>
        /// Creates a new bill with parameters specified, then throws a quick console check with user input
        /// to see if bill has been paid yet or not.
        /// </summary>
        /// <param name="billName">Name of the bill</param>
        /// <param name="dateDue">Due date</param>
        /// <param name="paymentAmount">Payment amount</param>
        /// <param name="paidOrNot">String to figure if bill has been paid or not.</param>
        public CreateBillPay(string billName, string dateDue, double paymentAmount, string paidOrNot)
        {
            _billName = billName;
            _dateDue = dateDue; //Might need to convert this to DateTime?
            _paymentAmount = paymentAmount;
            if (paidOrNot == "yes" || paidOrNot == "y")
            {
                _isPaid = true;
            }
            else if (paidOrNot == "no" || paidOrNot == "n")
            {
                _isPaid = false;
            }
        }


        /// <summary>
        /// Asks the user if this bill was paid by them thus far or not.
        /// </summary>
        /// <returns>True of false if bill has been paid.</returns>
        public bool IsPaid()
        {
            return _isPaid;
        }



        /// <summary>
        /// Converts _isPaid boolean to a string where False = No, and True = Yes.
        /// </summary>
        /// <returns>Yes or No as a string.</returns>
        private string IsPaidConvert()
        {
            string replace = "";
            if (_isPaid)
            {
                replace = "Yes";
            }
            else
            {
                replace = "No";
            }
            return replace;
        }


        /// <summary>
        /// Formats the bill for BillPayReminder main class to print to user.
        /// </summary>
        /// <returns>Formatted string for printing the bill.</returns>
        public string FormatBill()
        {
            string newStr = $"Bill: {_billName} - Due on: {_dateDue} ---- Amount: ${_paymentAmount} | Paid?: {IsPaidConvert()}";
            return newStr;
        }


        /// <summary>
        /// Formats the bill for BillPayReminder main class to import/export to/from BillPaidReminders.txt file.
        /// </summary>
        /// <returns>Formatted string for importing/exporting the bill.</returns>
        public string FormatExport()
        {
            string newStr = $"{_billName}|{_dateDue}|{_paymentAmount}|{IsPaidConvert()}";
            return newStr;
        }


        /// <summary>
        /// Function to check if the bill is due soon, not soon or past due.
        /// </summary>
        /// <returns>String that is represented as NOTSOON, SOON or PASTDUE.</returns>
        public string IsBillDue()
        {
            //NOTSOON anytime
            //SOON <= 5 days from duedate
            //PASTDUE > DueDate
            //Will be represented as NOTSOON, SOON, and PASTDUE
            string isDue = "";
            DateTime getNow = DateTime.Today;

            string now = getNow.ToString("d");
            //THIS IS THE BILLS DUE DATE
            DateTime dueDate = DateTime.Parse(_dateDue);
            //Takes the bills due date and adds 5 days to it.
            DateTime projectionDueDate = dueDate.AddDays(-5);

            if (getNow > dueDate)
            {
                isDue = "PASTDUE";
            }
            //If today (10/22/2023) is equal to the projectionDueDate (set at 10/27/2023 so it would be 10/22/2023)
            //OR if today (10/22/2023) is greater than or equal to projectionDueDate (10/22/2023)
            else if (getNow == projectionDueDate || getNow >= projectionDueDate)
            {
                isDue = "SOON";
            }
            else if (getNow < dueDate)
            {
                isDue = "NOTSOON";
            }
            return isDue;
        }
    }
}
