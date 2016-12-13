using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            Console.WriteLine("");
            Console.WriteLine("Please enter your credentials to log in");
            User user = null;
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

            Console.WriteLine("");
            Console.WriteLine("Welcome " + user.username);

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Choose one of the following possibilites:");
                user.showPossibilites();
                Console.WriteLine("");
                try
                {
                    int action = Int32.Parse(Console.ReadLine());
                    user.makeAction(action);
                }
                catch (NotFiniteNumberException n)
                {
                    Console.WriteLine("Please enter a valid number");
                }
                catch (FormatException f)
                {
                    Console.WriteLine("Please enter a valid number");

                }

                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to choose another possibilites or Q for exit");
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (input.Key == ConsoleKey.Q)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static User getUserForGivenCredentials(String username, String password)
        {

            //buduci da nema baze podaka validacija je ovakva. S bazom bi to bilo drugacije
            if (username.Equals("matej") && password.Equals("matejpass"))
            {
                return new Administrator(username, password);
            }

            if (username.Equals("ivan") && password.Equals("ivanpass"))
            {
                return new Cashier(username, password);
            }
            return null;
        }

        private static void initData()
        {
            File.Create(Util.BILLS_FILE_NAME + ".json").Dispose();
            File.Create(Util.ARTICLES_FILE_NAME + ".json").Dispose();
            File.Create(Util.USER_FILE_NAME + ".json").Dispose();

            initArticles();
            initUsers();
        }

        private static void initArticles()
        {
            ArticlePerItem auto = new ArticlePerItem(200, "Auto", 1250, CroatianPDV.getInstance());
            ArticlePerItem bicikl = new ArticlePerItem(201, "Bicikl", 100, CroatianPDV.getInstance());
            ArticlePerItem stol = new ArticlePerItem(202, "Stol", 300, CroatianPDV.getInstance());
            ArticlePerItem cvijet = new ArticlePerItem(203, "Cvijet", 30, CroatianPDV.getInstance());

            ArticlePerKg limun = new ArticlePerKg(100, "Limun", 10, CroatianPDV.getInstance());
            ArticlePerKg lubenica = new ArticlePerKg(101, "Lubenica", 5, CroatianPDV.getInstance());
            ArticlePerKg jabuka = new ArticlePerKg(102, "Jabuka", 3, CroatianPDV.getInstance());

            List<Article> articles = new List<Article>();
            articles.Add(auto);
            articles.Add(bicikl);
            articles.Add(stol);
            articles.Add(cvijet);
            articles.Add(limun);
            articles.Add(lubenica);
            articles.Add(jabuka);
            Util.saveArticles(articles);
        }

        private static void initUsers()
        {
            Administrator administrator = new Administrator("matej", "matejpass");
            Cashier cashier = new Cashier("ivan", "ivanpass");

            List<User> users = new List<User>();
            users.Add(administrator);
            users.Add(cashier);
            Util.saveUsers(users);
        }

    }
}
