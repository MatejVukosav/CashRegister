using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class ArticlePerItem : Article
    {
        public float quantity { get; set; }

        public ArticlePerItem(String name, float price, PDV pdv)
        {
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
    }
}
