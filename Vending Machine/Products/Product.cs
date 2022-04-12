using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public abstract class Product
    {
        
        private int price = 10;
        private string info = "base product";
        public virtual string Info { get { return info; } set { info = value; } }
        public virtual int Price { get { return price; } set { price = value; } }
        // Examine, to show product price and info
        public virtual void Examine()
        {
            Console.WriteLine($"Product description{info} and product price tag{price}");
        }
        // Use, to show a message to user that he used product
        public virtual void Use()
        {
            Console.WriteLine($"You just used {info}");
        }
    }
}
