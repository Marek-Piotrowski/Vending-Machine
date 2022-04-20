using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public interface IVending
    {
        void Purchase();
        
        bool ShowAll();
        
        void InsertMoney();

        int EndTransaction();

    }
}
