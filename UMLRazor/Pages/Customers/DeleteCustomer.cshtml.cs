using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        [BindProperty]
        public Customer Customer { get; set; }

        public DeleteCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        public void OnGet(string deleteMobile)
        {
            Customer = _repo.GetCustomerByMobile(deleteMobile);
        }
        public IActionResult OnPost()
        {
            _repo.RemoveCustomer(Customer.Mobile);
            return RedirectToPage("ShowCustomers");
        }
    }
}
