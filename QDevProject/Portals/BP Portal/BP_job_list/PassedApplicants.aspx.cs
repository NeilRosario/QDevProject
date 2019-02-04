using RecruitMe.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecruitMe.BP_job_list
{
    public partial class PassedApplicants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Cookie summon and summond b_access_id
            if (Request.QueryString["app"] != null)
            {
                string filter_query = Request.QueryString["app"].ToString();
                if (filter_query == "f_app") {
                    getFailed();
                } else if (filter_query=="pa_app") {
                    getPassed();
                }
            }
            else {
          
                getAppplications();
           }
            
        }
        void getAppplications()
        {
            //get business ID
            int bus_id = 0;
            List<int> job_id_list = new List<int>();
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select job_id from job_posting", conn);
                //cmd.Parameters.AddWithValue("@b_id", 2);
                SqlDataReader id_list = cmd.ExecuteReader();
                while (id_list.Read())
                {
                    job_id_list.Add(id_list.GetInt32(0));
                }
                conn.Close();

            }

            int[] initial_id = job_id_list.ToArray();
            List<int> applied_id = new List<int>();
            List<int> app_id = new List<int>();
            List<DateTime> date_submitted = new List<DateTime>();

            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {

                int[] received_app_id = app_id.ToArray();
                int[] applied_id_receive = applied_id.ToArray();
                List<string> appNo = new List<string>();
                List<string> appName = new List<string>();
                conn.Open();
                //select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id and job_posting.b_access_id=1 )inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id))
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_application.status_id=2))";
                using (SqlCommand com = new SqlCommand(cmd, conn))
                {
                    SqlDataReader test_data = com.ExecuteReader();
                    while (test_data.Read())
                    {
                        appNo.Add(test_data.GetInt32(0).ToString());
                        appName.Add(test_data.GetString(2));

                    }

                    
                   
                
                }
                conn.Close();

            }
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {

                int[] received_app_id = app_id.ToArray();
                int[] applied_id_receive = applied_id.ToArray();
                List<string> appNo = new List<string>();
                List<string> appName = new List<string>();
                conn.Open();
                //select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id and job_posting.b_access_id=1 )inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_applicant.status_id=3))
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_application.status_id=2 or job_application.status_id=3))";
                SqlCommand com = new SqlCommand(cmd, conn);


                using (SqlDataAdapter data = new SqlDataAdapter(com))
                {
                    DataSet applications = new DataSet();
                    data.Fill(applications);
                    applications_list.DataSource = applications;
                    applications_list.DataBind();
                }

                conn.Close();

            }

        }
        void getPassed()
        {
            //get business ID
            int bus_id = 0;
            List<int> job_id_list = new List<int>();
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select job_id from job_posting", conn);
                //cmd.Parameters.AddWithValue("@b_id", 2);
                SqlDataReader id_list = cmd.ExecuteReader();
                while (id_list.Read())
                {
                    job_id_list.Add(id_list.GetInt32(0));
                }
                conn.Close();

            }

            int[] initial_id = job_id_list.ToArray();
            List<int> applied_id = new List<int>();
            List<int> app_id = new List<int>();
            List<DateTime> date_submitted = new List<DateTime>();

            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {

                int[] received_app_id = app_id.ToArray();
                int[] applied_id_receive = applied_id.ToArray();
                List<string> appNo = new List<string>();
                List<string> appName = new List<string>();
                conn.Open();
                //select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id and job_posting.b_access_id=1 )inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id))
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_application.status_id=2))";
                using (SqlCommand com = new SqlCommand(cmd, conn))
                {
                    SqlDataReader test_data = com.ExecuteReader();
                    while (test_data.Read())
                    {
                        appNo.Add(test_data.GetInt32(0).ToString());
                        appName.Add(test_data.GetString(2));

                    }

                    /**
                    using (SqlDataAdapter data = new SqlDataAdapter(com))
                    {
                        DataSet applications = new DataSet();
                        data.Fill(applications);
                        applications_list.DataSource = applications;
                        applications_list.DataBind();
                    }
                **/
                }
                conn.Close();

            }
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {

                int[] received_app_id = app_id.ToArray();
                int[] applied_id_receive = applied_id.ToArray();
                List<string> appNo = new List<string>();
                List<string> appName = new List<string>();
                conn.Open();
                //select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id and job_posting.b_access_id=1 )inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_applicant.status_id=3))
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_application.status_id=2))";
                SqlCommand com = new SqlCommand(cmd, conn);


                using (SqlDataAdapter data = new SqlDataAdapter(com))
                {
                    DataSet applications = new DataSet();
                    data.Fill(applications);
                    applications_list.DataSource = applications;
                    applications_list.DataBind();
                }

                conn.Close();

            }

        }
        void getFailed()
        {
            //get business ID
            int bus_id = 0;
            List<int> job_id_list = new List<int>();
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select job_id from job_posting", conn);
                //cmd.Parameters.AddWithValue("@b_id", 2);
                SqlDataReader id_list = cmd.ExecuteReader();
                while (id_list.Read())
                {
                    job_id_list.Add(id_list.GetInt32(0));
                }
                conn.Close();

            }

            int[] initial_id = job_id_list.ToArray();
            List<int> applied_id = new List<int>();
            List<int> app_id = new List<int>();
            List<DateTime> date_submitted = new List<DateTime>();

            
            using (SqlConnection conn = new SqlConnection(Helper.GetConnection()))
            {

                int[] received_app_id = app_id.ToArray();
                int[] applied_id_receive = applied_id.ToArray();
                List<string> appNo = new List<string>();
                List<string> appName = new List<string>();
                conn.Open();
                //select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id and job_posting.b_access_id=1 )inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_applicant.status_id=3))
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id and job_application.status_id=3))";
                SqlCommand com = new SqlCommand(cmd, conn);


                using (SqlDataAdapter data = new SqlDataAdapter(com))
                {
                    DataSet applications = new DataSet();
                    data.Fill(applications);
                    applications_list.DataSource = applications;
                    applications_list.DataBind();
                }

                conn.Close();

            }

        }

        protected void redirect_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "go_back")
            {
                Response.Redirect("ProcessApplicants.aspx");
            }
        }

        protected void filter_command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "filter_failed")
            {
                Response.Redirect("PassedApplicants.aspx?app=f_app");
            }
            else if (e.CommandName == "filter_passed") {
                Response.Redirect("PassedApplicants.aspx?app=pa_app");
            } 
        }
    }
}
