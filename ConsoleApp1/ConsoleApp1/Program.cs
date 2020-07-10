using System;

using System.Collections.Generic;

using System.Linq;

namespace ConsoleApp1
{
    public class Program

    {

        static Product prod1 = new Product() { ID = 1, Name = "A", Price = 50 };

        static Product prod2 = new Product() { ID = 2, Name = "B", Price = 30 };

        static Product prod3 = new Product() { ID = 3, Name = "C", Price = 20 };

        static Product prod4 = new Product() { ID = 4, Name = "D", Price = 15 };

 

        public static int ProductA_Quantity = 0;

        public static int ProductB_Quantity = 0;

        public static int ProductC_Quantity = 0;

        public static int ProductD_Quantity = 0;

        static Order order;

        static void Main(string[] args)

        {

            Console.WriteLine("Enter quantity for Product A");

            string input = Console.ReadLine();

            bool result = int.TryParse(input, out ProductA_Quantity);

            Console.WriteLine("Enter quantity for Product B");

            input = Console.ReadLine();

            result = int.TryParse(input, out ProductB_Quantity);

            Console.WriteLine("Enter quantity for Product C");

            input = Console.ReadLine();

            result = int.TryParse(input, out ProductC_Quantity);

            Console.WriteLine("Enter quantity for Product D");

            input = Console.ReadLine();

            result = int.TryParse(input, out ProductD_Quantity);

            var products = new List<Product>()

            {

                prod1,prod2,prod3,prod4

            };

            order = new Order()

            {

                Items = new List<Item>() {

                    new Item() { ProductItem = prod1, Quantity = ProductA_Quantity },

                    new Item() { ProductItem = prod2, Quantity = ProductB_Quantity },

                    new Item() { ProductItem = prod3, Quantity = ProductC_Quantity },

                    new Item() { ProductItem = prod4, Quantity = ProductD_Quantity }

                }

            };

            ApplyPromotions(order);

            order.Print();

        }

        public static void ApplyPromotions(Order order)

        {

            //Applying promotions

            IPromoService promoService_ProductA = new PromoService_ProductA(ProductA_Quantity);

            order.Total = promoService_ProductA.GetPrice();

            IPromoService promoService_ProductB = new PromoService_ProductB(ProductB_Quantity);

            order.Total += promoService_ProductB.GetPrice();

            IPromoService promoService_ProductCD = new PromoService_ProductCD(ProductC_Quantity, ProductD_Quantity);

            order.Total += promoService_ProductCD.GetPrice();

        }

    }

    public class Product

    {

        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

    }

    public class Order

    {

        public List<Item> Items { get; set; }

        public double Total { get; set; }

        public void Print()

        {

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("******************************" + Environment.NewLine);

            Console.WriteLine("Order Total is " + this.Total);

            Console.WriteLine(Environment.NewLine + "******************************");

            Console.WriteLine("Press any key to exit!!!");

            Console.ReadLine();

        }

    }

    public class Item

    {

        public Product ProductItem { get; set; }

        public double Quantity { get; set; }

    }

 

    //Template pattern is used to apply the promotions for different products and in future, it can be extended with some other promotions

    interface IPromoService

    {

        double GetPrice();

    }

 

    public class PromoService_ProductA : IPromoService

    {

        public int Quantity { get; set; }

        public PromoService_ProductA(int quantity)

        {

            Quantity = quantity >= 0 ? quantity : 0;

        }

        public double GetPrice()

        {

            double result = 0;

            if (Quantity > 0)

                result = 130 * (Quantity / 3) + 50 * (Quantity % 3);

           

            Console.WriteLine(Environment.NewLine + "Product A");

            Console.WriteLine("Quantity " + (Quantity % 3) + " with acutal price is " + 50 * (Quantity % 3));

            Console.WriteLine("Set " + (Quantity / 3) + " with promotion applied is " + 130 * (Quantity / 3));

            return result;

        }

    }

 

    public class PromoService_ProductB : IPromoService

    {

        public int Quantity { get; set; }

        public PromoService_ProductB(int quantity)

        {

            Quantity = quantity >= 0 ? quantity : 0;

        }

        public double GetPrice()

        {

            double result = 0;

            if (Quantity > 0)

                result = 45 * (Quantity / 2) + 30 * (Quantity % 2);

           

            Console.WriteLine(Environment.NewLine + "Product B");

            Console.WriteLine("Quantity " + (Quantity % 2) + " with acutal price is " + 30 * (Quantity % 2));

            Console.WriteLine("Set " + (Quantity / 2) + " with promotion applied is " + 45 * (Quantity / 2));

            return result;

        }

    }

    public class PromoService_ProductCD : IPromoService

    {

        public int Quantity_ProductC { get; set; }

        public int Quantity_ProductD { get; set; }

        public PromoService_ProductCD(int quantity_ProductC, int quantity_ProductD)

        {

            Quantity_ProductC = quantity_ProductC >= 0 ? quantity_ProductC : 0;

            Quantity_ProductD = quantity_ProductD >= 0 ? quantity_ProductD : 0;

        }

        public double GetPrice()

        {

            double result = 0;

            int totalCombo = 0;

            int tempQuantity_ProductC = Quantity_ProductC;

            int tempQuantity_ProductD = Quantity_ProductD;

            int maxIndex = Quantity_ProductC > Quantity_ProductD ? Quantity_ProductC : Quantity_ProductD;

            for (int Index = 0; Index < maxIndex; Index++)

            {

                if (Quantity_ProductC > 0 && Quantity_ProductD > 0)

                {

                    result += 30;

                    totalCombo++;

                }

                else

                    break;

                tempQuantity_ProductC -= 1;

                tempQuantity_ProductD -= 1;

            }

            result += tempQuantity_ProductC * 20 + tempQuantity_ProductD * 15;

            Console.WriteLine(Environment.NewLine + "Product C");

            Console.WriteLine("Quantity " + tempQuantity_ProductC + " with acutal price is " + tempQuantity_ProductC * 20);

            Console.WriteLine(Environment.NewLine + "Product D");

            Console.WriteLine("Quantity " + tempQuantity_ProductD + " with acutal price is " + tempQuantity_ProductD * 15);

            Console.WriteLine(Environment.NewLine + "Product C & D");

            Console.WriteLine("Combo promotion applied for set "+ totalCombo +" is " + totalCombo * 30);

            return result;

        }

    }
}
