namespace Lab_Project.Models
{
    public class Student:User
    {
        public Student()
        {
            role = "Student"; 
        }
        public int TeamId { get; set; }
        public int major {  get; set; }
    }
}
