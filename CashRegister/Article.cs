using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    abstract class Article
    {
        protected int id = Int32.Parse(System.Guid.NewGuid().ToString());
        public String name { get; set; }
        public float price { get; set; }
        public PDV pdv { get; set; }

        public int getId()
        {
            return id;
        }

        public abstract float getValue();
        public abstract float getCalculatedPDV();
    }
}
