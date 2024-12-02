
using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab_Project.Models
{
    public class DB
    {
        SqlConnection connection { get; set; }
        public string connectionstring = " Data source  = LOCALHOST\\SQLEXPRESS; Initial Catalog =InLabProject ; Integrated Security = true ; trust server certificate = true ";
        public DB() {
            connection = new SqlConnection(connectionstring);
        }
        public DataTable ReadProjectsData()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Project";
            
            try
            {
                connection.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter(Query, connection);
                Adapter.Fill(dt);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { 
                connection.Close();
            }

            return dt;

        }
        public (DataTable,DataTable) ReadProject(int id)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            string Stored_proc = "project_members";
       
            SqlCommand cmd = new SqlCommand(Stored_proc , connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@project_id", id));

                connection.Open();

                SqlDataReader reader =  cmd.ExecuteReader();
                dt1.Load(reader);

                
                dt2.Load(reader);
               

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }

            return (dt1,dt2);
        }
    }

}
