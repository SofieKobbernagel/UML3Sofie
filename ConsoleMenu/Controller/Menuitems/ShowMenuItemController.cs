using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controller.Menuitems
{
    public class ShowMenuItemController
    {
        private IMenuItemRepository _menuItemRepo;
        public ShowMenuItemController(IMenuItemRepository menurepository) 
        {
            _menuItemRepo = menurepository;
        }
        public void ShowAllMenuItems()
        {
            _menuItemRepo.PrintAllMenuItems();
        }

    }
}
