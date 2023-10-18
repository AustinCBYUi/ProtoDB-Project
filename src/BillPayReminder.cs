using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    //TODO Document all methods and classname ASAP.
    internal class BillPayReminder
    {
        private List<CreateBillPay> _bills = new List<CreateBillPay>();

        Menu setColor = new Menu();

        public void AddBillToList(CreateBillPay billPay)
        {
            _bills.Add(billPay);
        }


        public void ViewBills(BillPayReminder manager)
        {
            int counter = 0;
            foreach (CreateBillPay bill in _bills) 
            {
                counter += 1;
                if (bill.IsPaid())
                {
                    setColor.WriteColor($"{counter} => {bill.FormatBill()}", ConsoleColor.Green);
                }
                //TODO Add DateTime stamp so if a bill is due in the next 5 days, the viewbp will display yellow.
                else if (!bill.IsPaid())
                {
                    setColor.WriteColor($"{counter} => {bill.FormatBill()}", ConsoleColor.Red);
                }
            }
        }



        public void ExportBillReminder()
        {

        }


        public void ImportBillReminder()
        {

        }
    }
}
