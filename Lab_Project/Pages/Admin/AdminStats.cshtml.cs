using Lab_Project.Models;
using Lab_Project.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Lab_Project.Pages.Admin
{
    [BindProperties]
    public class AdminStatsModel : PageModel
    {
  
        public DB db { get; set; }
        public Numbers num { get; set; }
        public string BarChartJson { get; set; }
        public string PieChartJson { get; set; }
        public ChartJs BarChart  { get; set; }
        public ChartJs PieChart { get; set; }

        public AdminStatsModel()
        {
            db = new DB();
            BarChart = new ChartJs();
            PieChart = new ChartJs();
            num = new Numbers();

        }
        public void OnGet()
        {
            Dictionary<string , int> majors_population= db.GetMajorsPopulation();
            Dictionary<string, int> Projects_Status = db.GetProjectsStatus();
            setUpBarChart(majors_population);
            setUpPieChart(Projects_Status);
            num = db.GetNums();




        }
        private void setUpBarChart(Dictionary<string, int> dataToDisplay)
        {
            try
            {
                // 1. set up chart options 
                BarChart.type = "bar";
                BarChart.options.responsive = true;

                // 2. separate the received Dictionary data into labels and data arrays 
                var Label_List = new List<string>();
                var Data_List = new List<double>();
                foreach (var data in dataToDisplay)
                {
                    Label_List.Add(data.Key);
                    Data_List.Add(data.Value);
                }

                BarChart.data.labels = Label_List;
                // 3. set up a dataset 
                var firsDataset = new Dataset();
                firsDataset.label = "Number of Students";
                firsDataset.data = Data_List.ToArray();
                firsDataset.backgroundColor = ["#C6E7FF"];
                BarChart.data.datasets.Add(firsDataset);
                // 4. finally, convert the object to json to be able to inject in  HTML code
                BarChartJson = JsonConvert.SerializeObject(BarChart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initialising the bar chart inside Index.cshtml.cs"
            );
                throw e;

            }
        }
        private void setUpPieChart(Dictionary<string, int> dataToDisplay)
        {
            try
            {
                // 1. set up chart options 
                PieChart.type = "pie";
                PieChart.options.responsive = true;

                // 2. separate the received Dictionary data into labels and data arrays 
                var Label_List = new List<string>();
                var Data_List = new List<double>();
                foreach (var data in dataToDisplay)
                {
                    Label_List.Add(data.Key);
                    Data_List.Add(data.Value);
                }

                PieChart.data.labels = Label_List;
                // 3. set up a dataset 
                var firsDataset = new Dataset();

                firsDataset.label = "Number of Projects";
                firsDataset.data = Data_List.ToArray();
                PieChart.data.datasets.Add(firsDataset);
                // 4. finally, convert the object to json to be able to inject in  HTML code
                PieChartJson = JsonConvert.SerializeObject(PieChart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initialising the bar chart inside Index.cshtml.cs"
            );
                throw e;

            }
        }
    }
}
