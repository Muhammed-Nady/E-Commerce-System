using System.Xml.Linq;

namespace ECommerceApp
{
    public class PhysicalProduct : Product
    {
        public double Weight { get; set; }
        public string Dimensions { get; set; }

        public PhysicalProduct(int id, string name, decimal basePrice, string category, int stock, double weight, string dimensions)
            : base(id, name, basePrice, category, stock)
        {
            Weight = weight;
            Dimensions = dimensions;
        }

        public override decimal GetFinalPrice()
        {
            decimal shippingCost = (decimal)(Weight * 0.5); // $0.5 per kg
            return BasePrice + shippingCost;
        }

        public override string GetProductDetails()
        {
            return $"{Name}, Price: ${GetFinalPrice():F2}, Weight: {Weight}kg, Size: {Dimensions}";
        }
    }
}