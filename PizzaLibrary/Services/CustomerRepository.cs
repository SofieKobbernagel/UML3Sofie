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

        // Tilføjer en kunde, hvis mobilnummer ikke allerede findes.
        public void AddCustomer(Customer customer)
        {
        
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

        // Henter alle kunder som en liste.
        public List<Customer> GetAll()
        {
        
           return _customers.Values.ToList();
        }

        // Henter en kunde baseret på mobilnummer.
        public Customer? GetCustomerByMobile(string mobile)
        {
            if (mobile !=null && _customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            return null;
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

        public void PrintAllCustomers()
        {
       
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

        // Returnerer alle kunder som en streng (til debugging).
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _customers.Values.Select(c => c.ToString()));
        }

       
    }
}
