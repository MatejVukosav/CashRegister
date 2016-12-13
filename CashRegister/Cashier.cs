using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Cashier : User
    {
        public Cashier(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.userRole = UserPermission.role.CASHIER;

        }

        public override void printExtraPossibilites()
        {
            Console.WriteLine("Cashier possibilities");

        }

        public override void makeAction(int action)
        {

            base.makeAction(action);
        }
    }
}
