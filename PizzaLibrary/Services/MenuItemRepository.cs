using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> menuItems;

        public MenuItemRepository()
        {
           // menuItems = new List<MenuItem>();
            menuItems = MockData.MenuItemData;
        }
        public int Count = 0;

        int IMenuItemRepository.Count => throw new NotImplementedException();

        public void AddMenuItem(MenuItem menuItem)
        {
            menuItems.Add(menuItem);
            Count++;
        }

        public List<MenuItem> GetAll()
        {
           return menuItems;
        }

        public List<MenuItem> AllItemsOver50()
        {
            List<MenuItem> over50List = new List<MenuItem>();
            foreach (MenuItem item in menuItems)
            {
                if (item.Price >= 50)
                {
                    over50List.Add(item);
                }
            }
            return over50List;
        }

        public MenuItem GetMenuItemByNo(int no)
        {

            foreach (MenuItem item in menuItems)
            {
                if (item.No == no) return item;
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            if (menuItems != null)
            {
                foreach (MenuItem menuItem in menuItems)
                {
                    Console.WriteLine($"{menuItem.No}. {menuItem.Name} {menuItem.Price} kr. \n {menuItem.TheMenuType}: {menuItem.Description}");
                }
                return;
            }
        }

        public void RemoveMenuItem(int no)
        {
            foreach (MenuItem item in menuItems)
            {
                if (item.No == no) 
                    menuItems.Remove(item);
            }
        }

        public MenuItem MostExpensivePizza()
        {
            if (menuItems.Count == 0)
            {
                return null;
            }

            MenuItem expensiveItem = new MenuItem();
            expensiveItem.Price = 0;
            foreach (MenuItem item in menuItems)
            {
                if (item.TheMenuType==MenuType.PIZZECLASSSICHE 
                    || item.TheMenuType == MenuType.PIZZESPECIALI 
                    && item.Price > expensiveItem.Price)
                {
                    expensiveItem = item; 
                }
            }
            return expensiveItem;
        }

    }
}
