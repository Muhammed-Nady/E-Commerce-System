using E_Commerce_System.Abstract;
using System;

namespace E_Commerce_System.Entities
{
    public class Admin : Person
    {
        public string Department { get; set; }
        public DateTime HireDate { get; set; }

        public Admin(int id, string name, string email, string department)
            : base(id, name, email)
        {
            Department = department;
            HireDate = DateTime.Now;
        }

        public override string GetRole()
        {
            return $"Admin - {Department}";
        }

        public bool CanManageInventory()
        {
            return Department == "Inventory" || Department == "Management";
        }
    }
}