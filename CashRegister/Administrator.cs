using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Administrator : AbstractUser, UserInterface
    {


        public Administrator(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.userRole = UserPermission.role.ADMIN;
        }

        public void defineNewArticle(Article article)
        {
            //spremit novi artikl
        }


        public override void printPossibilites()
        {
            Console.WriteLine("Admin mogucnosti");
        }

        public void redefineBill(Bill oldBill, Bill newBill)
        {
            //redefinirat vrijednost starog artikla
        }

    }
}
