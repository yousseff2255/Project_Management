using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
namespace Lab_Project.Models
{
    [BindProperties(SupportsGet = true)]
    public class User
    {


        public User()
        {
            role = "User"; 
        }
        //public string name { get; set; }

        public string username { get; set; }
        [MinLength(3,ErrorMessage ="Password is too short ( 3 characters at minimum )")]
       
        public string password { get; set; }

        public string role { get; set; }


        // public string email { get; set; }
    }
}
