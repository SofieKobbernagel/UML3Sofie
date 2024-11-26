using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IAccessoryRepository
    {
         int Count { get; }
         List<Accessory> GetAll();
         void AddAccessory(Accessory accessory);
         Accessory GetAccessoryById(int id);
         void RemoveAccessory(int id);
         void PrintAllAccessories();
      
    }
}
