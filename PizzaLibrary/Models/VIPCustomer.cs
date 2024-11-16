using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        private double _discount;

        public double Discount
        {
            get { return _discount; }
            set
            {
                if (value < 1 || value > 25)
                {
                    throw new ArgumentOutOfRangeException("Discount", "Discount must be between 1 and 25%");
                }
                _discount = value;
            }
        }
        public VIPCustomer(string name, string mobile, string address,double discount) : base(name, mobile, address)
        {
            Discount = discount;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nVIP Customer Discount: {Discount}%";
        }
    }
}
