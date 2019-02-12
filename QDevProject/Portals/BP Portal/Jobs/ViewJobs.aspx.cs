using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using QDevProject.App_Code;

namespace QDevProject.Portals.BP_Portal.Jobs
{
    public partial class ViewJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetJobs();
            }
        }


        void GetJobs()
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string cmd = @"SELECT j.job_id, a.description, j.job_title, j.job_description, j.job_monthly_salary, j.date_submitted, j.posting_start, j.posting_end
                               FROM job_posting j 
                               INNER JOIN approval_request a
                               
                               ON j.approval_id = a.approval_id 
							   WHERE j.job_post_status_id!=2 AND j.b_access_id=@BID";

                using (SqlCommand com = new SqlCommand(cmd, con))
                {
                    com.Parameters.AddWithValue("@BID", Session["b_access_id"].ToString());
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

            if (e.CommandName == "deljob")
            {
                using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                {
                    con.Open();
                    string DELETE = @"DELETE FROM job_posting WHERE job_id=@job_id";
                    using (SqlCommand Nero = new SqlCommand(DELETE, con))
                    {
                        Nero.Parameters.AddWithValue("@job_id", ltJobID.Text);
                        Nero.ExecuteNonQuery();
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