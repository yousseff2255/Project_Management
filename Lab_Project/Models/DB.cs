
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab_Project.Models
{
    public class DB
    {

        #region ConnectToDatabase
        SqlConnection connection { get; set; }
        public string connectionstring = " Data source  = LOCALHOST\\SQLEXPRESS; Initial Catalog =InLabProject ; Integrated Security = true ; trust server certificate = true ";
        #endregion

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



        #region lists
        public List<string> GetAdvisors()
        {
            List<string> advisors = new List<string>();
            string Query = "Select username from advisor";
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand(Query, connection);


                SqlDataReader sdr =  cmd1.ExecuteReader();
                while (sdr.Read())
                {
                    advisors.Add(sdr.GetString(0));

                }
                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return advisors;


        }

        public List<int> GetProjects()
        {
            List<int> projects = new List<int>();
            string Query = "Select id from project";
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand(Query, connection);


                SqlDataReader sdr = cmd1.ExecuteReader();
                while (sdr.Read())
                {
                    projects.Add(sdr.GetInt32(0));

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return projects;


        }

        public List<int> GetTeams()
        {
            List<int> teams = new List<int>();
            string Query = "Select team_id from team";
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand(Query, connection);


                SqlDataReader sdr = cmd1.ExecuteReader();
                while (sdr.Read())
                {
                    teams.Add(sdr.GetInt32(0));

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return teams;


        }

        #endregion



        #region Admin Functions
        public Numbers GetNums()
        {
            Numbers num = new Numbers();
            string Query_1 = "Select count(*) from Project";
            string Query_2 = "Select count(*) from Student";
            string Query_3 = "Select count(*) from Advisor";
            string Query_4 = "Select count(*) from Major";

            try
            {
                connection.Open();
               SqlCommand cmd1 = new SqlCommand (Query_1, connection);
                SqlCommand cmd2 = new SqlCommand(Query_2, connection);
                SqlCommand cmd3 = new SqlCommand(Query_3, connection);
                SqlCommand cmd4 = new SqlCommand(Query_4, connection);

                num.Num_Projects = (int)cmd1.ExecuteScalar();
                num.Num_Students = (int)cmd2.ExecuteScalar();
                num.Num_Advisors = (int)cmd3.ExecuteScalar();
                num.Num_Majors = (int)cmd4.ExecuteScalar();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return num;

        }

        public void AddProject(Project p)
        {
            try
            {
                connection.Open();
                string Query = $"Insert into Project values ({p.Id} , '{p.title}' , '{p.description}' , '{p.focus_area}' , {2024} , '{p.status}' , '{p.video}' , '{p.team_id}' , '{p.Dep_project_id}' , '{p.thesis}' , '{p.advisor}')";
                //string Query = $"Insert into Project values ({p.Id} , '{p.title}' , '{p.description}' , '{p.focus_area}' , {2024} , '{p.status}' , '{p.video}' , '{p.team_id}' , '{p.Dep_project_id}' , '{p.thesis}' , {p.advisor})";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                connection.Close();
            }
        }

        public void AddStudent(Student s)
        {
            try
            {
                connection.Open();
                string Query = $"Insert into Student values ('{s.username}' , '{s.password}' , '{s.email}' , {1} , '{s.name}')";
                //string Query = $"Insert into Project values ({p.Id} , '{p.title}' , '{p.description}' , '{p.focus_area}' , {2024} , '{p.status}' , '{p.video}' , '{p.team_id}' , '{p.Dep_project_id}' , '{p.thesis}' , {p.advisor})";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                connection.Close();
            }
        }

        public void AddAdvisor(Advisor ad)
        {
            try
            {
                connection.Open();
                string Query = $"Insert into advisor values ('{ad.username}' , '{ad.password}' , '{ad.email}' , {1} , '{ad.name}' , '{ad.Specialiaztion}')";
                //string Query = $"Insert into Project values ({p.Id} , '{p.title}' , '{p.description}' , '{p.focus_area}' , {2024} , '{p.status}' , '{p.video}' , '{p.team_id}' , '{p.Dep_project_id}' , '{p.thesis}' , {p.advisor})";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                connection.Close();
            }
        }

        public Dictionary<string, int> GetMajorsPopulation()
        {
            Dictionary<string, int> MajorsPopulation = new Dictionary<string, int>();

            try
            {
                connection.Open();
                string Query = "SELECT j.name as [Major name] , count(s.username) as [Number of Students]\r\nFROM student as s join major as j on (s.major = j.major_num) \r\ngroup by j.name ";
                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    MajorsPopulation.Add(sdr["Major name"].ToString(), (int)sdr["Number of Students"]);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }

            return MajorsPopulation;
        }

        public Dictionary<string, int> GetProjectsStatus()
        {
            Dictionary<string, int> ProjectsStatus = new Dictionary<string, int>();

            try
            {
                connection.Open();
                string Query = "SELECT status , count (ID) as [Number of projects] FROM project group by status";
                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ProjectsStatus.Add(sdr["status"].ToString(), (int)sdr["Number of projects"]);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }

            return ProjectsStatus;
        }
        #endregion


    }

}
