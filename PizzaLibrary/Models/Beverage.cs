using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get; set; }
        public Beverage(string name, double price, string description, MenuType menuType, bool alcohol) : base(name, price, description, menuType)
        {
            Alcohol = alcohol;
        }
        
        public override string ToString()
        {
            if (Alcohol)
            return base.ToString() + $" indeholder alkohol.";
            return base.ToString() + $" indeholder ikke alcohol.";
        }

    }
}
