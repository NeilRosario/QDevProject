using QDevProject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QDevProject
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        void LogInApplicant()

        {
            using (SqlConnection Con = new SqlConnection(Helper.GetConnection()))
            {
                //Util audlog = new Util();
                //Cryptic DE = new Cryptic();
                Con.Open();

                string SQL = @"SELECT applicant_id, access_type_id, a_email, a_password, first_name,  middle_name, last_name 
                                 FROM applicant_basic_info
                                 WHERE a_email=@a_email AND a_password=@a_password";
                using (SqlCommand cmd = new SqlCommand(SQL, Con))
                {
                    cmd.Parameters.AddWithValue("@a_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@a_password", txtPassword.Text);

                    using (SqlDataReader Data = cmd.ExecuteReader())
                    {
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                Session["applicant_id"] = Data["applicant_id"].ToString();
                                Session["first_name"] = Data["first_name"].ToString();
                                Session["middle_name"] = Data["middle_name"].ToString();
                                Session["last_name"] = Data["last_name"].ToString();
                                Session["a_email"] = Data["a_email"].ToString();
                                Session["access_type_id"] = Data["access_type_id"].ToString();


                            }

                            ////Audit Log of Session ID
                            //audlog.AuditLogAdmin(DE.Encrypt("Student Log-In"), int.Parse(Session["user_id"].ToString()), DE.Encrypt("Logged-In by Student "
                            //    + Session["First_Name"].ToString() + " " + Session["Middle_Name"].ToString() + " " + Session["Last_Name"].ToString()));

                            // Log In Redirect for Applicant 
                            // If UserType = 1 -> Redirect to Applicant Portal
                            if (Session["access_type_id"].ToString() == "1")
                            {
                                Response.Redirect("~/Portals/Applicant Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "2")
                            {
                                Response.Redirect("~/Portals/BP Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "3")
                            {
                                Response.Redirect("~/Portals/Admin Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "4")
                            {
                                Response.Redirect("~/Portals/HR Portal/Home.aspx");
                            }

                        }

                        else

                            error.Visible = true;

                    }
                }
            }
        }


        void LogInBP()

        {
            using (SqlConnection Con = new SqlConnection(Helper.GetConnection()))
            {
                //Util audlog = new Util();
                //Cryptic DE = new Cryptic();
                Con.Open();

                string SQL = @"SELECT b_access_id, access_type_id, business_email, business_password, 
                                    company_name, company_address FROM business_access
                                 WHERE business_email=@business_email AND business_password=@business_password";
                using (SqlCommand cmd = new SqlCommand(SQL, Con))
                {
                    cmd.Parameters.AddWithValue("@business_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@business_password", txtPassword.Text);

                    using (SqlDataReader Data = cmd.ExecuteReader())
                    {
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                Session["b_access_id"] = Data["b_access_id"].ToString();
                                Session["company_name"] = Data["company_name"].ToString();
                                Session["company_address"] = Data["company_address"].ToString();


                                Session["business_email"] = Data["business_email"].ToString();
                                Session["access_type_id"] = Data["access_type_id"].ToString();


                            }

                            ////Audit Log of Session ID
                            //audlog.AuditLogAdmin(DE.Encrypt("Student Log-In"), int.Parse(Session["user_id"].ToString()), DE.Encrypt("Logged-In by Student "
                            //    + Session["First_Name"].ToString() + " " + Session["Middle_Name"].ToString() + " " + Session["Last_Name"].ToString()));

                            // Log In Redirect for Applicant 
                            // If UserType = 2 -> Redirect to BP Portal
                            if (Session["access_type_id"].ToString() == "1")
                            {
                                Response.Redirect("~/Portals/Applicant Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "2" && Session["company_address"].ToString() == "Empty")
                            {


                                Response.Redirect("~/Portals/BP Portal/Profile/CreateProfilePrompt.aspx");

                                
                            }
                            else if (Session["access_type_id"].ToString() == "2" && Session["company_address"].ToString() != "Empty")
                            {


                                Response.Redirect("~/Portals/BP Portal/Home.aspx");


                            }
                            else if (Session["access_type_id"].ToString() == "3")
                            {
                                Response.Redirect("~/Portals/Admin Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "4")
                            {
                                Response.Redirect("~/Portals/HR Portal/Home.aspx");
                            }

                        }

                        else

                            error.Visible = true;

                    }
                }
            }
        }


        void LogInAdmin()

        {
            using (SqlConnection Con = new SqlConnection(Helper.GetConnection()))
            {
                //Util audlog = new Util();
                //Cryptic DE = new Cryptic();
                Con.Open();

                string SQL = @"SELECT admin_id, access_type_id, admin_email, admin_PW, first_name, middle_name, last_name
                                 FROM admin_details
                                 WHERE admin_email=@admin_email AND admin_PW=@admin_PW";
                using (SqlCommand cmd = new SqlCommand(SQL, Con))
                {
                    cmd.Parameters.AddWithValue("@admin_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@admin_PW", txtPassword.Text);

                    using (SqlDataReader Data = cmd.ExecuteReader())
                    {
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                Session["admin_id"] = Data["admin_id"].ToString();
                                Session["first_name"] = Data["first_name"].ToString();
                                Session["middle_name"] = Data["middle_name"].ToString();
                                Session["last_name"] = Data["last_name"].ToString();
                                Session["admin_email"] = Data["admin_email"].ToString();
                                Session["access_type_id"] = Data["access_type_id"].ToString();


                            }

                            ////Audit Log of Session ID
                            //audlog.AuditLogAdmin(DE.Encrypt("Student Log-In"), int.Parse(Session["user_id"].ToString()), DE.Encrypt("Logged-In by Student "
                            //    + Session["First_Name"].ToString() + " " + Session["Middle_Name"].ToString() + " " + Session["Last_Name"].ToString()));

                            // Log In Redirect for Applicant 
                            // If UserType = 3 -> Redirect to Admin Portal
                            if (Session["access_type_id"].ToString() == "1")
                            {
                                Response.Redirect("~/Portals/Applicant Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "2")
                            {
                                Response.Redirect("~/Portals/BP Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "3")
                            {
                                Response.Redirect("~/Portals/Admin Portal/Admin/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "4")
                            {
                                Response.Redirect("~/Portals/Admin Portal/HR/Home.aspx");
                            }

                        }

                        else

                            error.Visible = true;

                    }
                }
            }
        }

        void LogInHR()

        {
            using (SqlConnection Con = new SqlConnection(Helper.GetConnection()))
            {
                //Util audlog = new Util();
                //Cryptic DE = new Cryptic();
                Con.Open();

                string SQL = @"SELECT admin_id, access_type_id, admin_email, admin_PW, first_name, middle_name, last_name
                                 FROM admin_details
                                 WHERE admin_email=@admin_email AND admin_PW=@admin_PW";
                using (SqlCommand cmd = new SqlCommand(SQL, Con))
                {
                    cmd.Parameters.AddWithValue("@admin_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@admin_PW", txtPassword.Text);

                    using (SqlDataReader Data = cmd.ExecuteReader())
                    {
                        if (Data.HasRows)
                        {
                            while (Data.Read())
                            {
                                Session["admin_id"] = Data["admin_id"].ToString();
                                Session["first_name"] = Data["first_name"].ToString();
                                Session["middle_name"] = Data["middle_name"].ToString();
                                Session["last_name"] = Data["last_name"].ToString();
                                Session["admin_email"] = Data["admin_email"].ToString();
                                Session["access_type_id"] = Data["access_type_id"].ToString();


                            }

                            ////Audit Log of Session ID
                            //audlog.AuditLogAdmin(DE.Encrypt("Student Log-In"), int.Parse(Session["user_id"].ToString()), DE.Encrypt("Logged-In by Student "
                            //    + Session["First_Name"].ToString() + " " + Session["Middle_Name"].ToString() + " " + Session["Last_Name"].ToString()));

                            // Log In Redirect for Applicant 
                            // If UserType = 4 -> Redirect to HR Portal
                            if (Session["access_type_id"].ToString() == "1")
                            {
                                Response.Redirect("~/Portals/Applicant Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "2")
                            {
                                Response.Redirect("~/Portals/BP Portal/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "3")
                            {
                                Response.Redirect("~/Portals/Admin Portal/Admin/Home.aspx");
                            }
                            else if (Session["access_type_id"].ToString() == "4")
                            {
                                Response.Redirect("~/Portals/Admin Portal/HR/Home.aspx");
                            }

                        }

                        else

                            error.Visible = true;

                    }
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {


            LogInApplicant();
            LogInBP();
            LogInAdmin();
            LogInHR();



        }
    }
}