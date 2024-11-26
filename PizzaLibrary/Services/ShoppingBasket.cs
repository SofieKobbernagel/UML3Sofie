using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class ShoppingBasket : IShoppingBasket
    {
        private List<OrderLine> _orderLines;

        public ShoppingBasket()
        {
            _orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderLine)
        {
           _orderLines.Add(orderLine);
        }

        public List<OrderLine> GetAll()
        {
            return _orderLines;
        }
    }
}
