using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace UMLRazor.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private ICustomerRepository repo;

        //Binder Customer-objektet til inputfelterne i formularen på Razor-siden.
        //Når brugeren opdaterer oplysningerne, bliver Customer-objektet automatisk opdateret med de nye værdier.
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

        //Modtager en ICustomerRepository som parameter, så man kan bruge den til at tilgå og opdatere data om kunder.
        public EditCustomerModel(ICustomerRepository customerRepository)
        {
            this.repo = customerRepository;
        }

        //Ved at bruge id parameteren hentes kunden fra ICustomerRepository via repo.GetCustomerById(id),
        //og dataene bindes til Customer-modellen, som derefter vises i formularen.
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
        //Denne metode bliver kaldt, når brugeren klikker på "Update" knappen i formularen
        //Opdatering af kunden: Den opdaterede Customer bliver sendt til repo.UpdateCustomer(Customer), som opdaterer dataene i repositoryet.
        //RedirectToPage("ShowCustomers"): brugeren sendes videre til "ShowCustomers"-siden
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