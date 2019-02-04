using RecruitMe.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecruitMe.HRApp_process
{
    public partial class HRViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get cookieto verify identity.
            /**
            if (HttpContext.Current.Application["view_id"] != null) {
                string receive_id = HttpContext.Current.Application["view_id"].ToString();
                int app_id = Int32.Parse(receive_id);
            }
            get_applicant(1);
            set_contact_details(1);
           **/
            int ValuePass = 0;
            if (Request.QueryString["id"] != null)
            {
                ValuePass = Int32.Parse(Request.QueryString["id"]);
                int getId = a_id(ValuePass);
                get_applicant(ValuePass);
                set_contact_details(getId);
                test_command.Text = ValuePass.ToString();
                get_applicant(ValuePass);
                set_contact_details(getId);
            }
        }
        int a_id(int received_app_id) {
            int x = 0;
            using (SqlConnection con = new SqlConnection(Helper.GetConnection())) {
                con.Open();
                SqlCommand cmd = new SqlCommand("select applicant_id from job_application where job_id=@ap_id", con);
                cmd.Parameters.AddWithValue("@ap_id", received_app_id);
                SqlDataReader specific_applicant = cmd.ExecuteReader();
                while (specific_applicant.Read()) {
                    x = specific_applicant.GetInt32(0);
                }
                
                con.Close();
            }
            return x;
        }
        void get_applicant(int y) {
            //get_applicant
            int r_app_id = a_id(y);
            using (SqlConnection con = new SqlConnection(Helper.GetConnection())) {
                con.Open();
                SqlCommand cmd = new SqlCommand("select first_name, middle_name,last_name, date_of_birth,a_email, gender from applicant_basic_info where applicant_id=@id", con);
                cmd.Parameters.AddWithValue("@id", y);
                SqlDataAdapter id_details = new SqlDataAdapter(cmd);
                DataSet data_gathered = new DataSet();
                id_details.Fill(data_gathered);
                applicant_details.DataSource = data_gathered;
                applicant_details.DataBind();
                con.Close();
            }
        }
        void set_contact_details(int alpha)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select home_phone,mobile_number,alternate_mobile from applicant_contact_details where applicant_id=@a_id", con);
                cmd.Parameters.AddWithValue("@a_id",alpha);
                SqlDataAdapter contact = new SqlDataAdapter(cmd);
                DataSet contacts = new DataSet();
                contact.Fill(contacts);
                contact_details.DataSource = contacts;
                contact_details.DataBind();
                con.Close();
            }
        }
        void set_education(int zeta) {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select educational_attainment.school_name,educational_attainment.educational_attainment,educational_attainment.date_graduated, educational_course.course_name from(educational_attainment INNER JOIN educational_course on educational_attainment.course_id=educational_course.course_id and educational_attainment.applicant_id=@app_id)", con);
                cmd.Parameters.AddWithValue("@app_id",zeta);
                SqlDataAdapter education = new SqlDataAdapter(cmd);
                DataSet data_education = new DataSet();
                education.Fill(data_education);
                education_status.DataSource = data_education;
                education_status.DataBind();
                con.Close();
            }
        }
        void get_extra(int beta) {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                SqlDataAdapter extra_activities = new SqlDataAdapter(cmd);
                DataSet data_extra = new DataSet();
                extra_activities.Fill(data_extra);
                con.Close();
                con.Close();
            }
        }
        protected void file_download_Click(object sender, EventArgs e)
        {
            //Place EXACT file path of document
            //string filePath = @"C:\Users\Ron Cardones\Documents\Visual Studio 2017\Projects\RecruitMe\RecruitMe\logs\applicant_log.txt";
            string filePath = @"";
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void return_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("HRProcessApp.aspx");
        }
    }
}