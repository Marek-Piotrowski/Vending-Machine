using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Utils
    {
        double userNumber;
        double sum;
        
        
        
        public void Menu(VendingMachine machine)
        {
            Console.WriteLine($"Total amount of money: {machine.moneyPool.Sum()}\n");
            Console.WriteLine("MENU:");
            Console.WriteLine("1 -  Purchase a product");
            Console.WriteLine("2 -  Show all products");
            Console.WriteLine("3 -  Insert money");
            Console.WriteLine("4 -  Return money");
            Console.WriteLine("0 -  Exit ");
            Console.WriteLine("\n\nPlease enter a number between 1 - 4 to choose a function or press 0 to exit ");
        }
        public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome!\nI am Vending Machine with products for you.\n");
            Console.WriteLine("Please choose an option from the menu.");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }
        public void Ending()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Only numbers allowed. \nPlease enter a number between 1 - 4 or press 0 to exit\n\n");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }
        public void CatchWarrning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Only numbers allowed. Use period sign for decimal numbers.");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }

        //public double ConvertToDouble(string userInput)
        //{
        //    if (userInput.Contains(','))
        //    {
        //        string newNum1 = userInput.Replace(',', '.');
        //        userNumber = double.Parse(newNum1);
        //        return userNumber;

        //    }
        //    else
        //    {
        //        userNumber = double.Parse(userInput);
        //        return userNumber;
        //    }
        //}
        
        public double AddUp(double num1, double num2)
        {
            this.sum = num1 + num2;
            return sum;
        }
        
        public double AddUp(double[] num1)
        {
            //only overload purpose
            return sum;
        }
        
        public double Subtract(double num1, double num2)
        {
            this.sum = num1 - num2;
            return sum;
        }
        
        public double Subtract(double[] num1)
        {
            //only overload purpose
            
            return sum;
        }
        
        public double Multiply(double num1, double num2)
        {
            this.sum = num1 * num2;
            return sum;
        }
        
        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Division by zero not allowed\n\n");
            }
            else
            {
                this.sum = num1 / num2;

                return sum;
            }
            
        }
        public void Result(double sum)
        {
            Console.WriteLine("\nEquals: " + sum);
            Console.WriteLine("\n===========================================================\n");
        }


    }
}
