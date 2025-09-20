using System.Xml.Linq;

namespace ECommerceApp
{
    public class PremiumProduct : PhysicalProduct, IDiscountable
    {
        public string Brand { get; set; }
        public int WarrantyMonths { get; set; }

        public PremiumProduct(int id, string name, decimal basePrice, string category, int stock,
                            double weight, string dimensions, string brand, int warrantyMonths)
            : base(id, name, basePrice, category, stock, weight, dimensions)
        {
            Brand = brand;
            WarrantyMonths = warrantyMonths;
        }

        public override decimal GetFinalPrice()
        {
            decimal baseWithShipping = base.GetFinalPrice();
            return ApplyDiscount(baseWithShipping);
        }

        public override string GetProductDetails()
        {
            return $"{Brand} {Name}, Price: ${GetFinalPrice():F2}, {WarrantyMonths}mo warranty";
        }

        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice * 1.15m; // 15% premium markup
        }

        public string GetDiscountDescription()
        {
            return "Premium product - 15% markup for quality";
        }
    }
}