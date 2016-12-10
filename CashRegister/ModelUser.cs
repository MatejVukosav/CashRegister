using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class ModelUser 
    {

        public String username { get; set; }
        public String password { get; set; }
        public Int32 id { get; set; }

        public UserPermission.role role { get; set; }

    }
}
