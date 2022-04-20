using System;
using System.Collections.Generic;
using Vending_Machine;
using Xunit;

namespace VendingMachineTests
{
    public class VendingMachineTests
    {
        
        [Fact]
        public void ValidCoinInserted()
        {
            //initialize variables
            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);
            int userCoin = 100;


            //Invoke method to test
            var result = machine.UserInsertsMoney(userCoin);

            //Verify
            Assert.True(result);
        }

        [Fact]
        public void InvalidCoinInserted()
        {
            
            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);
            int userCoin = 59;


            
            var result = machine.UserInsertsMoney(userCoin);

            
            Assert.False(result);
        }

        [Fact]
        public void NoMoneyToReturnTest()
        {

            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);
            

            machine.total = 0;



            Action result = () => machine.EndTransaction();
            //Verify

            NoMoneyToReturnException exception = Assert.Throws<NoMoneyToReturnException>(result);
            Assert.Equal("No money to return", exception.Message);
            
        }

        [Fact]
        public void MoneyToReturnExists()
        {

            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);
            int userCoin1 = 100;


            int result = machine.TotalAmountInMachine(userCoin1);

            //Verify
            Assert.Equal(userCoin1, result); 

        }



        [Fact]
        public void VendingMachineHasProducts()
        {
            
            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);

            
            var result = machine.ShowAll();

            
            Assert.True(result);
        }

        [Fact]
        public void VendingMachineHasNoProducts()
        {
            
            List<Product> products = new List<Product>();
            VendingMachine machine = new VendingMachine(products);
            machine.products.Clear();

            var result = machine.ShowAll();

            Assert.False(result);
        }





    }
}