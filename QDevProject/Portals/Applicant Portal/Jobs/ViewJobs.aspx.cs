using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using QDevProject.App_Code;

namespace QDevProject.Portals.Applicant_Portal.Jobs
{
    public partial class ViewJobs : System.Web.UI.Page
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
                string cmd = @"SELECT j.job_id, b.company_name, a.description, j.job_title, j.job_description, j.job_monthly_salary, j.date_submitted
                                   FROM job_posting j 
                                   INNER JOIN approval_request a 
                                   ON j.approval_id = a.approval_id 
							       INNER JOIN business_access b 
							       ON j.b_access_id = b.b_access_id 
							       WHERE j.job_post_status_id!=2";


                using (SqlCommand com = new SqlCommand(cmd, con))
                {
                    
                    using (SqlDataAdapter sda = new SqlDataAdapter(com))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "job_posting");

                        lvJobs.DataSource = ds;
                        lvJobs.DataBind();

                    }
                }
            }
        }

        protected void lvJobs_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            Literal ltJobID = (Literal)e.Item.FindControl("ltJobID");

            if (e.CommandName == "sendapplication")
            {
                using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                {
                    string SQL = @"INSERT INTO job_application (job_id, applicant_id, status_id, date_applied)
                                   VALUES (@JID, @AID, @SID, @DateApplied)";

                    using (SqlCommand cmd = new SqlCommand(SQL, con))
                    {
                        cmd.Parameters.AddWithValue("@JID", ltJobID.Text);
                        cmd.Parameters.AddWithValue("@AID", Session["applicant_id"].ToString());
                        cmd.Parameters.AddWithValue("@SID", 1);
                        cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                        cmd.ExecuteNonQuery();

                        Response.Redirect("ViewJobs.aspx");
                    }
                }
            }


        }



        

        protected void lvJobs_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dpJobs.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            GetJobs();
        }
    }
}