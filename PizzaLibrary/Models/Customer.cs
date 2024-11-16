using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        
        private int _id;
        private static int _counter = 0;

        public string Address { get; set; }
        public bool ClubMember { get; set; }
       
        public int Id {  get { return _id; } }

        public string Mobile { get; set; }
        public string Name { get; set; }

        public Customer(string name, string mobile, string address) 
        {
            _counter++;
            _id = _counter;
            Name = name;
            Mobile = mobile;
            Address = address;
            ClubMember = false;
        }
        public Customer() {
                _counter++;
                _id = _counter;
            
        }

        public override string ToString()
        {
            return $"Costumer with id: {Id}\nName: {Name}\nMobile: {Mobile}\nAddress: {Address}\nIs clubmember: {ClubMember}";
        }
    }
}
