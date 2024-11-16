using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get; set; }


        public Beverage(bool alcohol) : base() 
        { 
            Alcohol = alcohol;
        }
        
        public override string ToString()
        {
            if (Alcohol)
            return base.ToString() + "Denne drik indeholder alkohol";
            return base.ToString() + "Der er ikke alcohol i denne drik.";
        }

    }
}
