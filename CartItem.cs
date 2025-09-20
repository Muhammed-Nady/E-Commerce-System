namespace ECommerceApp
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal TotalPrice => Product.GetFinalPrice() * Quantity;

        public override string ToString()
        {
            return $"{Product.Name} x{Quantity} = ${TotalPrice:F2}";
        }
    }
}