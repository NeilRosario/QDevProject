using QDevProject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QDevProject.Extras
{
    public partial class forgotten_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void changePassword(string email) {
            string message_after = "An Email has been sent with your new random password. Please log in and change the password.";
            int app_id =app_db_check(email);
            int bp_id=bp_db_check(email);
            string npass=complete_password();
            if (app_id > 0) {
                app_change_password(email,npass);
            } else if (bp_id>0) {
                bp_change_password(email,npass);
            }
            //password_recovery change_password = new password_recovery();
            /**
            string new_pass = change_password.random_password();
            int x = change_password.bp_db_check(user_email.ToString());
            int i = change_password.app_db_check(user_email.ToString());
            if (x > 0)
            {
                change_password.bp_change_password(user_email.ToString(), new_pass);
                message.InnerText = message_after;
                change_password.recovery_confirmation(user_email.ToString(), new_pass);
            }
            else if (i > 0)
            {
                change_password.app_change_password(user_email.ToString(), new_pass);
                change_password.recovery_confirmation(user_email.ToString(), new_pass);
                message.InnerText = message_after;
            }
            else
            {
                message.InnerText = i.ToString();
            }**/
        }
        public int app_db_check(string email_provided)
        {
            int x = 0;
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select applicant_id from applicant_basic_info where a_email=@email", conn);
            cmd.Parameters.AddWithValue("@email", email_provided);
            SqlDataReader results = cmd.ExecuteReader();
            while (results.Read())
            {
                x = results.GetInt32(0);
            }
            return x;
        }
        public int bp_db_check(string email_provided)
        {
            int y = 0;
           
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select b_access_id from business_access where business_email=@email", conn);
            cmd.Parameters.AddWithValue("@email", email_provided);
            SqlDataReader results = cmd.ExecuteReader();
            while (results.Read())
            {
                y = results.GetInt32(0);
            }
            conn.Dispose();
            conn.Close();
            return y;
        }
        //Change password
        public void app_change_password(string email_provided, string new_password)
        {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update applicant_basic_info set a_password=@rndm where a_email=@amail",conn);
            cmd.Parameters.AddWithValue("@amail",email_provided);
            cmd.Parameters.AddWithValue("@rndm",new_password);
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
        public void bp_change_password(string email_provided, string new_password)
        {
            SqlConnection conn = new SqlConnection(Helper.GetConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update business_access set business_password=@rndm where business_email=@bmail",conn);
            cmd.Parameters.AddWithValue("@bmail", email_provided);
            cmd.Parameters.AddWithValue("@rndm", new_password);
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
        public void app_log() { }
        public void bp_log() { }
        public int position(int length)
        {
            return new Random().Next(0, length);
        }
        public string random_password()
        {

            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = alphabets + small_alphabets + numbers;
            string new_password = null;
            int char_position = 0;
            Random random = new Random();
            int i = 0;
            for (int x = 0; x < 15; x++)
            {
                char_position = random.Next(0, characters.Length);
                string selected_item = characters.ToCharArray()[char_position].ToString();
                new_password = new_password + selected_item;

            }
            return new_password;
        }
        public string complete_password()
        {
            string selected_password = null;
            for (int x = 0; x < 1; x++)
            {
                selected_password = selected_password + random_password();
            }
            return selected_password;
        }
        protected void system_check_Click(object sender, EventArgs e)
        {
            changePassword(current_email.Text);
            
            
        }
    }
}