using System;

namespace ECommerceApp
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        protected Person(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public abstract string GetRole();

        public virtual string GetContactInfo()
        {
            return $"{Name} ({Email})";
        }
    }
}