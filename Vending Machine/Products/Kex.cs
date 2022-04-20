using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Kex : Product
    {

        public override void Examine()
        {
            Console.WriteLine($"{Info} is a waffle with chocolate. Most popular in Sweden. Price tag is {Price} \n");
        }

        public override void Use()
        {
            Console.WriteLine($"You just eated your {Info}.\n");
        }
    }
}
