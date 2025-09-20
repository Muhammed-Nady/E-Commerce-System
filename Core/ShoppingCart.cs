using E_Commerce_System.Abstract;
using E_Commerce_System.Entities;
using E_Commerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_System.Core
{
    public class ShoppingCart
    {
        private List<CartItem> items;
        public Customer Customer { get; set; }

        public ShoppingCart(Customer customer = null)
        {
            items = new List<CartItem>();
            Customer = customer;
        }

        public void AddItem(Product product, int quantity)
        {
            var existingItem = items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }

        public decimal GetTotal()
        {
            decimal total = items.Sum(item => item.TotalPrice);
            return ApplyCustomerDiscount(total);
        }

        private decimal ApplyCustomerDiscount(decimal total)
        {
            if (Customer == null) return total;

            return Customer.Type switch
            {
                CustomerType.Premium => total * 0.95m, // 5% discount
                CustomerType.VIP => total * 0.90m,     // 10% discount
                _ => total
            };
        }

        public void DisplayCart()
        {
            if (!items.Any())
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Console.WriteLine("\n--- Shopping Cart ---");
            foreach (var item in items)
            {
                Console.WriteLine(item);
                if (item.Product is IDiscountable discountable)
                {
                    Console.WriteLine($"  * {discountable.GetDiscountDescription()}");
                }
            }
            Console.WriteLine($"Subtotal: ${items.Sum(i => i.TotalPrice):F2}");
            if (Customer?.Type != CustomerType.Regular)
            {
                Console.WriteLine($"Customer Discount ({Customer?.Type}): Applied");
            }
            Console.WriteLine($"Total: ${GetTotal():F2}");
        }

        public List<CartItem> GetItems() => new List<CartItem>(items);
        public void Clear() => items.Clear();
        public void RemoveItem(int productId) => items.RemoveAll(item => item.Product.Id == productId);
    }
}