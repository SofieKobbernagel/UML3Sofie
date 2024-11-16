using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        private static int _itemCounter = 1;
        public string Description { get; set; }
        public string Name { get; set; }
       
        public int No { get; private set; }
        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public MenuItem()
        {
            
        }

        public MenuItem(string name, double price, string description, MenuType menuType) 
        {
            Name = name;
            Description = description;
            Price = price;  
            TheMenuType = menuType;
            No=_itemCounter;
            _itemCounter++;
        }   

        
    }
}
