using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.FinancialTools
{
    /// <summary>
    /// Represents a calculator that performs operations to calculate loan payments
    /// </summary>
    internal class PaymentCalculator
    {
        private double _monthlyPayment;
        private double _interest;
        private double _principleBal;
        private string _loanType;

        public PaymentCalculator() { }


        /// <summary>
        /// Starts the Payment Calculator Application
        /// </summary>
        public void Start()
        {
            string loanType = SetLoanType();
            double balance = SetPrinciple();
            double inter = setInterest();
            _monthlyPayment = CalculateMonthlyCCPayment(balance, inter);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your monthly Payment of Interest: ${_monthlyPayment}");
            Console.WriteLine("How much would you like to pay monthly?: ");
            Console.Write("$");
            double plannedPayment = double.Parse(Console.ReadLine());
            CalculateAllPayments(inter, balance, plannedPayment);


        }


        /// <summary>
        /// Sets the loan type which is used to gather additional information depending on loan type.
        /// </summary>
        /// <returns>A string which is used to check the input for the keywords</returns>
        private string SetLoanType()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Loan type(cc, car, mortgage, etc..): ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+ ");
            string userInput = Console.ReadLine();
            Console.ResetColor();
            return userInput;
        }


        /// <summary>
        /// Sets the principle balance of the loan by user input.
        /// </summary>
        /// <returns>A double which is the principle balance</returns>
        private double SetPrinciple()
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Total Balance: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+ ");
            _principleBal = double.Parse(Console.ReadLine());
            Console.ResetColor();
            return _principleBal;
        }


        /// <summary>
        /// Sets the interest rate of the loan by user input.
        /// </summary>
        /// <returns>A double which is the interest rate of the loan.</returns>
        private double setInterest()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Interest Rate: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+ ");
            _interest = double.Parse(Console.ReadLine());
            Console.ResetColor();
            return _interest;
        }


        /// <summary>
        /// Calculates Monthly Credit Card interest payment.
        /// </summary>
        /// <param name="interest">Interest rate as a double</param>
        /// <param name="principle">Principle Balance as a double</param>
        /// <returns>The monthly interest payment.</returns>
        private double CalculateMonthlyCCPayment(double interest, double principle)
        {
            double monthlyInterest = (interest / 12) / 100;
            double monthlyPayment = monthlyInterest * principle;
            return monthlyPayment;
        }


        /// <summary>
        /// Calculates all payments it requires to pay off a credit card given a target payment. Displays as
        /// months - payment - payment toward principle balance, principle balance remaining
        /// </summary>
        /// <param name="interest">Interest rate as a double</param>
        /// <param name="principle">Principle balance as a double</param>
        /// <param name="targetPayment">Target payment as a double.</param>
        private void CalculateAllPayments(double interest, double principle, double targetPayment)
        {
            //principle is 7000
            //103
            double monthlyInterest = CalculateMonthlyCCPayment(interest, principle);
            double paymentTowardPrinciple = targetPayment - monthlyInterest;
            double monthsToPayOff = principle / paymentTowardPrinciple;
            Console.WriteLine("Month - Payment - Payment To Principle - Principle Balance");
            Console.WriteLine($"Monthly Interest: {monthlyInterest} | Principle Payment(interest - payment): {paymentTowardPrinciple}");
            for (double i = 0;  i < monthsToPayOff; i++) 
            {
                principle = principle - paymentTowardPrinciple;
                Console.WriteLine($"Month: {i}   - ${targetPayment} - ${paymentTowardPrinciple} - ${Math.Round(principle, 2)}");
            }
        }


        /// <summary>
        /// Used to define _loanType variable, which is used to define which type of loan the program will be
        /// calculating
        /// </summary>
        /// <param name="input">User input as a string (cc, car, mortgage)</param>
        /// <returns>The _loanType variable as a string</returns>
        private string GetLoanType(string input)
        {
            if (input == "cc")
            {
                _loanType = "cc";
            }
            return _loanType;
        }
    }
}
