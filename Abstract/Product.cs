using System;

namespace E_Commerce_System.Abstract
{
    public abstract class Product
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }

        protected Product(int id, string name, decimal basePrice, string category, int stock)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
            Category = category;
            Stock = stock;
        }

        public abstract decimal GetFinalPrice();
        public abstract string GetProductDetails();

        public virtual bool IsAvailable()
        {
            return Stock > 0;
        }

        public override string ToString()
        {
            return $"ID: {Id}, {GetProductDetails()}, Stock: {Stock}";
        }
    }
}