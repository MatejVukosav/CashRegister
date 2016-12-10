using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    abstract class PDV
    {
        private float value;

        public abstract float getValue();
    }
}
