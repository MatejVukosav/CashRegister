﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CashRegister
{
    class ArticlePerItem : Article
    {
        new public float quantity { get; set; } = 1;
        public override int type {
            get {
                return 1;
            }
        }

        public ArticlePerItem() { }

        public ArticlePerItem(int id, String name, float price, PDV pdv)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.pdv = pdv;
        }

        public override float getCalculatedPDV()
        {
            return getValue() * pdv.getValue();
        }

        public override float getValue()
        {
            return quantity * price;
        }

        public override void save()
        {

            List<Article> articles = Util.getArticles();
            if (articles == null)
            {
                articles = new List<Article>();
            }
            articles.Add(this);
            Util.saveArticles(articles);
        }

        public override void print()
        {
            String json = JsonConvert.SerializeObject(this);
            Console.WriteLine(json);
        }

        public override int getTypeId()
        {
            return 1;
        }

        public override string getFileName(int id)
        {
            return "articlePerItem" + id + ".json";
        }
    }
}
