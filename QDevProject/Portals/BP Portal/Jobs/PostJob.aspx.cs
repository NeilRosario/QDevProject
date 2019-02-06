using QDevProject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QDevProject.Portals.BP_Portal.Jobs
{
    public partial class PostJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();

                string sql = "INSERT INTO job_posting(approval_id, job_post_status_id, b_access_id, " +
                    "job_title, job_description, job_monthly_salary, " +
                    "date_submitted, posting_start, posting_end)" +
                    "VALUES (@AID, @JobStatus, @BID, @txtJobTitle, " +
                    "@txtJobDesc, @txtMonthlySalary, @txtDateSubmit, " +
                    "@txtPostStart, @txtPostEnd)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AID", 3);
                    cmd.Parameters.AddWithValue("@JobStatus", 1);
                    cmd.Parameters.AddWithValue("@BID", Session["b_access_id"].ToString());

                    
                    cmd.Parameters.AddWithValue("@txtJobTitle", txtJobTitle.Text);
                    cmd.Parameters.AddWithValue("@txtJobDesc", txtJobDesc.Text);
                    cmd.Parameters.AddWithValue("@txtMonthlySalary", txtMonthlySalary.Text);
                        
                    cmd.Parameters.AddWithValue("@txtDateSubmit", DateTime.Now);
                    cmd.Parameters.AddWithValue("@txtPostStart", txtPostStart.Text);
                    cmd.Parameters.AddWithValue("@txtPostEnd", txtPostEnd.Text);
                    cmd.ExecuteNonQuery();

                    Response.Redirect("~/Portals/BP Portal/Home.aspx");

                }

            }

        }
    }
}