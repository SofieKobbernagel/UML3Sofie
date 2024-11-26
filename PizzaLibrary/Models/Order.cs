using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaLibrary.Models
{
    public class Order : IOrder
    {
        private List<OrderLine> _lines;
        private Customer _customer;
        private DateTime _timeOfCreation;

        private static int _count = 0;

        public int Id { get; }
        public bool ToBeDelivered { get; }

        public Order(Customer customer, bool toBeDelivered)
        {
            Id = _count++;
            _customer = customer;
            _timeOfCreation = DateTime.Now;
            _lines= new List<OrderLine>();
            ToBeDelivered = toBeDelivered;
        }

        public void AddToOrder(OrderLine line)
        {
            _lines.Add(line);
        }


        public double CalculateTotal()
        {
            if(_lines.Count == 0) return 0;
            double total = 0;
            foreach (OrderLine line in _lines)
            {
                total += line.SubTotal();
            }
            return total;
        }

        public void PrintReciept()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            // Start med de grundlæggende oplysninger om ordren
            string receipt = $"Order ID: #{Id}\n";
            receipt += $"Customer: {_customer.Name}\n";
            receipt += $"Created: {_timeOfCreation}\n";
            receipt += $"Delivery: {(ToBeDelivered ? "Yes" : "No")}\n\n";

            // Tilføj header til ordrelinjerne
            receipt += "Order Details:\n";
            receipt += "--------------------------------------------------\n";

            // Tilføj hver ordrelinje
            foreach (OrderLine line in _lines)
            {
                receipt += line.ToString() + "\n";
            }

            // Tilføj en divider og totalprisen
            receipt += "--------------------------------------------------\n";
            receipt += $"Total: {CalculateTotal():C}\n";

            return receipt;
        }

    }
}
