using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IAccessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ToString();
    }
}
