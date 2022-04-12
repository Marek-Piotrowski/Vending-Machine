using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        bool hasMoney = true;
        bool hasProduct = true;
        int userChoice;
        int user;
        List<Product> products = new List<Product>();
       
       
        public List<int> moneyPool = new List<int>();

        
        private int[] moneyDenominations = new int[8] {1,5,10,20,50,100,500,1000};
        public int[] MoneyDenominations { get { return moneyDenominations; } }

        public VendingMachine()
        {
            FillWithProducts();
        }


        //Enum.IsDefined(typeof(coins), user)
        //enum coins 
        //{
        //    One = 1,
        //    Five = 5,
        //    Ten = 10,
        //    Twenty = 20,
        //    Fifty = 50,
        //    Hundred = 100,
        //    FiveHundred = 500,
        //    Thousand = 1000,
        //};
        //public int[] ConvertListToArray(List<int> list)
        //{
        //    if(list == null)
        //    {
        //        int[] number = { 0 };
        //        return number;
        //    }
        //    else
        //    {
        //        int[] result = new int[list.Count];

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            result[i] = list[i];
        //        }
        //        return result;
        //    }
        //}

        public void FillWithProducts()
        {
            CocaCola cola = new CocaCola() { Info = "Coca cola", Price = 25 };
            Kex kex = new Kex() { Info = "Kex", Price = 35 };
            Snickers snickers = new Snickers() { Info = "Snickers", Price = 20 };
            Ramlosa ramlosa = new Ramlosa() { Info = "Ramlosa", Price = 25 };

            products.Add(cola);
            products.Add(kex);
            products.Add(snickers);
            products.Add(ramlosa);

        }
        public void BuyProduct(Product product)
        {
            Console.WriteLine($"Total amount of money: {UpdateMoneyPool(product)}\n");
            Console.WriteLine(" You have purchased " + product.Info + "\n");

            do
            {
                Console.WriteLine("\nPress 1 to Examine a product");
                Console.WriteLine("Press 2 to Use a product");
                Console.WriteLine("Press 3 to continue buying");
                Console.WriteLine("Press 0 to exit and get the change");

                try
                {

                    userChoice = int.Parse(Console.ReadLine());


                    switch (userChoice)
                    {
                        case 1:
                            product.Examine();
                            hasProduct = true;
                            break;
                        case 2:
                            product.Use();
                            hasProduct = true;
                            break;
                        case 3:
                            hasProduct = false;
                            break;
                        case 0:
                            // exit and get a change 
                            hasProduct = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please choose between 0 or 3\n");
                            Console.WriteLine("===========================================================\n");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only numbers allowed. \nPlease choose between 0 or 3\n");
                    Console.WriteLine("===========================================================\n");
                    Console.ResetColor();
                };


            }
            while (hasProduct);

        }

        
        
        public void Purchase()
        {
            if (moneyPool.Sum() > 0) {

                //Console.WriteLine($"Total amount of money: {moneyPool.Sum()}\n");
                ShowAll();

                do
                {
                    Console.WriteLine("\nPress 1 to buy CocaCola");
                    Console.WriteLine("Press 2 to buy Kex");
                    Console.WriteLine("Press 3 to buy Snickers");
                    Console.WriteLine("Press 4 to buy Ramlosa");
                    Console.WriteLine("Press 0 to return");

                    try
                    {

                        userChoice = int.Parse(Console.ReadLine());


                        switch (userChoice)
                        {
                            case 1:
                                BuyProduct(products[0]);

                                break;
                            case 2:
                                BuyProduct(products[1]);
                                break;
                            case 3:
                                BuyProduct(products[2]);
                                break;
                            case 4:
                                BuyProduct(products[3]);
                                break;
                            case 0:
                                Console.WriteLine("Stop buying");
                                hasMoney = false;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter 1 or 2\n");
                                Console.WriteLine("===========================================================\n");
                                Console.ResetColor();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Only numbers allowed. \nPlease enter 1 or 4\n");
                        Console.WriteLine("===========================================================\n");
                        Console.ResetColor();
                    };

                }
                while (hasMoney);
            }
            else
            {
                Console.WriteLine("You don't have enough moneyto buy product's.");
            }
        }

        public int UpdateMoneyPool(Product product)
        {
            int result = moneyPool.Sum() - product.Price;

            return result;
        }

        public void ShowAll()
        {

            Console.WriteLine("You can buy :\n");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(" "+(i + 1) +": "+ products[i].Info+ "   "+ products[i].Price+" kr");
            }
            
        }
        public void EndTransaction()
        {
            // write method to return existing value from userMoneyInserted
            // returns money from the moneyPool
        }

        public void InsertMoney()
        {
            
            try
            {
                Console.WriteLine("Only 1, 5, 10, 20, 50, 100, 500, 1000 kr allowed.");
                Console.WriteLine("Insert money:");
                user = int.Parse(Console.ReadLine());

                if (moneyDenominations.Contains(user))
                {
                    Console.WriteLine("Coin accepted");
                    moneyPool.Add(user);
                 
                    //for(int i = 0; i < userMoneyInserted.Count; i++)
                    //{
                    //    Console.WriteLine("Monety w zbiorze "+userMoneyInserted[i]);
                    //}
                }
                else
                {
                    Console.WriteLine("Wrong coin.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only 1, 5, 10, 20, 50, 100, 500, 1000 kr allowed.");
                Console.WriteLine("===========================================================\n\n");
                Console.ResetColor();
            }

            


        }



    }
}
