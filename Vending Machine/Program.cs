using System;

namespace Vending_Machine // Note: actual namespace depends on the project name.

    // requirements
    
    
    
    
    // when user buys the product he can use it right away. Show him the menu, to continue buying, stop buying, consume the product
    // by consume use a product method to show a message, f.ex You have drinked water etc

    //
    // make unit tests
        // - return value from end transaction method
{
    public class Program
    {
        static void Main(string[] args)
        {

            
            int user;
            bool goodIndex = true;
            Utils utils = new Utils();
            VendingMachine machine = new VendingMachine();

            

            utils.Intro();

            do
            {
                utils.Menu(machine);

                try
                {
                    user = int.Parse(Console.ReadLine());

                    switch (user)
                    {
                        case 0:
                            Console.WriteLine("Goodbye.");
                            goodIndex = false;
                            break;
                        case 1:
                            machine.Purchase();
                            break;
                        case 2:
                            machine.ShowAll();
                            break;
                        case 3:
                            machine.InsertMoney();
                            break;
                        case 4:
                            machine.EndTransaction();
                            break;
                        default:
                            utils.Ending();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    utils.Ending();

                };
            }
            while (goodIndex);
            Console.WriteLine("Program closed");
        }
    }
}

