using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QDevProject.App_Code;

namespace QDevProject.Portals.Applicant_Portal.Applications
{
    public partial class ViewApplicationStatus : System.Web.UI.Page
    {
       
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetJobs();
            }
        }

        void GetJobs()
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string cmd = @"SELECT jobapp.application_no, s.status, c.company_name, j.job_title, j.job_description, js.Description FROM job_application jobapp
                                        INNER JOIN job_status s ON jobapp.status_id = s.status_id  
										INNER JOIN job_posting j ON jobapp.job_id=j.job_id                                    
										INNER JOIN business_access c ON j.b_access_id = c.b_access_id
										INNER JOIN job_post_status js ON j.job_post_status_id = js.job_post_status_id
										WHERE jobapp.applicant_id=@AID";


                using (SqlCommand com = new SqlCommand(cmd, con))
                {
                    com.Parameters.AddWithValue("@AID", Session["applicant_id"].ToString());

                    using (SqlDataAdapter sda = new SqlDataAdapter(com))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "job_application");

                        lvApp.DataSource = ds;
                        lvApp.DataBind();

                    }
                }
            }
        }
    }
}