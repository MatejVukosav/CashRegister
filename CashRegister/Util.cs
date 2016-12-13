using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CashRegister
{
    class Util
    {

        private static int globalCounter = 50;

        public static int getGlobalIdCounter()
        {
            globalCounter++;
            return globalCounter;
        }

        public static string ARTICLES_FILE_NAME = "articles";
        public static string BILLS_FILE_NAME = "bills";
        public static string USER_FILE_NAME = "users";

        public static List<Article> getArticles()
        {

            List<Article> articles = null;
            using (StreamReader reader = File.OpenText(ARTICLES_FILE_NAME + ".json"))
            {
                string json = reader.ReadToEnd();
                articles = JsonConvert.DeserializeObject<List<Article>>(json, new ArticleCreationConverter(), new PDVCreationConverter());
            }
            if (articles == null)
            {
                articles = new List<Article>();
            }

            return articles;
        }

        public static List<Bill> getBills()
        {
            List<Bill> bills = null;
            using (StreamReader reader = File.OpenText(BILLS_FILE_NAME + ".json"))
            {
                string json = reader.ReadToEnd();
                bills = JsonConvert.DeserializeObject<List<Bill>>(json, new ArticleCreationConverter(), new PDVCreationConverter());
            }
            if (bills == null)
            {
                bills = new List<Bill>();
            }
            return bills;
        }

        public static void saveBills(List<Bill> bills)
        {
            string json = JsonConvert.SerializeObject(bills);
            //write string to file
            File.WriteAllText(BILLS_FILE_NAME + ".json", json);
        }

        public static void saveArticles(List<Article> articles)
        {
            string json = JsonConvert.SerializeObject(articles);
            //write string to file
            File.WriteAllText(ARTICLES_FILE_NAME + ".json", json);
        }
        public static void saveUsers(List<User> users)
        {

            string json = JsonConvert.SerializeObject(users);
            //write string to file
            File.WriteAllText(USER_FILE_NAME + ".json", json);

        }
        public static List<User> getUsers()
        {
            List<User> users = null;
            using (StreamReader file = File.OpenText(USER_FILE_NAME + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                users = (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }



            if (users == null)
            {
                users = new List<User>();
            }

            return users;
        }

        public static Bill getBillById(int id)
        {
            List<Bill> bills = getBills();
            foreach (Bill bill in bills)
            {
                if (bill.id == id)
                {
                    return bill;
                }
            }
            return null;
        }
        public static Article getArticleById(int id)
        {
            List<Article> articles = getArticles();
            foreach (Article article in articles)
            {
                if (article.id == id)
                {
                    return article;
                }
            }
            return null;
        }

        public static void printDailyBillReport()
        {
            List<Bill> bills = getBills();
            Console.WriteLine("Today was " + bills.Count() + " bills");
            float sum = 0;
            foreach (Bill b in bills)
            {
                sum += b.getSumPrice();
            }
            Console.WriteLine("Today traffic was " + sum + " $$");

            foreach (Bill b in bills)
            {
                Console.WriteLine("Bill:" + b.id + " " + b.getDate() + " " + b.getArticlesCount() + " " + b.getSumPrice() + "$");
            }

        }

        public static void printDailyArticlesReport()
        {
            List<Bill> bills = getBills();
            if (bills.Count() == 0)
            {
                Console.WriteLine("There was no bills today");
            }
            else
            {
                Dictionary<int, int> dailyArticles = new Dictionary<int, int>();

                foreach (Bill b in bills)
                {
                    foreach (Article a in b.articles)
                    {
                        int value;
                        bool hasValue = dailyArticles.TryGetValue(a.id, out value);
                        if (hasValue)
                        {
                            dailyArticles[a.id] = value + 1;
                        }
                        else
                        {
                            dailyArticles.Add(a.id, 1);
                        }

                    }
                }
                if (dailyArticles.Count() == 0)
                {
                    Console.WriteLine("There is no articles in daily bills");
                }
                else
                {
                    dailyArticles = (from entry in dailyArticles orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                    foreach (KeyValuePair<int, int> item in dailyArticles)
                    {
                        //  string articleString = JsonConvert.SerializeObject(getArticleById(item.Key));
                        Article article = getArticleById(item.Key);
                        Console.WriteLine(item.Value + " " + article.name);
                    }
                }
            }
        }

        public static void printUsers()
        {
            List<User> users = getUsers();
            foreach (User u in users)
            {
                Console.WriteLine(u.username + " " + u.userRole);
            }
        }

    }


}
