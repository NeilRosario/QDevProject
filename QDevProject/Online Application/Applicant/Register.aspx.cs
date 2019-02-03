using QDevProject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QDevProject.Online_Application.Applicant
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void btnApply_Click(object sender, EventArgs e)
        {

            using (SqlConnection Con = new SqlConnection(Helper.GetConnection()))
            {

                Con.Open();

                // Verifies if Email is Existing.
                bool exists = false;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM applicant_basic_info WHERE a_email = @email", Con))
                {
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }

                // If email already exists
                // Error Code will be shown
                // test
                if (exists)
                {
                    error.Visible = true;
                }

                //Else the registration will continue.
                else
                {
                    string SQL = @"INSERT INTO applicant_basic_info (access_type_id, a_email, a_password, first_name, middle_name, last_name, 
                                                        date_of_birth, gender, applicant_cv)

                                              VALUES (@access_type_id, @a_email, @a_password, @first_name, @middle_name, @last_name, 
                                                      @date_of_birth, @gender, @applicant_cv)";

                    using (SqlCommand cmd = new SqlCommand(SQL, Con))
                    {
                        cmd.Parameters.AddWithValue("@access_type_id", 1);

                        cmd.Parameters.AddWithValue("@a_email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@a_password", txtPW.Text);


                        cmd.Parameters.AddWithValue("@first_name", txtFN.Text);
                        cmd.Parameters.AddWithValue("@middle_name", txtMN.Text);
                        cmd.Parameters.AddWithValue("@last_name", txtLN.Text);

                        cmd.Parameters.AddWithValue("@date_of_birth", txtBirthDate.Text);
                        cmd.Parameters.AddWithValue("@gender", DropDownList7.SelectedItem.Value);

                        string fileExt = Path.GetExtension(FileContent.FileName);
                        string id = Guid.NewGuid().ToString();
                        cmd.Parameters.AddWithValue("@applicant_cv", id + fileExt);
                        FileContent.SaveAs(Server.MapPath("~/Files/CV/" + id + fileExt));

                        cmd.ExecuteNonQuery();

                        Response.Redirect("Default.aspx");

                    }
                }


            }
        }
    }
}