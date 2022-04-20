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
        
        public List<int> moneyPool;
        public List<Product> products;

        private int[] moneyDenominations;
        public int[] MoneyDenominations { get { return moneyDenominations; } }

        public VendingMachine(List<Product> emptyProducts)
        {
            
            products = FillWithProducts(emptyProducts);
            moneyPool = new List<int>();
            moneyDenominations = new int[8] { 1, 5, 10, 20, 50, 100, 500, 1000 };
            total = 0;
            
        }


        public List<Product> FillWithProducts(List<Product> machineShelfs)
        {
            CocaCola cola = new CocaCola() { Info = "Coca cola", Price = 25 };
            Kex kex = new Kex() { Info = "Kex", Price = 35 };
            Snickers snickers = new Snickers() { Info = "Snickers", Price = 20 };
            Ramlosa ramlosa = new Ramlosa() { Info = "Ramlosa", Price = 25 };

            machineShelfs.Add(cola);
            machineShelfs.Add(kex);
            machineShelfs.Add(snickers);
            machineShelfs.Add(ramlosa);

            return machineShelfs;

        }
        public void BuyProduct(Product product)
        {
            if(total >= product.Price)
            {
                total = UpdateTotalValue(product);
                Console.WriteLine($"Total amount of money: {total} kr \n");
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
                                Console.WriteLine($"Total amount of money: {total} kr \n");
                                product.Examine();
                                hasProduct = true;
                                break;
                            case 2:
                                Console.WriteLine($"Total amount of money: {total} kr \n");
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
                        Utils.WrongInput();
                    };


                }
                while (hasProduct);
            }
            else
            {
                hasMoney = false;
                hasProduct = false;
                throw new NotEnoughMoneyException("You don't have enough money to buy this product.\nInsert more money if you wish to buy this item.");
            }


        }
        
        public void Purchase()
        {
            if (total > 0) {

                Console.WriteLine($"Total amount of money: {total} kr \n");
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
                                Utils.Ending();
                                break;
                        }
                    }
                    catch(NotEnoughMoneyException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Utils.WrongInput();
                    };

                }
                while (hasMoney);
            }
            else
            {
                throw new NotEnoughMoneyException("You don't have enough money to buy product's.");
            }
        }

        public int UpdateTotalValue(Product product)
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

        public bool ShowAll()
        {
            if(products.Count > 0)
            {
                Console.WriteLine("Available products :\n");

                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(" " + (i + 1) + ": " + products[i].Info + "   " + products[i].Price + " kr");
                }
                return true;
            }
            else
            {
                
                Console.WriteLine("Machine has no products.");
                return false;
            }
            
            
        }
        public int EndTransaction()
        {

            if(total == 0)
            {
                Console.WriteLine("No money to return.\n");
                //total = 0;
                //return total;
                throw new NoMoneyToReturnException("No money to return");
                
               
            }
            else
            {
                Console.WriteLine($"Returned money : {total} kr \n");
                moneyPool.Clear();
                total = Reset(total);
                return total;
            }
        }

        public int Reset(int amount)
        {
            amount = 0;

            return amount;
        }

        public bool UserInsertsMoney(int userCoin)
        {
                if (moneyDenominations.Contains(userCoin))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public int TotalAmountInMachine(int userCoin)
        {
            if(total > 0)
            {
                moneyPool.Clear();
                moneyPool.Add(total);
                
            }
            
            moneyPool.Add(userCoin);
            total = moneyPool.Sum();

            return total;
            
        }



        public void InsertMoney()
        {
            
            try
            {
                Console.WriteLine("Only 1, 5, 10, 20, 50, 100, 500, 1000 kr allowed.");
                Console.WriteLine("Insert money:");
                user = int.Parse(Console.ReadLine());



                if (UserInsertsMoney(user))
                {
                    Console.WriteLine("Coin accepted\n");

                    total = TotalAmountInMachine(user);

                }
                else
                {
                    throw new WrongCoinException("Invalid coin.\n");
                    
                }
            }
            catch (WrongCoinException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

               Utils.WrongInput();
                
            }

            


        }




    }
}
