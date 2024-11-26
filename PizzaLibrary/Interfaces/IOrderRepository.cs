using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderRepository
    {
        public int Count { get; set; }
        public List<IOrder> GetAll();
        public void AddOrder(IOrder order);
        public IOrder GetOrderById(int id);
        public void RemoveOrder(int id);
        public string PrintAllOrders();
        public string ToString();
    }
}
