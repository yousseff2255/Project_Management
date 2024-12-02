using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_Project.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Reflection;
using System.Data;
namespace Lab_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]  
        public User userr { get; set; } = new User();
        public string name { get; set; }
        public string session { get; set; } = "0";
        DB db;
        public DataTable dt { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                
                session = "1";
                userr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                name = userr.username.Substring(userr.username.IndexOf('-') + 1);
                
            }
            dt = db.ReadProjectsData();




        }
        public IActionResult OnPostLogout()
        {

            HttpContext.Session.Clear();
            session = "0";
            return RedirectToPage("/SignIn");
        }
        public IActionResult OnPostView(int ID)
        {
            return RedirectToPage("/ProjectDetails" , new {id = ID});
        }
    }
}
