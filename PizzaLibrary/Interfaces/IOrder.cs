using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrder
    {
     public int Id { get; }
        public bool ToBeDelivered { get; }
        public void AddToOrder(OrderLine line);
        public double CalculateTotal();
        public void PrintReciept();
        public string ToString();
    }
}
