using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Cash
    {
        List<Bill> bills;

        public Cash()
        {
            bills = new List<Bill>();
        }

        public void getReport( )
        {
            //dohvatit broj svih racuna
            //ukupnu vrijednost prodane robe
            //popis svih racuna
        }

        private float getSumBillsValue(List<Bill> bills)
        {
            float value=0;
            foreach(Bill bill in bills)
            {
                value += bill.getSumPrice();
            }
            return value;
        }

        private void printAllBills(List<Bill> bills)
        {
            foreach (Bill bill in bills)
            {
               //isprintaj racun Vrijeme izdavanja - Broj artikala - iznos racuna
            }
        }

    }
}
