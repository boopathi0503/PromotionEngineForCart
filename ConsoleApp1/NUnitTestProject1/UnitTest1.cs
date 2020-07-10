using NUnit.Framework;

using System;

using System.Collections.Generic;

using System.Linq;

using ConsoleApp1;

namespace NUnitTestProject1
{
    public class Tests

    {

        Product prod1 = new Product() { ID = 1, Name = "A", Price = 50 };

        Product prod2 = new Product() { ID = 2, Name = "B", Price = 30 };

        Product prod3 = new Product() { ID = 3, Name = "C", Price = 20 };

        Product prod4 = new Product() { ID = 4, Name = "D", Price = 15 };

 

        [SetUp]

        public void Setup()

        {

        }

 

        //Scenario A

        [Test]

        public void Test1()

        {

            Program.ProductA_Quantity = 1;

            Program.ProductB_Quantity = 1;

            Program.ProductC_Quantity = 1;

 

            var order = new Order()

            {

                Items = new List<Item>() {

                   new Item() { ProductItem = prod1, Quantity = Program.ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = Program.ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = Program.ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = Program.ProductD_Quantity }

                }

            };

            Program.ApplyPromotions(order);

            Assert.AreEqual(order.Total, 100);

        }

        //Scenario B

        [Test]

        public void Test2()

        {

            Program.ProductA_Quantity = 5;

            Program.ProductB_Quantity = 5;

            Program.ProductC_Quantity = 1;

 

            var order = new Order()

            {

                Items = new List<Item>() {

                    new Item() { ProductItem = prod1, Quantity = Program.ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = Program.ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = Program.ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = Program.ProductD_Quantity }

                }

            };

            Program.ApplyPromotions(order);

            Assert.AreEqual(order.Total, 370);

        }

        //Scenario C

        [Test]

        public void Test3()

        {

            Program.ProductA_Quantity = 3;

            Program.ProductB_Quantity = 5;

            Program.ProductC_Quantity = 1;

            Program.ProductD_Quantity = 1;

 

            var order = new Order()

            {

                Items = new List<Item>() {

                    new Item() { ProductItem = prod1, Quantity = Program.ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = Program.ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = Program.ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = Program.ProductD_Quantity }

                }

            };

            Program.ApplyPromotions(order);

            Assert.AreEqual(order.Total, 280);

        }

        //Scenario D

        [Test]

        public void Test4()

        {

            Program.ProductA_Quantity = 5;

            Program.ProductB_Quantity = 5;

            Program.ProductC_Quantity = 5;

            Program.ProductD_Quantity = 5;

 

            var order = new Order()

            {

                Items = new List<Item>() {

                    new Item() { ProductItem = prod1, Quantity = Program.ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = Program.ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = Program.ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = Program.ProductD_Quantity }

                }

            };

            Program.ApplyPromotions(order);

            Assert.AreEqual(order.Total, 500);

        }

        //Scenario D

        [Test]

        public void Test5()

        {

            Program.ProductA_Quantity = 10;

            Program.ProductB_Quantity = 10;

            Program.ProductC_Quantity = 10;

            Program.ProductD_Quantity = 10;

 

            var order = new Order()

            {

                Items = new List<Item>() {

                    new Item() { ProductItem = prod1, Quantity = Program.ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = Program.ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = Program.ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = Program.ProductD_Quantity }

                }

            };

            Program.ApplyPromotions(order);

            Assert.AreEqual(order.Total, 965);

        }

    }
}