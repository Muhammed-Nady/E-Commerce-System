using E_Commerce_System.Abstract;
using E_Commerce_System.Interfaces;
using System.Xml.Linq;

namespace E_Commerce_System.Entities
{
    public class DigitalProduct : Product, IDiscountable
    {
        public string DownloadUrl { get; set; }
        public int FileSizeMB { get; set; }

        public DigitalProduct(int id, string name, decimal basePrice, string category, int stock, string downloadUrl, int fileSizeMB)
            : base(id, name, basePrice, category, stock)
        {
            DownloadUrl = downloadUrl;
            FileSizeMB = fileSizeMB;
        }

        public override decimal GetFinalPrice()
        {
            return ApplyDiscount(BasePrice);
        }

        public override string GetProductDetails()
        {
            return $"{Name}, Price: ${GetFinalPrice():F2}, Size: {FileSizeMB}MB [Digital]";
        }

        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice * 0.9m; // 10% discount for digital products
        }

        public string GetDiscountDescription()
        {
            return "10% digital discount applied";
        }
    }
}