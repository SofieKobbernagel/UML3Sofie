
using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private int _id;
        private static int _counter = 0;
        public string Address { get; set; }
        public bool ClubMember { get; set; } = false;  // Sætter en standardværdi for ClubMember.
        public int Id { get { return _id; } set { _id = value; } }
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Write your name"), MaxLength(30), DisplayName("Customer name")]
        public string Name { get; set; }

        public string CustomerImage { get; set; } = "default.jpg"; // Sætter en standardværdi for CustomerImage.

        // Standardkonstruktør.
        public Customer()
        {
            CustomerImage = "default.jpg";
            _counter++;
            _id = _counter;
        }
        // Overloaded konstruktør
        public Customer(string name, string mobile, string address)
        {
            CustomerImage = "default.jpg";
            _counter++;
            _id = _counter;
            Name = name;
            Mobile = mobile;
            Address = address;
            ClubMember = false;
        }   
        #region Methods

        public override string ToString()
        {
            return $"{_id} {Name} {Mobile} {Address} {(ClubMember ? "er medlem" : "Er ikke medlem")}";
        }
        #endregion
    }
}
