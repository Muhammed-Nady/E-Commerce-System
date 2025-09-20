using System;

namespace ECommerceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new ECommerceSystem();

            Console.WriteLine("=== E-Commerce System ===");

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Login as Customer\n2. Login as Admin\n3. View Products\n4. Add to Cart\n5. View Cart\n6. Checkout\n7. View Users\n0. Exit");

                Console.WriteLine("");

                switch (Console.ReadLine())
                {
                    case "1":
                        system.DisplayUsers();
                        Console.Write("Enter Customer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int custId))
                            system.LoginUser(custId);
                        break;
                    case "2":
                        system.DisplayUsers();
                        Console.Write("Enter Admin ID: ");
                        if (int.TryParse(Console.ReadLine(), out int adminId))
                            system.LoginUser(adminId, true);
                        break;
                    case "3":
                        system.DisplayProducts();
                        break;
                    case "4":
                        Console.Write("Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out int pid))
                        {
                            Console.Write("Quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int qty))
                                system.AddToCart(pid, qty);
                        }
                        break;
                    case "5":
                        system.Cart.DisplayCart();
                        break;
                    case "6":
                        system.ProcessPayment();
                        break;
                    case "7":
                        system.DisplayUsers();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}