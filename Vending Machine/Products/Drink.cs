using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Drink : Product
    {
        public override void Examine()
        {
            Console.WriteLine($"This is {Info}. Price tag is {Price} \n");
        }

        public override void Use()
        {
            Console.WriteLine($"You just drinked your {Info} \n");
        }


    }
}
