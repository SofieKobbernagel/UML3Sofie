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

        //Denne konstruktor bruges til at initialisere afh�ngigheder, som ICustomerRepository, som bruges til at h�ndtere fil-uploadet.
        public AddCustomerModel(ICustomerRepository customerRepository, IWebHostEnvironment webHost)
        {
            _repo = customerRepository;
            webHostEnvironment = webHost;
        }

        //Denne metode kaldes, n�r siden indl�ses med en GET-anmodning
        //Den er tom i �jeblikket, hvilket betyder, at man ikke beh�ver at g�re noget, n�r siden bare bliver indl�st.
        public void OnGet()
        {
        }

        //Kaldes, n�r formularen sendes (POST-anmodning). Den h�ndterer logikken for at gemme en ny kunde, herunder fil-upload (billede).
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Hvis modelvalidering fejler, vis formularen igen med fejl
            }

            if (Photo != null)  // H�ndtering af billedeupload og filsletning
            {
                if (Customer.CustomerImage != null && Customer.CustomerImage != "default.jpg")
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/Images/CustomerImages", Customer.CustomerImage);
                    System.IO.File.Delete(filePath);
                }
                // Process�r og gem det nye billede
                Customer.CustomerImage = ProcessUploadedFile();
            }

            // Tilf�j den nye kunde til databasen
            _repo.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }

        //H�ndterer fil-uploadet. Den opretter et unikt filnavn, gemmer filen i den angivne mappe og returnerer det nye filnavn.
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
                // Kopi�r filen til serveren
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName; // Return�r det nye filnavn
        }
    }
}
