using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_Project.Models;
using Newtonsoft.Json;
namespace Lab_Project.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public User user { get; set; } = new User();
        


        public string session { get; set; } = "0";



        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                if (user.username.Contains("ad-"))
                {
                    Advisor advisor = new Advisor();
                    advisor.username = user.username;
                    advisor.password = user.password;
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(advisor));
                }
                else if (user.username.Contains("s-"))
                {
                    Student student = new Student();
                    student.username = user.username;
                    student.password = user.password;
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(student));


                }
                else if (user.username.Contains("a-"))
                {
                    admin adminn = new admin();
                    adminn.username = user.username;
                    adminn.password = user.password;
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(adminn));


                }
                else
                {
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                }


                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
