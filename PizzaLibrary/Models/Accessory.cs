using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Accessory: IAccessory
    {
        private int _id;
        private string _name;
        private double _price;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Price: {_price:C}";
        }
    }
}
