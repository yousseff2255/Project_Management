namespace Lab_Project.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string focus_area { get; set; }
        public int year { get; set; }
        public string status { get; set; }
        public string video { get; set; }
        public string thesis { get; set; }

        public int Dep_project_id { get; set; }
        public int team_id { get; set; }
        public string advisor { get; set; }
    }
}
