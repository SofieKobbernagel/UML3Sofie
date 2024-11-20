using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class AddCustomerModel : PageModel
    {
        private ICustomerRepository _repo;


        private IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public IFormFile Photo { get; set; }


        [BindProperty] //Two way binding
        public Customer Customer { get; set; }

        //Denne konstruktor bruges til at initialisere afhængigheder, som ICustomerRepository, som bruges til at håndtere fil-uploadet.
        public AddCustomerModel(ICustomerRepository customerRepository, IWebHostEnvironment webHost)
        {
            _repo = customerRepository;
            webHostEnvironment = webHost;
        }

        //Denne metode kaldes, når siden indlæses med en GET-anmodning
        //Den er tom i øjeblikket, hvilket betyder, at man ikke behøver at gøre noget, når siden bare bliver indlæst.
        public void OnGet()
        {
        }

        //Kaldes, når formularen sendes (POST-anmodning). Den håndterer logikken for at gemme en ny kunde, herunder fil-upload (billede).
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Hvis modelvalidering fejler, vis formularen igen med fejl
            }

            if (Photo != null)  // Håndtering af billedeupload og filsletning
            {
                if (Customer.CustomerImage != null && Customer.CustomerImage != "default.jpg")
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/Images/CustomerImages", Customer.CustomerImage);
                    System.IO.File.Delete(filePath);
                }
                // Processér og gem det nye billede
                Customer.CustomerImage = ProcessUploadedFile();
            }

            // Tilføj den nye kunde til databasen
            _repo.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }

        //Håndterer fil-uploadet. Den opretter et unikt filnavn, gemmer filen i den angivne mappe og returnerer det nye filnavn.
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                // Bestem upload-mappen
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/CustomerImages");
                // Opret et unikt filnavn
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                // Bestem filens fulde sti
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Kopiér filen til serveren
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName; // Returnér det nye filnavn
        }
    }
}
