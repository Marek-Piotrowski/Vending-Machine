using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Ramlosa : Product
    {
        

        public override void Examine()
        {
            Console.WriteLine($"{Info} is a water with taste of citron. Price tag is {Price}. \n");
        }

        public override void Use()
        {
            Console.WriteLine($"You just drinked your {Info}. \n");
        }
    }
}
