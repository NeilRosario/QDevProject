using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QDevProject.App_Code;

namespace QDevProject.Portals.Admin_Portal.HR.Applications
{
    public partial class UpdateAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///get Sessions
            if (Session["appt_no"] != null)
            {
                string r_apt = Session["appt_no"].ToString();
                int apt_no = Int32.Parse(r_apt);
                int ap_id = get_a_id(apt_no);
                int job_id = get_j_id(apt_no);
                int b_id = set_b_id(apt_no);
                setTime();
                setDetails(apt_no);
                setAType();
                set_applicant(ap_id);
                set_business_details(b_id);
                app_number.Text = Session["appt_no"].ToString();

                ///set session Variables
            }
            else {
                ///Recdirect
            }
        }
        //Get and set Variables
        //Get Variables to set 
        void setDetails(int pass_app) {
            DateTime dateGiven = new DateTime();
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select app_contact, appointment_type,interview_date, interview_start from hr_appointments where appointment_id=@app_no", conn);
            cmd.Parameters.AddWithValue("@app_no", pass_app);
            SqlDataReader storedApp = cmd.ExecuteReader();
            while (storedApp.Read()) {
                bp_contact.Attributes["placeholder"] = storedApp.GetString(0);
                apt_type.Text = storedApp.GetString(1);
                dateGiven = storedApp.GetDateTime(2);
                apt_date.Text = dateGiven.ToShortDateString();
                app_time.Text = storedApp.GetString(3);
            }
            conn.Close();
        }
        void setAType()
        {
            List<ListItem> apt_type = new List<ListItem>();
            apt_type.Add(new ListItem("Final Interview", "1"));
            apt_type.Add(new ListItem("Deployment", "2"));
            appointment_type.Items.AddRange(apt_type.ToArray());
        }
        void setDateTimePicker()
        {

        }
        int get_a_id(int a_id)
        {
            int app_id = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select applicant_id from hr_appointments where appointment_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", a_id);
            SqlDataReader applicant_id = cmd.ExecuteReader();
            while (applicant_id.Read())
            {
                app_id = applicant_id.GetInt32(0);
            }
            conn.Close();
            return app_id;

        }
        int get_j_id(int a_id)
        {
            int j_id = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select job_id from job_application where application_no=@id", conn);
            cmd.Parameters.AddWithValue("@id", a_id);
            SqlDataReader job_id = cmd.ExecuteReader();
            while (job_id.Read())
            {
                j_id = job_id.GetInt32(0);
            }
            conn.Close();
            return j_id;

        }
        void set_applicant(int app_id)
        {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select a_email, first_name, middle_name, last_name from applicant_basic_info where applicant_id=@aid", conn);
            cmd.Parameters.AddWithValue("@aid", app_id);
            SqlDataReader basic_info = cmd.ExecuteReader();
            while (basic_info.Read())
            {
                applicant_name.Text = basic_info.GetString(1) + " " + basic_info.GetString(2) + " " + basic_info.GetString(3);
                a_email.Text = basic_info.GetString(0);
            }
            //DataReader
            ///DataAdapter
            ///
            conn.Close();
        }
        void set_business_details(int bp_id)
        {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select business_email, company_name,company_address,b_contactno from business_access where b_access_id=@aid", conn);
            cmd.Parameters.AddWithValue("@aid", bp_id);
            SqlDataReader b_info = cmd.ExecuteReader();
            while (b_info.Read())
            {

                c_email.Text = b_info.GetString(0);
                c_address.Text = b_info.GetString(2);
                //c_number.Text = b_info.GetString(3);
            }
            //DataReader
            ///DataAdapter
            ///
            conn.Close();
        }
        int set_b_id(int appID)
        {
            int business_id = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select b_access_id from hr_appointments where appointment_id=@posting_id", conn);
            cmd.Parameters.AddWithValue("@posting_id", appID);
            SqlDataReader bus_id = cmd.ExecuteReader();
            while (bus_id.Read())
            {
                business_id = bus_id.GetInt32(0);
            }
            conn.Close();
            return business_id;
        }
        List<string> updatedDetails(int a_id){
            List<string> detailsReceiver = new List<string>();
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
          
            SqlCommand cmd = new SqlCommand("select app_contact, appointment_type, interview_date, interview_start from hr_appointments where appointment_id=@aid", conn);
            cmd.Parameters.AddWithValue("@aid", a_id);
            SqlDataReader apt_info = cmd.ExecuteReader();
            while(apt_info.Read()){
                detailsReceiver.Add(apt_info.GetString(0));
                detailsReceiver.Add(apt_info.GetString(1));
                DateTime receiveDate = apt_info.GetDateTime(2);
                detailsReceiver.Add(receiveDate.ToShortDateString());
                detailsReceiver.Add(apt_info.GetString(3));
            }
            conn.Close();

            return detailsReceiver;
        }
        void sendEmailFinalInterview(string app_email,int app_no)
        {
            List<string> receiverList = updatedDetails(app_no);
            string[] listDetails = receiverList.ToArray();
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(app_email));
            mail.From = new MailAddress("ron_cardones@live.com.ph", "Appointment", System.Text.Encoding.UTF8);
            mail.Subject = "Final Interview update";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.Body = "HI!!!!" + " " + applicant_name.Text + Environment.NewLine + "Please see your updated details for "+apt_type.Text+"." + Environment.NewLine +
                "Please see below the details of your Final Interview sched" + Environment.NewLine + "Date:" + listDetails[2] + Environment.NewLine+"Time:"+listDetails[3]+
                Environment.NewLine + "Address:" + c_address.Text + Environment.NewLine + "Contact Name:" + listDetails[0] + Environment.NewLine + "Email:" + c_email.Text +
                 Environment.NewLine + "test";
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ron_cardones@live.com.ph", "Fanfiction1985!");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Send(mail);
        }
        void log_action(int b_log)
        {
            string message = "set appointment for" + " " + a_email.Text;
            DateTime date_log = DateTime.Now;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into business_log_file (b_access_id, b_action_type, b_log_date) values (@b_id, @b_action, @d_date)", conn);
            cmd.Parameters.AddWithValue("@b_id", b_log);
            cmd.Parameters.AddWithValue("@b_action", message);
            cmd.Parameters.AddWithValue("@d_date", date_log.ToShortDateString());
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        void setTime()
        {
            DateTime interviewStart = DateTime.ParseExact("09:00", "HH:mm", null);
            TimeSpan interviewLength = new TimeSpan(1, 0, 0);
            if (drop_start_time.Items.Count==0) {
                int office_hours = 0;
                while (office_hours < 10)
                {
                    drop_start_time.Items.Add(interviewStart.ToShortTimeString());
                    interviewStart = interviewStart.Add(interviewLength);
                    office_hours++;
                }
            }
           

        }
        int checkAvailability(string DateInterview, string TimeInterview)
        {
            string r_apt = Session["appt_no"].ToString();
            int apt_no = Int32.Parse(r_apt);
            int ap_id = get_a_id(apt_no);
            int job_id = get_j_id(apt_no);
            int b_id = set_b_id(job_id);
            //AddBusinessId
            DateTime intDate = Convert.ToDateTime(DateInterview);
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            int dateSet = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select appointment_id from hr_appointments where interview_date=@date_int and interview_start=@time_int and b_access_id=@bu_id", conn);
            cmd.Parameters.AddWithValue("@date_int", intDate);
            cmd.Parameters.AddWithValue("@time_int", TimeInterview);
            cmd.Parameters.AddWithValue("@bu_id",b_id);
            SqlDataReader foundTime = cmd.ExecuteReader();
            while (foundTime.Read())
            {
                dateSet = 1;
            }
            conn.Close();
            return dateSet;
        }
        void updateContactName(int appt_id) {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update hr_appointments set app_contact=@nc_name where appointment_id=@apnt_id",conn);
            cmd.Parameters.AddWithValue("@nc_name",bp_contact.Text);
            cmd.Parameters.AddWithValue("@apnt_id",appt_id);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }
        void updateDateTime(int appt_id) {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update hr_appointments set interview_date=@n_date, interview_start=@time where appointment_id=@apnt_id", conn);
            cmd.Parameters.AddWithValue("@n_date", date_appointment.SelectedDate);
            cmd.Parameters.AddWithValue("@time",drop_start_time.Text);
            cmd.Parameters.AddWithValue("@apnt_id", appt_id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        object itexmo(string Number, string Message, string API_CODE)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "https://www.itexmo.com/php_api/api.php";
                parameter.Add("1", Number);
                parameter.Add("2", Message);
                parameter.Add("3", API_CODE);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }

        protected void set_update_Command(object sender, CommandEventArgs e)
        {
            //string app_no = Session["appt_no"].ToString();
            string message = null;
            string chose_date = date_appointment.SelectedDate.Year.ToString();
            if (e.CommandName=="update_appt") {
                if (chose_date!="1") {
                    
                    DateTime now = DateTime.Now;
                    DateTime selected_date = date_appointment.SelectedDate;
                    string time = drop_start_time.SelectedItem.ToString();
                    DateTime TimeSelected = Convert.ToDateTime(time);
                    int time_check = DateTime.Compare(now, selected_date);
                    int checkA = checkAvailability(date_appointment.SelectedDate.ToShortDateString(), drop_start_time.SelectedItem.Text);
                    //Validation for availability of date and time
                    //Check if there is a need to update it.
                    if (checkA == 0 && time_check < 1)
                    {
                        string r_id = app_number.Text.ToString();
                        updateDateTime(Int32.Parse(r_id));
                        message = message + "Date and Time Updated!! ";
                       
                    }
                    else {
                        message = "Incorrect Date, Either date and time is already in use or it is too early.";
                    }
   
                }
               
                if (bp_contact.Text.Length>0) {
                    string rr_id = app_number.Text;
                    updateContactName(Int32.Parse(rr_id));
                    message = message + "Contact Name Updated";
                }
                
                if (message==null) {
                    test.Text = "Nothing Changed!!";
                }
                else {
                    test.Text = message;
                    string r_id = app_number.Text.ToString();
                    sendEmailFinalInterview("tenshikage@gmail.com", Int32.Parse(r_id));
                    //Feed Number from system
                    string number = "09987944973";//"09063952650";
                    itexmo(number, apt_type.Text, "TR-RONAN944973_3RLC7 ");
                    test.Text = message;
                }
                
            }
        }
    }
}