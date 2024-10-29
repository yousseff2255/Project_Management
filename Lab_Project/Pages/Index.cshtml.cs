using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_Project.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Reflection;
namespace Lab_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]  
        public User userr { get; set; } = new User();
        public string name { get; set; }
        public string session { get; set; } = "0";
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                
                session = "1";
                userr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                name = userr.username.Substring(userr.username.IndexOf('-') + 1);

            }
          

        }
        public IActionResult OnPostLogout()
        {

            HttpContext.Session.Clear();
            session = "0";
            return RedirectToPage("/SignIn");
        }
    }
}
