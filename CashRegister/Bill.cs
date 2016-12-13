using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CashRegister
{
    class Bill
    {
        public int id;
        public List<Article> articles;
        public DateTime date;

        public Bill()
        {
            id = Util.getGlobalIdCounter();
            articles = new List<Article>();
            date = DateTime.Now;
        }

        public float getSumPrice()
        {
            float value = 0;
            foreach (Article article in articles)
            {
                value += article.getValue();
            }
            return value;
        }

        public DateTime getDate()
        {
            return date;
        }

        public float getCalculatedPDV()
        {
            float value = 0;
            foreach (Article article in articles)
            {
                value += article.getValue();
            }
            return value;
        }

        public void printBill()
        {
            String json = JsonConvert.SerializeObject(this);
            Console.WriteLine(json);
        }

        public void addArticle(Article article)
        {
            articles.Add(article);
        }

        public void removeArticle(int id)
        {
            foreach (Article article in articles)
            {
                if (article.id == id)
                {
                    articles.Remove(article);
                    break;
                }
            }

        }

        public int getArticlesCount()
        {
            return articles.Count();
        }
        public void save()
        {
            List<Bill> bills = Util.getBills();
            if (bills == null)
            {
                bills = new List<Bill>();
            }
            bills.Add(this);

            Util.saveBills(bills);
        }

        public static string getFileName(int id)
        {
            return @"c:\bill" + id + ".json";
        }

    }
}
