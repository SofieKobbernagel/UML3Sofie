using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Repositories
{
    public class AccessoryRepository : IAccessoryRepository
    {
        private List<Accessory> _accessories;

        public int Count { get; set; }

        public AccessoryRepository()
        {
            _accessories = new List<Accessory>();
        }

        public List<Accessory> GetAll()
        {
            return new List<Accessory>(_accessories);
        }

        public void AddAccessory(Accessory accessory)
        {
            if (accessory != null)
            {
                _accessories.Add(accessory);
            }
        }

        public Accessory? GetAccessoryById(int id)
        {
                foreach (var acc in _accessories)
                {
                    if (acc.Id == id)
                        return acc;
                }
                return null;
        }

        public void RemoveAccessory(int id)
        {
            var accessory = GetAccessoryById(id);
            if (accessory != null)
            {
                _accessories.Remove(accessory);
            }
        }

        public void PrintAllAccessories()
        {
            foreach (var accessory in _accessories)
            {
                Console.WriteLine(accessory);
            }
        }
    }
}

