using System;
using System.Collections.Generic;
using Vending_Machine;
using Xunit;

namespace VendingMachineTests
{
    public class VendingMachineTests
    {
        private List<Product> _products;
        private VendingMachine _machine;
        public VendingMachineTests()
        {
            _products = new List<Product>();
            _machine = new VendingMachine(_products);

        }

        [Fact]
        [Trait("Category", "Money")]
        public void ValidCoinInserted()
        {
            //variables
            int userCoin = 100;

            //Invoke method to test
            var result = _machine.UserInsertsMoney(userCoin);

            //Verify
            Assert.True(result);
        }

        [Fact]
        [Trait("Category", "Money")]
        public void InvalidCoinInserted()
        {

            //variables
            int userCoin = 59;


            //Invoke method to test
            var result = _machine.UserInsertsMoney(userCoin);

            //Verify
            Assert.False(result);
        }

        [Fact]
        [Trait("Category", "Money")]
        public void NoMoneyToReturnTest()
        {

            //variables
            _machine.total = 0;

            //Invoke method to test
            Action result = () => _machine.EndTransaction();

            //Verify
            NoMoneyToReturnException exception = Assert.Throws<NoMoneyToReturnException>(result);
            Assert.Equal("No money to return", exception.Message);
            
        }

        [Fact]
        [Trait("Category", "Money")]
        public void MoneyToReturnExists()
        {

            //variables
            int userCoin1 = 100;

            //Invoke method to test
            int result = _machine.TotalAmountInMachine(userCoin1);

            //Verify
            Assert.Equal(userCoin1, result); 

        }



        [Fact]
        [Trait("Category", "Products")]
        public void VendingMachineHasProducts()
        {

            // variables in constructor

            var result = _machine.ShowAll();

            
            Assert.True(result);
        }

        [Fact]
        [Trait("Category", "Products")]
        public void VendingMachineHasNoProducts()
        {

            // variables
            // in constructor

            //Invoke method to test
            _machine.products.Clear();

            var result = _machine.ShowAll();

            //Verify
            Assert.False(result);
        }

        [Fact]
        [Trait("Category", "Money")]
        public void MachineStartsWithNoMoney()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            int result = _machine.total;

            //Verify
            Assert.Equal(0, result);
        }

        

        [Fact]
        [Trait("Category", "Products")]
        public void HaveCocaCola()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            List<Product> allproducts = _machine.products;

            //Verify
            Assert.Contains(allproducts, item => item.Info == "Coca cola");
        }

        [Fact]
        [Trait("Category", "Products")]
        public void HaveKex()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            List<Product> allproducts = _machine.products;

            //Verify
            Assert.Contains(allproducts, item => item.Info == "Kex");
        }


        [Fact]
        [Trait("Category", "Products")]
        public void HaveSnickers()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            List<Product> allproducts = _machine.products;

            //Verify
            Assert.Contains(allproducts, item => item.Info == "Snickers");
        }

        [Fact]
        [Trait("Category", "Products")]
        public void HaveRamlosa()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            List<Product> allproducts = _machine.products;

            //Verify
            Assert.Contains(allproducts, item => item.Info == "Ramlosa");
        }

        [Fact]
        [Trait("Category","Products")]
        public void ProductDoesNotExist()
        {
            //initialize variables
            // in constructor

            //Invoke method to test
            List<Product> allproducts = _machine.products;

            //Verify
            Assert.DoesNotContain(allproducts, item => item.Info == "Yogi");
        }

        





    }
}