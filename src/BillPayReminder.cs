using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Reference to a list of Bills to pay.
    /// </summary>
    internal class BillPayReminder
    {
        //TODO: Stop this from duplicating if you create new entries?
        private List<CreateBillPay> _bills = new List<CreateBillPay>();

        Menu setColor = new Menu();


        /// <summary>
        /// Used to add a bill to the list.
        /// </summary>
        /// <param name="billPay">Individual bill</param>
        public void AddBillToList(CreateBillPay billPay)
        {
            _bills.Add(billPay);
        }


        /// <summary>
        /// Used to view all bills in the current list, displays bills as colored coded.
        /// </summary>
        /// <param name="manager">Main manager to instantiate the list.</param>
        public void ViewBills(BillPayReminder manager)
        {
            int counter = 0;
            foreach (CreateBillPay bill in _bills) 
            {
                string getDueDateCondition = bill.IsBillDue();
                counter += 1;
                if (bill.IsPaid())
                {
                    setColor.WriteColor($"{counter} => {bill.FormatBill()}", ConsoleColor.Green);
                }
                else if (!bill.IsPaid() && getDueDateCondition != "SOON")
                {
                    setColor.WriteColor($"{counter} => {bill.FormatBill()}", ConsoleColor.Red);
                }
                else if (getDueDateCondition == "SOON")
                {
                    setColor.WriteColor($"{counter} => {bill.FormatBill()}", ConsoleColor.Yellow);
                }
            }
        }


        /// <summary>
        /// Exports the bills to a file inside data/debug/net6.0 as billpayreminder.txt. Specially formatted.
        /// </summary>
        /// <param name="manager">Main BillPayReminder as instance</param>
        public void ExportBillReminder(BillPayReminder manager)
        {
            string test = Directory.GetCurrentDirectory();
            string fileName = $"{test}/BillPayReminders.txt";

            using (StreamWriter write = new StreamWriter(fileName))
            {
                foreach (CreateBillPay bill in _bills)
                {
                    write.WriteLine($"{bill.FormatExport()}");
                }
            }
        }


        /// <summary>
        /// Imports the bills from a file inside data/debug/net6.0 as billpayreminder.txt. Re-creates list.
        /// </summary>
        /// <param name="manager">Main bill pay reminder as instance.</param>
        public void ImportBillReminder(BillPayReminder manager)
        {
            string getDir = Directory.GetCurrentDirectory();
            string loadfile = $"{getDir}/BillPayReminders.txt";
            File.Create(loadfile).Close();
            string[] lines = File.ReadAllLines(loadfile);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                string billName = parts[0];
                string billDate = parts[1];
                double paymentAmount = double.Parse(parts[2]);
                string billPaid = parts[3];
                CreateBillPay newBill = new CreateBillPay(billName, billDate, paymentAmount, billPaid);
                manager.AddBillToList(newBill);
            }
        }
    }
}
