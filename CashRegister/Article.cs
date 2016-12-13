using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CashRegister
{
    public abstract class Article
    {
        public int id { get; set; }
        public abstract int type { get; }
        public String name { get; set; }
        public float price { get; set; }
        public PDV pdv { get; set; }

        public abstract float getValue();
        public abstract float getCalculatedPDV();

        public abstract int getTypeId();

        public abstract void save();
        public abstract void print();

        public abstract string getFileName(int id);

    }
}
