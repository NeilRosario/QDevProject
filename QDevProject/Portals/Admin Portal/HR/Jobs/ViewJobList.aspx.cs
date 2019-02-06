using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QDevProject.App_Code;

namespace QDevProject.Portals.Admin_Portal.HR.Jobs
{
    public partial class ViewJobList : System.Web.UI.Page
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
                string cmd = @"SELECT  c.company_name, a.description, j.job_title, j.job_description, j.job_monthly_salary, j.date_submitted" +
                              "  FROM job_posting j INNER JOIN approval_request a ON j.approval_id = a.approval_id " +
                              "INNER JOIN business_access c ON j.b_access_id = c.b_access_id WHERE j.job_post_status_id!=2";


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

            if (e.CommandName == "acceptapp")
            {
                using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                {
                    string SQL = @"UPDATE job_posting SET approval_id=@AID";

                    using (SqlCommand cmd = new SqlCommand(SQL, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@AID", 1);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("ViewJobList.aspx");
                    }
                }
            }

            else if (e.CommandName == "rejectapp")
            {
                using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                {
                    string SQL = @"UPDATE job_posting SET approval_id=@AID";

                    using (SqlCommand cmd = new SqlCommand(SQL, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@AID", 2);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("ViewJobList.aspx");
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