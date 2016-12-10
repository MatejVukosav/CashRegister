using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class ArticlPerKg : Article
    {
        public float ammount { get; set; }

        public ArticlPerKg(String name, float price, PDV pdv)
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
            return ammount * price;
        }

    }
}
