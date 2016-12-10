using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            initData();
            run();

        }

        private static void run()
        {
            Console.WriteLine("Welcome to cashier system");
            Console.WriteLine("Please enter your credentials");

            User user;
            while (true)
            {
                Console.WriteLine("Username");
                String username = Console.ReadLine();
                //unos i provjera usernamea
                Console.WriteLine("Password");
                String password = Console.ReadLine();
                //dohvati korisnika
                user = getUserForGivenCredentials(username, password);
                if (user == null)
                {
                    Console.WriteLine("User does not exists");
                }
                else
                {
                    //user postoji, prikazi mogucnosti
                    break;
                }
            }

            Console.WriteLine("Welcome " + user);
            user.printPossibilites();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Odaberite jednu od mogucnosti");
                Console.ReadLine();

            }

        }

        private static User getUserForGivenCredentials(String username, String password)
        {

            ModelUser user = new ModelUser(); ;

            switch (user.role)
            {
                case UserPermission.role.ADMIN:
                    return new Administrator(user.username, user.password);
                case UserPermission.role.CASHIER:
                    return new Cashier(user.username, user.password);
                default:
                    return null;
            }


            Cashier cashier = new Cashier(username, password);
            //vrati usera
            return new Administrator(username, password);

        }

        private static void initData()
        {
            initArticles();
            initUsers();
        }

        private static void initArticles()
        {
            ArticlePerItem auto = new ArticlePerItem("Auto", 1250, CroatianPDV.getInstance());
            ArticlePerItem bicikl = new ArticlePerItem("Bicikl", 100, CroatianPDV.getInstance());
            ArticlePerItem stol = new ArticlePerItem("Stol", 300, CroatianPDV.getInstance());
            ArticlePerItem cvijet = new ArticlePerItem("Cvijet", 30, CroatianPDV.getInstance());

            ArticlPerKg limun = new ArticlPerKg("Limun", 10, CroatianPDV.getInstance());
            ArticlPerKg lubenica = new ArticlPerKg("Lubenica", 5, CroatianPDV.getInstance());
            ArticlPerKg jabuka = new ArticlPerKg("Jabuka", 3, CroatianPDV.getInstance());

            //spremiti u xml
        }

        private static void initUsers()
        {
            Administrator administrator = new Administrator("matej", "matejpass");
            Cashier cashier = new Cashier("ivan", "ivanpass");
        }

    }
}
