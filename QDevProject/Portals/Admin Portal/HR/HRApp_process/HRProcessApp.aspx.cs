using RecruitMe.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecruitMe.HRApp_process
{
    public partial class HRProcessApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getHRAppList();
        }
        void getHRAppList()
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
                string cmd = @"select job_application.application_no, job_posting.job_title, applicant_basic_info.first_name,applicant_basic_info.last_name, job_application.date_applied, job_status.status from ((((job_application Inner Join job_posting ON job_application.job_id=job_posting.job_id)inner join applicant_basic_info on job_application.applicant_id=applicant_basic_info.applicant_id)inner join job_status on job_application.status_id=job_status.status_id))";
                SqlCommand com = new SqlCommand(cmd, conn);


                using (SqlDataAdapter data = new SqlDataAdapter(com))
                {
                    DataSet applications = new DataSet();
                    data.Fill(applications);
                    applicant_list.DataSource = applications;
                    applicant_list.DataBind();
                }

                conn.Close();

            }

        }

        void process(int x, int y)
        {

            SqlConnection con = new SqlConnection(Helper.GetConnection());

            con.Open();
            SqlCommand cmd = new SqlCommand("Update job_application set status_id=@results where application_no=@number", con);
            cmd.Parameters.AddWithValue("@results", y);
            cmd.Parameters.AddWithValue("@number", x);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void btn_reject_Command(object sender, EventArgs e)
        {

        }

        protected void btn_reject_Command1(object sender, CommandEventArgs e)
        {
            string holder = e.CommandArgument.ToString();
            int x = Int32.Parse(holder);
            if (e.CommandName == "fail")
            {

                if (x > 0)
                {
                    process(x, 3);
                    Response.Redirect("http://localhost:49894/BP_job_list/ProcessApplicants");
                }
            }
            else if (e.CommandName == "pass")
            {
                if (x > 0)
                {
                    process(x, 2);
                    Response.Redirect("http://localhost:49894/BP_job_list/ProcessApplicants");
                }
            }
            else if (e.CommandName == "view_details")
            {
                if (x > 0)
                {

                    
                    Response.Redirect("HRViewProfile.aspx?id=" + e.CommandArgument.ToString());
                }
            }
        }
    }
}