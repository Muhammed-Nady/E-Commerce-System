using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp
{
    public class ECommerceSystem
    {
        private List<Product> products;
        private List<Customer> customers;
        private List<Admin> admins;
        public ShoppingCart Cart { get; private set; }
        public Person CurrentUser { get; private set; }

        public ECommerceSystem()
        {
            products = new List<Product>();
            customers = new List<Customer>();
            admins = new List<Admin>();
            Cart = new ShoppingCart();
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // Physical Products
            products.Add(new PhysicalProduct(1, "Gaming Laptop", 1200m, "Electronics", 5, 2.5, "40x30x3cm"));
            products.Add(new PhysicalProduct(2, "Wireless Mouse", 45m, "Electronics", 25, 0.15, "12x7x4cm"));
            products.Add(new PhysicalProduct(3, "Mechanical Keyboard", 120m, "Electronics", 15, 0.8, "45x15x4cm"));
            products.Add(new PhysicalProduct(4, "Office Desk", 350m, "Furniture", 8, 25.0, "120x60x75cm"));
            products.Add(new PhysicalProduct(5, "Running Shoes", 95m, "Sports", 30, 0.4, "35x25x12cm"));
            products.Add(new PhysicalProduct(6, "Coffee Maker", 85m, "Kitchen", 12, 2.1, "25x35x30cm"));
            products.Add(new PhysicalProduct(7, "Backpack", 65m, "Travel", 20, 0.9, "45x30x20cm"));
            products.Add(new PhysicalProduct(8, "Bluetooth Speaker", 75m, "Electronics", 18, 0.6, "20x8x8cm"));

            // Premium Products
            products.Add(new PremiumProduct(9, "iPhone Pro", 1299m, "Electronics", 10, 0.2, "15x7x1cm", "Apple", 24));
            products.Add(new PremiumProduct(10, "MacBook Pro", 2499m, "Electronics", 6, 2.0, "35x25x2cm", "Apple", 36));
            products.Add(new PremiumProduct(11, "Samsung TV", 899m, "Electronics", 8, 15.5, "140x80x8cm", "Samsung", 24));
            products.Add(new PremiumProduct(12, "Sony Headphones", 299m, "Electronics", 15, 0.3, "20x18x8cm", "Sony", 12));
            products.Add(new PremiumProduct(13, "Nike Air Jordan", 180m, "Sports", 22, 0.5, "35x25x12cm", "Nike", 6));
            products.Add(new PremiumProduct(14, "Rolex Watch", 8999m, "Accessories", 3, 0.1, "5x5x1cm", "Rolex", 60));
            products.Add(new PremiumProduct(15, "Canon Camera", 1599m, "Electronics", 7, 1.2, "15x12x8cm", "Canon", 24));

            // Digital Products
            products.Add(new DigitalProduct(16, "Photoshop License", 239m, "Software", 999, "adobe.com/ps", 3072));
            products.Add(new DigitalProduct(17, "Microsoft Office", 149m, "Software", 999, "microsoft.com/office", 4096));
            products.Add(new DigitalProduct(18, "Spotify Premium Year", 119m, "Entertainment", 999, "spotify.com/premium", 50));
            products.Add(new DigitalProduct(19, "Coding Bootcamp", 2999m, "Education", 999, "bootcamp.com/course", 15360));
            products.Add(new DigitalProduct(20, "Stock Photos Pack", 89m, "Design", 999, "photos.com/download", 2048));
            products.Add(new DigitalProduct(21, "Antivirus Software", 79m, "Software", 999, "antivirus.com/download", 512));
            products.Add(new DigitalProduct(22, "E-Book Collection", 45m, "Books", 999, "ebooks.com/collection", 1024));
            products.Add(new DigitalProduct(23, "Game Bundle", 199m, "Entertainment", 999, "games.com/bundle", 25600));
            products.Add(new DigitalProduct(24, "Online Language Course", 299m, "Education", 999, "language.com/course", 8192));
            products.Add(new DigitalProduct(25, "Design Templates", 69m, "Design", 999, "templates.com/pack", 512));

            // Customers - Regular
            customers.Add(new Customer(1, "John Doe", "john.doe@gmail.com", CustomerType.Regular));
            customers.Add(new Customer(2, "Sarah Connor", "sarah.connor@yahoo.com", CustomerType.Regular));
            customers.Add(new Customer(3, "Mike Johnson", "mike.j@outlook.com", CustomerType.Regular));
            customers.Add(new Customer(4, "Lisa Anderson", "lisa.anderson@gmail.com", CustomerType.Regular));
            customers.Add(new Customer(5, "Tom Wilson", "tom.wilson@hotmail.com", CustomerType.Regular));
            customers.Add(new Customer(6, "Emma Davis", "emma.davis@gmail.com", CustomerType.Regular));

            // Customers - Premium
            customers.Add(new Customer(7, "Jane Smith", "jane.smith@gmail.com", CustomerType.Premium));
            customers.Add(new Customer(8, "David Brown", "david.brown@yahoo.com", CustomerType.Premium));
            customers.Add(new Customer(9, "Rachel Green", "rachel.green@outlook.com", CustomerType.Premium));
            customers.Add(new Customer(10, "Kevin Miller", "kevin.miller@gmail.com", CustomerType.Premium));
            customers.Add(new Customer(11, "Amanda Taylor", "amanda.taylor@hotmail.com", CustomerType.Premium));

            // Customers - VIP
            customers.Add(new Customer(12, "Bob Wilson", "bob.wilson@gmail.com", CustomerType.VIP));
            customers.Add(new Customer(13, "Victoria Adams", "victoria.adams@yahoo.com", CustomerType.VIP));
            customers.Add(new Customer(14, "Alexander King", "alex.king@outlook.com", CustomerType.VIP));
            customers.Add(new Customer(15, "Sophia Martinez", "sophia.martinez@gmail.com", CustomerType.VIP));

            // Admins
            admins.Add(new Admin(1, "Admin Manager", "admin.manager@company.com", "Management"));
            admins.Add(new Admin(2, "Inventory Admin", "inventory.admin@company.com", "Inventory"));
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n--- Available Products ---");
            foreach (var product in products.Where(p => p.IsAvailable()))
            {
                Console.WriteLine(product);
                if (product is IDiscountable discountable)
                {
                    Console.WriteLine($"  * {discountable.GetDiscountDescription()}");
                }
            }
        }

        public void DisplayUsers()
        {
            Console.WriteLine("\n--- Users ---");
            Console.WriteLine("Customers:");
            customers.ForEach(c => Console.WriteLine($"ID: {c.Id} - {c.GetContactInfo()}"));
            Console.WriteLine("Admins:");
            admins.ForEach(a => Console.WriteLine($"ID: {a.Id} - {a.GetContactInfo()}"));
        }

        public void LoginUser(int userId, bool isAdmin = false)
        {
            if (isAdmin)
            {
                CurrentUser = admins.FirstOrDefault(a => a.Id == userId);
            }
            else
            {
                CurrentUser = customers.FirstOrDefault(c => c.Id == userId);
                if (CurrentUser != null)
                {
                    Cart = new ShoppingCart((Customer)CurrentUser);
                }
            }

            if (CurrentUser != null)
            {
                Console.WriteLine($"Welcome, {CurrentUser.GetContactInfo()}!");
                Console.WriteLine($"Role: {CurrentUser.GetRole()}");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        public bool AddToCart(int productId, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);

            if (product == null || !product.IsAvailable() || product.Stock < quantity)
            {
                Console.WriteLine("Product unavailable or insufficient stock!");
                return false;
            }

            Cart.AddItem(product, quantity);
            Console.WriteLine($"Added {quantity} {product.Name}(s) to cart.");
            return true;
        }

        public void ProcessPayment()
        {
            if (CurrentUser is not Customer customer)
            {
                Console.WriteLine("Only customers can place orders!");
                return;
            }

            var items = Cart.GetItems();
            if (!items.Any())
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            // Update stock
            foreach (var item in items)
            {
                item.Product.Stock -= item.Quantity;
            }

            Console.WriteLine($"\n=== ORDER CONFIRMATION ===");
            Console.WriteLine($"Customer: {customer.GetContactInfo()}");
            Console.WriteLine($"Items: {items.Count}");
            Console.WriteLine($"Total: ${Cart.GetTotal():F2}");
            Console.WriteLine("Order placed successfully!");

            Cart.Clear();
        }
    }
}