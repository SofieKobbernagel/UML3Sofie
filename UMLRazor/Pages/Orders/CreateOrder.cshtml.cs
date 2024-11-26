using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        private ICustomerRepository _cRepo;
        private IMenuItemRepository _mRepo;
        private IShoppingBasket _shoppingBasket;
        [BindProperty]
        public string SearchCustomerMobile { get; set; }

        public List<SelectListItem> MenuItemSelectList { get; set; }

        public Customer TheCustomer { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public ShoppingBasket ShoppingBasket { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public CreateOrderModel(
            ICustomerRepository customerRepository, 
            IMenuItemRepository menuItemRepository, 
            IShoppingBasket shoppingBasket)
        {
            _cRepo = customerRepository;
            _mRepo = menuItemRepository;
            _shoppingBasket = shoppingBasket;
            createMenuSelectList();
            _shoppingBasket = shoppingBasket;
        }

        private void createMenuSelectList()
        {
            MenuItemSelectList = new List<SelectListItem>();
            MenuItemSelectList.Add(new SelectListItem("Select an item", "-1"));
            foreach(MenuItem item in _mRepo.GetAll()) 
            {
                SelectListItem sli = new SelectListItem(item.Name, item.No.ToString());
                MenuItemSelectList.Add(sli);
            }
        }

        public void OnGet()
        {
        }

        public void OnPostCustomer() 
        {
            TheCustomer = _cRepo.GetCustomerByMobile(SearchCustomerMobile);
            if (TheCustomer == null)
            {
                //Error message
            }
        }
        public void OnPostAddToOrder() 
        {
            if (Amount > 0) 
            {
                MenuItem menuItemToOrder = _mRepo.GetMenuItemByNo(ChosenMenuItem);
                if (menuItemToOrder != null) 
                {
                    OrderLine ol = new OrderLine(menuItemToOrder, Amount,Comment);
                    ShoppingBasket.AddOrderLine(ol);
                }
            }
        }
    }
}
