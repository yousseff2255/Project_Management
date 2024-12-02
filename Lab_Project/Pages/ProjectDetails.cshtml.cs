using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_Project.Models;

namespace Lab_Project.Pages
{
    public class ProjectDetailsModel : PageModel
    {
        [BindProperty]
        public DataTable dt1 { get; set; }
        [BindProperty]
        public DataTable dt2 { get; set; }
        DB db;
        [BindProperty]
        public Project p { get; set; }
        public int ID { get; set; }
        public ProjectDetailsModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(int id)
        {
            p  = new Project();

            ID = id;
            (dt1, dt2) = db.ReadProject(ID);
            p.title = (string)dt2.Rows[0][1];
            p.description = (string)dt2.Rows[0][2];
            p.focus_area = (string)dt2.Rows[0][3];
            p.year = (int) dt2.Rows[0][4];
            p.status = (string) dt2.Rows[0][5];
            p.video = (string) dt2.Rows[0][6];
            p.team_id = (int)dt2.Rows[0][7];
            p.Dep_project_id = (int)dt2.Rows[0][8];
            p.thesis = (string)dt2.Rows[0][9];
            p.advisor= (string)dt2.Rows[0][10];




        }
        
    }
}
