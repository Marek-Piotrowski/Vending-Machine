using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class CocaCola : Product
    {
        public override void Examine()
        {
            Console.WriteLine($"{Info} in 0,33l can with price tag {Price} \n");
        }

        public override void Use()
        {
            Console.WriteLine($"You just drinked your {Info} \n");
        }


    }
}
