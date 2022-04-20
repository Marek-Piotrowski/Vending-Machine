using System;

namespace Vending_Machine // Note: actual namespace depends on the project name.

   
    // make unit tests
        // - return value from end transaction method
{
    public class Program
    {
        static void Main(string[] args)
        {

            
            int user;
            bool goodIndex = true;
            
            List<Product> products = new List<Product>();

            VendingMachine machine = new VendingMachine(products);


            Utils.Intro();

            do
            {
                Utils.Menu(machine);

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
                            Utils.Ending();
                            break;
                    }
                }
                catch (NotEnoughMoneyException ex)
                {
                    Console.WriteLine(ex.Message); 
                }
                catch (Exception ex)
                {
                    Utils.Ending();

                };
            }
            while (goodIndex);
            Console.WriteLine("Program closed");
        }

        
    }
}

