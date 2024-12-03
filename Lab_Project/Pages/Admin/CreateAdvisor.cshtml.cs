using Lab_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_Project.Pages.Admin
{

    public class CreateAdvisorModel : PageModel
    {
        DB db;
        [BindProperty]
        public Advisor ad { get; set; }
        public CreateAdvisorModel(DB db)
        {
            this.db = db;
            ad = new Advisor();

        }
   

        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {

            db.AddAdvisor(ad);
            return RedirectToPage("/Index");
        }
    }
}
