using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Snickers : Product
    {

        public override void Examine()
        {
            Console.WriteLine($"{Info} is a bar with chocolate and carmel. Price tag is {Price}.");
        }

        public override void Use()
        {
            Console.WriteLine($"You just eated your {Info}");
        }
    }
}
