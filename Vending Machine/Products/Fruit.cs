using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Fruit : Product
    {

        public override void Examine()
        {
            Console.WriteLine($"This is {Info}. Price tag is {Price}.\n");
        }

        public override void Use()
        {
            Console.WriteLine($"You just eated your {Info} \n");
        }
    }
}
