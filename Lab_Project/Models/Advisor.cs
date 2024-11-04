namespace Lab_Project.Models
{
    public class Advisor : User
    {

        public Advisor()
        {
            role = "Advisor"; 
        }

        public string Major { get; set; }
        public string Specialiaztion { get; set; }
    }
}
