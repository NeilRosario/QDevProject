using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QDevProject.App_Code;

namespace QDevProject.Portals.Admin_Portal.HR.Applications
{
    public partial class HRViewAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///Get job_application id
            getAppointments();
        }
        void getAppointments() {
            SqlConnection con = new SqlConnection(Helper.GetConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("select hr_appointments.appointment_id,hr_appointments.app_contact, hr_appointments.appointment_type,applicant_basic_info.first_name, applicant_basic_info.last_name, business_access.company_name,job_posting.job_title, hr_appointments.interview_date, hr_appointments.interview_start from (((hr_appointments inner join job_application on hr_appointments.application_no=job_application.application_no)inner join business_access on business_access.b_access_id=hr_appointments.b_access_id)inner join job_posting on hr_appointments.job_id=job_posting.job_id)inner join applicant_basic_info on hr_appointments.applicant_id=applicant_basic_info.applicant_id", con);
            SqlDataAdapter setAppoint = new SqlDataAdapter(cmd);
            DataSet appointData = new DataSet();
            setAppoint.Fill(appointData);
            appointments_list.DataSource = appointData;
            appointments_list.DataBind();
            con.Close();
        }


        protected void updateAppoinment_Command(object sender, CommandEventArgs e)
        {
            
            if (e.CommandName=="update") {
                Session["appt_no"]=e.CommandArgument.ToString();
                Response.Redirect("UpdateAppointments.aspx");
            }
        }

        protected void appointments_list_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem data = (ListViewDataItem)e.Item;
           
        }
    }
}