using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<MenuItem> GetAll();
        void AddMenuItem(MenuItem menuItem);
        MenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);

        void PrintAllMenuItems();
}
}
