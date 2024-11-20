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
        private static int _itemCounter = 1; // Styrer automatisk nummerering af menupunkter.
        public int No { get; private set; } 
        public string Name { get; set; } 
        public string Description { get; set; } // Beskrivelsen af menupunktet.
        public double Price { get; set; } // Prisen på menupunktet.
        public MenuType TheMenuType { get; set; } // Typen af menupunkt.

        // Overloaded konstruktør
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Description = description;
            Price = price;
            TheMenuType = menuType;
            // Genererer et unikt nummer for hvert menupunkt.
            No = _itemCounter;
            _itemCounter++;
        }

        public MenuItem()
        {
            
        }
        public override string ToString()
        {
            return $"{Name}";
        }


    }
}
