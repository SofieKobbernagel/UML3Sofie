using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controller.Customers
{
    public class AddCustomerController
    {
        ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }

        public AddCustomerController(string name, string mobile, string address, bool clubMember, ICustomerRepository customerRepository)
        {
            Customer = new Customer(name, mobile, address);
            Customer.ClubMember = clubMember;
            _customerRepository = customerRepository;
        }

        public void AddCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }


    }

}
