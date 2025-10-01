using System;
using System.Collections.Generic;
using System.Linq;
using Lab_2_2.Models;

namespace Lab_2_2.Services
{
    public class LombardService
    {
        private List<ItemModel> _items;

        public LombardService()
        {
            _items = new List<ItemModel>();
        }

        public void GenerateTestData()
        {
            var client1 = new ClientModel
            {
                FirstName = "Іван",
                LastName = "Петренко",
                Email = "ivan@example.com",
                PhoneNumber = "0991112233",
                Age = 30
            };

            var client2 = new ClientModel
            {
                FirstName = "Марія",
                LastName = "Іваненко",
                Email = "maria@example.com",
                PhoneNumber = "0975556677",
                Age = 25
            };

            _items.Add(new ItemModel
            {
                Name = "Золотий ланцюжок",
                Price = 5000,
                ReceivedDate = DateTime.Now.AddDays(-10),
                InterestFreePeriodEndDate = DateTime.Now.AddDays(-5),
                DeathLineDate = DateTime.Now.AddDays(5),
                InterestPerDay = 50,
                Owner = client1
            });

            _items.Add(new ItemModel
            {
                Name = "Ноутбук Asus",
                Price = 12000,
                ReceivedDate = DateTime.Now.AddDays(-20),
                InterestFreePeriodEndDate = DateTime.Now.AddDays(-15),
                DeathLineDate = DateTime.Now.AddDays(-1),
                InterestPerDay = 100,
                Owner = client2
            });
        }

        public List<ItemModel> GetAllItems()
        {
            return _items;
        }

        public List<ItemModel> SearchByName(string name)
        {
            return _items.Where(i => i.Name.Contains(name)).ToList();
        }

        public List<ItemModel> SearchByOwner(string lastName)
        {
            return _items.Where(i => i.Owner.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<ItemModel> FilterByPrice(float min, float max)
        {
            return _items.Where(i => i.Price >= min && i.Price <= max).ToList();
        }

        public List<ItemModel> GetExpiredItems()
        {
            return _items.Where(i => DateTime.Now > i.DeathLineDate).ToList();
        }

        public List<ItemModel> GetActiveItems()
        {
            return _items.Where(i => DateTime.Now <= i.DeathLineDate).ToList();
        }
    }
}
