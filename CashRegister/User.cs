using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class User
    {

        protected int id = Int32.Parse(System.Guid.NewGuid().ToString());
        public String password { get; set; }
        public String username { get; set; }

        public UserPermission.role userRole { get; set; }
        public Bill createBill()
        {
            return new Bill();
        }

        public void printBill(Bill bill)
        {
            //spremanje svih stvari u sustav
            //printanje na ekran
            bill.printBill();
        }

        public int getId()
        {
            return id;
        }

        public void printPossibilites()
        {
            Console.WriteLine("User possibilities: ");
        }
    }
}
