using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Bill
    {

        private List<Article> articles;
        private DateTime date;

        public Bill()
        {
            articles = new List<Article>();
            date = new DateTime();
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

        }

        public void addArticle(Article article)
        {
            articles.Add(article);
        }

        public void removeArticle(int id)
        {
            foreach (Article article in articles)
            {
                if (article.getId() == id)
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

    }
}
