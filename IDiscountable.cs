namespace ECommerceApp
{
    public interface IDiscountable
    {
        decimal ApplyDiscount(decimal originalPrice);
        string GetDiscountDescription();
    }
}
