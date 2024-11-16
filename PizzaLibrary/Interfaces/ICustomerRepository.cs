using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Models;

namespace PizzaLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        public int Count { get; }
        List<Customer> GetAll();
        void AddCustomer(Customer customer);
        Customer? GetCustomerByMobile(string mobile);
        void RemoveCustomer(string mobile);
        void PrintAllCustomers();
        void EditCustomer(Customer customer);
    }
}
