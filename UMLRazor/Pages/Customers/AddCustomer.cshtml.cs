using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class AddCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        [BindProperty]//two way binding
        public Customer Customer { get; set; }

        public AddCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _repo.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }
    }
}
