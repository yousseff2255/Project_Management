using Lab_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_Project.Pages.Admin
{
    public class CreateUsersModel : PageModel
    {
        [BindProperty]
        public Student s { get; set; }
        public DB db { get; set; }
        public CreateUsersModel(DB db)
        {
            this.db = db;
            s = new Student();

        }
        public void OnGet()
        {

        }

        public IActionResult OnPost() {

            db.AddStudent(s);
            return RedirectToPage("/Index");
        }
    }
}
