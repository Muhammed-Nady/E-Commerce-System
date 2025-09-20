using System;

namespace ECommerceApp
{
    public class Customer : Person
    {
        public CustomerType Type { get; set; }
        public DateTime JoinDate { get; set; }

        public Customer(int id, string name, string email, CustomerType type)
            : base(id, name, email)
        {
            Type = type;
            JoinDate = DateTime.Now;
        }

        public override string GetRole()
        {
            return $"Customer - {Type}";
        }

        public override string GetContactInfo()
        {
            return $"{base.GetContactInfo()} - {Type} since {JoinDate:yyyy}";
        }
    }

    public enum CustomerType
    {
        Regular,
        Premium,
        VIP
    }
}