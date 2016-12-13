using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public abstract class PDV
    {
        private float value;
        public abstract int type { get; }

        public abstract float getValue();
        public abstract int getId();
    }
}
