namespace E_Commerce_System.Interfaces
{
    public interface IDiscountable
    {
        decimal ApplyDiscount(decimal originalPrice);
        string GetDiscountDescription();
    }
}
