using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
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

        
    }
}
