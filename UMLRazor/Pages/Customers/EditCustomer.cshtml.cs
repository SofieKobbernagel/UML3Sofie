using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        [BindProperty]
        public Customer Customer { get; set; }
        public int CId { get; set; }

        public EditCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        public void OnGet(string editMobile)
        {
            Customer = _repo.GetCustomerByMobile(editMobile);
            CId = Customer.Id;
        }
        public IActionResult OnPost()
        {
            _repo.EditCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }
    }
       
}
