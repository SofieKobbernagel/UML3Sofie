using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IShoppingBasket
    {
        List<OrderLine> GetAll();
        void AddOrderLine(OrderLine orderLine);
    }
}
