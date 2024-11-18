using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private ICustomerRepository repo;

        [BindProperty]
        public Customer Customer { get; set; }

        //[BindProperty]
        //public string Name { get; set; }
        //[BindProperty]
        //public string Mobile { get; set; }
        //[BindProperty]
        //public string Address { get; set; }
        //[BindProperty]
        //public int Id { get; set; }


        public EditCustomerModel(ICustomerRepository customerRepository)
        {
            this.repo = customerRepository;
        }

        public IActionResult OnGet(int id)
        {
            Customer = repo.GetCustomerById(id);
            //Customer? currentCustomer = repo.GetCustomerById(id);
            //if (currentCustomer != null)
            //{
            //    Name = currentCustomer.Name;
            //    Mobile = currentCustomer.Mobile;
            //    Address = currentCustomer.Address;
            //    Id = currentCustomer.Id;
            //}
            return Page();

        }

        public IActionResult OnGetCustomer(int id)
        {
            Customer = repo.GetCustomerById(id);
            return Page();
        }

        public IActionResult OnPostEdit()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            repo.UpdateCustomer(Customer);
            //repo.UpdateCustomer(Id, Name, Mobile, Address);
            return RedirectToPage("ShowCustomers");
        }

        public IActionResult OnPostDelete()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //repo.DeleteEvent(Event);
            return RedirectToPage("ShowCustomers");
        }
    }
}