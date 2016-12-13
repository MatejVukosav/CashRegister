using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class CroatianPDV : PDV
    {

        private static CroatianPDV instance;
        private CroatianPDV()
        {

        }

        public override int type {
            get {
                return 1;
            }
        }

        public static CroatianPDV getInstance()
        {
            if (instance == null)
            {
                instance = new CroatianPDV();

            }
            return instance;
        }

        public override int getId()
        {
            return 1;
        }

        public override float getValue()
        {
            return 0.25f;
        }
    }
}
