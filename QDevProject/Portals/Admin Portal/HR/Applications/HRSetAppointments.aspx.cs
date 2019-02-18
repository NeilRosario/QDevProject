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
    public partial class HRSetAppointments : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Helper.GetConnection());
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetAPP, ID
            //GetEmail
            //GEtCompanyName
            //SetUp
            //Receive Session Variables
            ///Tempt if null send back to dashboard,

            int bp = 0;
            string receive_app = null;
            if (receive_app != null)
            {
                receive_app =Request.QueryString["ap"].ToString();
                int pass = Int32.Parse(receive_app);
                int get_apply = get_a_id(pass);
                int job = get_j_id(pass);
                bp = set_b_id(job);
                set_applicant(get_apply);
                set_business_details(bp);
                setTime();
            }
            else
            {

                int pass = 1; //Int32.Parse(receive_app);
                int get_apply = get_a_id(pass);
                int job = get_j_id(pass);
                setAType();
                bp = set_b_id(job);
                set_applicant(get_apply);
                set_business_details(bp);
                setTime();
                //Redirect
            }
        }
        void setAType() {
            List<ListItem> apt_type = new List<ListItem>();
            apt_type.Add(new ListItem("Final Interview", "1"));
            apt_type.Add(new ListItem("Deployment", "2"));
            appointment_type.Items.AddRange(apt_type.ToArray());
        }
        void setDateTimePicker() {
           
        }
        int get_a_id(int a_id) {
            int app_id = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select applicant_id from job_application where application_no=@id",conn);
            cmd.Parameters.AddWithValue("@id",a_id);
            SqlDataReader applicant_id = cmd.ExecuteReader();
            while (applicant_id.Read()) {
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
        void set_applicant(int app_id) {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select a_email, first_name, middle_name, last_name from applicant_basic_info where applicant_id=@aid", conn);
            cmd.Parameters.AddWithValue("@aid", app_id);
            SqlDataReader basic_info = cmd.ExecuteReader();
            while (basic_info.Read()) {
                applicant_name.Text = basic_info.GetString(1)+" "+basic_info.GetString(2)+" "+basic_info.GetString(3);
                a_email.Text =basic_info.GetString(0);
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
            cmd.Parameters.AddWithValue("@aid",bp_id);
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
        int set_b_id(int appID) {
            int business_id = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select b_access_id from job_posting where job_id=@posting_id", conn);
            cmd.Parameters.AddWithValue("@posting_id", appID);
            SqlDataReader bus_id = cmd.ExecuteReader();
            while (bus_id.Read())
            {
                business_id = bus_id.GetInt32(0);
            }
            conn.Close();
            return business_id;
        }
        void sendEmailFinalInterview(string app_email) {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(app_email));
            mail.From = new MailAddress("ron_cardones@live.com.ph", "Appointment", System.Text.Encoding.UTF8);
            mail.Subject = "Final Interview";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
          
            mail.Body = "Congratulations!!!!" + " " +Environment.NewLine+
                "Please see below the details of your  "+ appointment_type.SelectedItem.Text + Environment.NewLine+"Date:" + date_appointment.SelectedDate.ToShortDateString()+
                Environment.NewLine+"Address:"+c_address.Text + Environment.NewLine + "Contact Name:" + contact_name.Text+ Environment.NewLine + "Email:" + c_email.Text+
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
        void log_action(int b_log) {
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
        void setTime() {
            DateTime interviewStart = DateTime.ParseExact("09:00", "HH:mm",null);
            TimeSpan interviewLength = new TimeSpan(1,0,0);
            int office_hours = 0;
            while (office_hours<10) {
                drop_start_time.Items.Add(interviewStart.ToShortTimeString());
                interviewStart = interviewStart.Add(interviewLength);
                office_hours++;
            }

        }
        int checkAvailability(string DateInterview, string TimeInterview) {
            DateTime intDate = Convert.ToDateTime(DateInterview);
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            int dateSet = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select appointment_id from hr_appointments where interview_date=@date_int and interview_start=@time_int", conn);
            cmd.Parameters.AddWithValue("@date_int", intDate);
            cmd.Parameters.AddWithValue("@time_int", TimeInterview);
            SqlDataReader foundTime = cmd.ExecuteReader();
            while (foundTime.Read()) {
                dateSet = 1;
            }
            conn.Close();
            return dateSet;
        }
        void setAppointment(DateTime InterviewDate, string InterviewTime, int b_id, int jid, int aid) {
            //need application no
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            int dateSet = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into hr_appointments (application_no,b_access_id,job_id,applicant_id,app_contact,appointment_type, interview_date,interview_start)values(@app_id,@b_access,@j_id,@appl_id,@contact, @app_type,@d_int, @d_strt)", conn);
            cmd.Parameters.AddWithValue("@app_id",1);
            cmd.Parameters.AddWithValue("@j_id",jid);
            cmd.Parameters.AddWithValue("@appl_id", aid);
            cmd.Parameters.AddWithValue("@contact", contact_name.Text);
            cmd.Parameters.AddWithValue("@app_type", appointment_type.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@b_access",b_id);
            cmd.Parameters.AddWithValue("@d_int", InterviewDate);
            cmd.Parameters.AddWithValue("@d_strt", InterviewTime);
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
        protected void set_appointment_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName=="appointment") {
                DateTime now = DateTime.Now;
                DateTime selected_date = date_appointment.SelectedDate;
                string time = drop_start_time.SelectedItem.ToString();
                DateTime TimeSelected = Convert.ToDateTime(time);
                int result = DateTime.Compare(now,selected_date);
                int available = checkAvailability(date_appointment.SelectedDate.ToShortDateString(),drop_start_time.SelectedItem.ToString());
                if (result < 1 && available==1)
                {
                    
                    int pass = 1; //Int32.Parse(receive_app); Get applicantion no
                    int get_apply = get_a_id(pass);
                    int job = get_j_id(pass);
                    int bp = set_b_id(job);
                    string a_cell = null;//cell number of applicant
                    
                    sendEmailFinalInterview("tenshikage@gmail.com");
                    log_action(bp);
                    setAppointment(selected_date,time, bp, job, get_apply);
                    //set text box for cell phone number below, message
                    itexmo("09063952650", appointment_type.SelectedItem.Text, "TR-RONAN944973_3RLC7 ");
                   

                }
                else {
                    test.Text = "Date Too Early!!";
                }
                   
            }
        }
        //Methods
        //Send Email and Text
    }
}