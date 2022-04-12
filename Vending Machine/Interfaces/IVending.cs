using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal interface IVending
    {
        void Purchase();
        
        void ShowAll();
        
        void InsertMoney();

        void EndTransaction();

    }
}
