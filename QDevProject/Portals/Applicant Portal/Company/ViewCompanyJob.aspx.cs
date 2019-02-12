using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QDevProject.App_Code;

namespace QDevProject.Portals.Applicant_Portal.Company
{
    public partial class ViewCompanyJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("ViewCompanyList.aspx");
            }
            else
            {
                int jobid = 0;
                bool validjobid = int.TryParse(Request.QueryString["ID"].ToString(), out jobid);

                if (validjobid)
                {
                    if (!IsPostBack)
                    {
                        getJobID(jobid);
                        ViewJobs(jobid);
                    }
                }
                else
                {
                    Response.Redirect("ViewCompanyList.aspx");
                }
            }
        }
        void getJobID(int ID)
        { using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                string cmd = @"SELECT b_access_id, company_name from business_access WHERE b_access_id=@BID";
                con.Open();
                using (SqlCommand com = new SqlCommand(cmd, con))
                {
                    com.Parameters.AddWithValue("@BID", ID);

                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ltCompID.Text = dr["company_name"].ToString();
                            }
                        }
                        else
                        {
                            Response.Redirect("ViewCompanyList.aspx");
                        }
                    }
                }
            }

        }

        void ViewJobs(int ID)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection())) {

                con.Open();
                string cmd = @"SELECT j.job_id, j.job_title, s.Description, j.job_description, 
                            j.job_monthly_salary FROM job_posting j 
                            INNER JOIN job_post_status s 
                            ON j.job_post_status_id = s.job_post_status_id WHERE 
                            j.b_access_id=@BID";

                using (SqlCommand com = new SqlCommand(cmd, con)) {
                    com.Parameters.AddWithValue("@BID", ID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(com))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "job_posting");
                        lvComp.DataSource = ds;
                        lvComp.DataBind();

                    }
                }
            }
        }
        protected void lvComp_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            Literal ltJobID = (Literal)e.Item.FindControl("ltJobID");

            if (e.CommandName == "sendapplication")
            {
                
                using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                {
                    con.Open();
                    string SQL = @"INSERT INTO job_application (job_id, applicant_id, status_id, date_applied)
                                   VALUES (@JID, @AID, @SID, @DateApplied)";

                    using (SqlCommand cmd = new SqlCommand(SQL, con))
                    {
                        cmd.Parameters.AddWithValue("@JID", ltJobID.Text);
                        cmd.Parameters.AddWithValue("@AID", Session["applicant_id"].ToString());
                        cmd.Parameters.AddWithValue("@SID", 1);
                        cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                        cmd.ExecuteNonQuery();

                        Response.Redirect("ViewCompanyJob.aspx");
                    }
                }
            }


        }

    }
}