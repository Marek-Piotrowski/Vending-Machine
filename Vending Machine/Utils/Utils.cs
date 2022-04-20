using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Utils
    {
        public static void Menu(VendingMachine machine)
        {
            Console.WriteLine($"Total amount of money: {machine.total}\n");
            Console.WriteLine("MENU:");
            Console.WriteLine("1 -  Purchase a product");
            Console.WriteLine("2 -  Show all products");
            Console.WriteLine("3 -  Insert money");
            Console.WriteLine("4 -  Return money");
            Console.WriteLine("0 -  Exit ");
            Console.WriteLine("\n\nPlease enter a number between 1 - 4 to choose a function or press 0 to exit ");
        }
        public static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome!\nI am Vending Machine with products for you.\n");
            Console.WriteLine("Please choose an option from the menu.");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }
        public static void Ending()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Only numbers allowed. \nPlease enter a number between 1 - 4 or press 0 to exit\n\n");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }
        public static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Only numbers allowed.\n");
            Console.WriteLine("===========================================================\n\n");
            Console.ResetColor();
        }

















    }
}
