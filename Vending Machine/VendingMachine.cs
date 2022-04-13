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
        public int total;
        int user;
        public List<Product> products;
        public List<int> moneyPool;


        private int[] moneyDenominations = new int[8] {1,5,10,20,50,100,500,1000};
        public int[] MoneyDenominations { get { return moneyDenominations; } }

        public VendingMachine()
        {
            products = new List<Product>();
            moneyPool = new List<int>();
            total = 0;
            FillWithProducts();
        }


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
            if(total >= product.Price)
            {
                total = UpdateMoneyPool(product);
                Console.WriteLine($"Total amount of money: {total}\n");
                Console.WriteLine(" You have purchased " + product.Info + "\n");

                do
                {
                    Console.WriteLine("\nPress 1 to Examine a product");
                    Console.WriteLine("Press 2 to Use a product");
                    Console.WriteLine("Press 3 to Continue buying");
                    Console.WriteLine("Press 0 to Stop buying and get the change");

                    try
                    {

                        userChoice = int.Parse(Console.ReadLine());


                        switch (userChoice)
                        {
                            case 1:
                                Console.WriteLine($"Total amount of money: {total}\n");
                                product.Examine();
                                hasProduct = true;
                                break;
                            case 2:
                                Console.WriteLine($"Total amount of money: {total}\n");
                                product.Use();
                                hasProduct = true;
                                break;
                            case 3:
                                hasProduct = false;
                                break;
                            case 0:
                                EndTransaction(); 
                                hasProduct = false;
                                hasMoney = false;
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
            else
            {
                Console.WriteLine("You don't have enough money to buy this product.\nInsert more money if you wish to buy this item.");
                hasMoney = false;
                hasProduct = false;
            }


        }
        
        public void Purchase()
        {
            if (total > 0) {

                Console.WriteLine($"Total amount of money: {total}\n");
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
                                Console.WriteLine("Only numbers allowed. \nPlease enter between 1 and 4\n");
                                Console.WriteLine("===========================================================\n");
                                Console.ResetColor();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Only numbers allowed. \nPlease enter between 1 and 4\n");
                        Console.WriteLine("===========================================================\n");
                        Console.ResetColor();
                    };

                }
                while (hasMoney);
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy product's.");
            }
        }

        public int UpdateMoneyPool(Product product)
        {
            if (total > 0)
            {
                int result = total - product.Price;

                return result;
            }
            else
            {
                return 0;
            }
            
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

            if(total == 0)
            {
                Console.WriteLine("No money to return.");
               
            }
            else
            {
                
                Console.WriteLine($"Returned money : {total} kr \n");
                total = Reset(total);
            }
        }

        public int Reset(int amount)
        {
            amount = 0;

            return amount;
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

                    if(total > 0)
                    {
                        moneyPool.Clear();
                        moneyPool.Add(total);

                        
                    }

                    moneyPool.Add(user);
                    total = moneyPool.Sum();


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
