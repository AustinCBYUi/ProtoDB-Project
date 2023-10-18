using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    internal class BillPayReminder
    {
        private List<CreateBillPay> _bills = new List<CreateBillPay>();

        public BillPayReminder()
        {
        }

        Menu setColor = new Menu();

        public void AddBillToList(CreateBillPay billPay)
        {
            _bills.Add(billPay);
        }


        public void ViewBills(BillPayReminder manager)
        {
            Console.WriteLine(manager._bills);
            int counter = 0;
            foreach (CreateBillPay bill in manager._bills) 
            {
                counter += 1;
                Console.WriteLine($"{counter} - {bill}");
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
