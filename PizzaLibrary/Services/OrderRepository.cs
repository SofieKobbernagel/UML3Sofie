using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class OrderRepository : IOrderRepository
    {
        public int Count { get; set; }

        public void AddOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        public List<IOrder> GetAll()
        {
            throw new NotImplementedException();
        }

        public IOrder GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public string PrintAllOrders()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
