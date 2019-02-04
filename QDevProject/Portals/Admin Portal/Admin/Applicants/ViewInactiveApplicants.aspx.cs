using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QDevProject.App_Code;


namespace QDevProject.Portals.Admin_Portal.Admin.Applicants
{
    public partial class ViewInactiveApplicants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetActiveApplicants();
            }
        }

        void GetActiveApplicants()
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string cmd = @"SELECT applicant_id, a_email, last_name + ', ' + first_name + ' ' + middle_name AS 'Full Name', date_of_birth, gender FROM applicant_basic_info where user_statusid !=1 ";

                using (SqlCommand com = new SqlCommand(cmd, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(com))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "applicant_basic_info");
                        lvApplicant.DataSource = ds;
                        lvApplicant.DataBind();

                    }
                }

            }
        }
        protected void lvApplicant_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dpApplicants.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            GetActiveApplicants();
        }
    }
}