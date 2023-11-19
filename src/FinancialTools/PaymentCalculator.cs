using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.FinancialTools
{
    internal class PaymentCalculator
    {
        private double _monthlyPayment;
        private double _interest;
        private double _principleBal;
        private string _loanType;

        public PaymentCalculator() { }


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


        private double CalculateMonthlyCCPayment(double interest, double principle)
        {
            double monthlyInterest = (interest / 12) / 100;
            double monthlyPayment = monthlyInterest * principle;
            return monthlyPayment;
        }


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
