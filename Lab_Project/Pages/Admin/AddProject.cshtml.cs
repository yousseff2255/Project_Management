using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_Project.Models;

namespace Lab_Project.Pages.Admin
{
    public class AddProjectModel : PageModel
    {
        [BindProperty]
        public Project p  { get; set; }
        public DB db { get; set; }

        public List<string> advisors { get; set; }
        public List<int> projects { get; set; }
        public List<int> teams { get; set; }

        public AddProjectModel(DB db)
        {
            this.db = db;
            advisors = new List<string>();
            projects = new List<int>();
            teams = new List<int>();
        }
        public void OnGet()
        {
            advisors = db.GetAdvisors();
            teams = db.GetTeams();
            projects = db.GetProjects();


        }

        public IActionResult OnPost() {
            db.AddProject(p);
            return RedirectToPage("/Index");
        }
    }
}
