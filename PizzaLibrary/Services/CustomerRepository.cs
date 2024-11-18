using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, Customer> _customers;

        public CustomerRepository()
        {
            //_customers = new Dictionary<string, Customer>();
            _customers = MockData.CustomerData;
        }

        public int Count { get { return _customers.Count; } }

        public void AddCustomer(Customer customer)
        {
            //TODO
            if (!_customers.ContainsKey(customer.Mobile))
            { 
                _customers.Add(customer.Mobile, customer); 
            }

            else
            {
                Console.WriteLine("Customer with this mobile number already exists in database.");
            }
            //return !_customers.ContainsKey(customer.Mobile) ? _customers.Add(customer.Mobile,customer) : null;
        }

        public List<Customer> GetAll()
        {
            //TODO
           return _customers.Values.ToList();
        }

        public Customer? GetCustomerByMobile(string mobile)
        {
            //TODO
            //return _customers.ContainsKey(mobile) ? _customers[mobile] : null;
            if (mobile !=null && _customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            return null;
        }

        public void PrintAllCustomers()
        {
            //TODO
            if (Count > 0)
                foreach (var customer in _customers.Values)
                {
                    Console.WriteLine(customer.ToString());
                    Console.WriteLine();
                }
            return;
        }
        public List<Customer> getAllClubMembers()
        {
            List<Customer> clubList = new List<Customer>();
            foreach (var customer in _customers.Values)
            {
                if (customer.ClubMember == true)
                { 
                clubList.Add(customer);
                }
            }
            return clubList;
        }
        public void UpdateCustomer(Customer customer)
        {
            if (customer != null && _customers.ContainsKey(customer.Mobile))
            {
                _customers[customer.Mobile] = customer;
            }
        }
    
        public void RemoveCustomer(string mobile)
        {
           _customers.Remove(mobile);
        }
       
        public override string ToString()
        {
            //TODO is this nessecary, what does it do?
            return base.ToString();
        }
        public Customer? GetCustomerById(int id)
        {
            foreach (var cus in _customers.Values)
            {
                if (cus.Id == id)
                    return cus;
            }
            return null;

        }
    }
}
