using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True");

                int currentUserId = (int)Session["currentUserId"];
                String currentFirstName;
                String currentLastName;
                String currentEmail;
                String currentUsername;

                try
                {
                    con.Open();
                    string query = "Select * from Users where userId = @currentUserId";
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("currentUserId", currentUserId);

                    using (SqlDataReader myReader = com.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            currentFirstName = myReader["firstName"].ToString();
                            editfirstname.Text = currentFirstName;
                            currentLastName = myReader["lastName"].ToString();
                            editname.Text = currentLastName;
                            currentEmail = myReader["email"].ToString();
                            editemail.Text = currentEmail;
                            currentUsername = myReader["userName"].ToString();
                            editusername.Text = currentUsername;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool valid = true;
                String _NewFirstName = editfirstname.Text;
                String _NewLastName = editname.Text;
                String _NewEmail = editemail.Text;
                String _NewUsername = editusername.Text;

                int currentUserId = (int)Session["currentUserId"];

                if (_NewFirstName == "")
                {
                    valid = false;
                    EroarePrenume.Text = "Error: Name cannot be blank!";
                    //Response.Write("Error: Name cannot be blank!");
                }

                if (_NewLastName == "")
                {
                    valid = false;
                    EroareNume.Text = "Error: Name cannot be blank!";
                    //Response.Write("Error: Name cannot be blank!");
                }

                if (_NewEmail == "")
                {
                    valid = false;
                    EroareEmail.Text = "Error: Email cannot be blank!";

                }

                if (_NewUsername == "")
                {
                    valid = false;
                    EroareUsername.Text = "Error: Username cannot be blank!";
                }


                if (valid)
                {
                    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True");
                    string query = "UPDATE Users SET firstName = @firstName, lastName = @lastName, email = @email, userName = @userName WHERE userId = @currentUserId";

                    try
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        com.Parameters.AddWithValue("firstName", _NewFirstName);
                        com.Parameters.AddWithValue("lastName", _NewLastName);
                        com.Parameters.AddWithValue("email", _NewEmail);
                        com.Parameters.AddWithValue("userName", _NewUsername);
                        com.Parameters.AddWithValue("currentUserId", currentUserId);

                        com.ExecuteNonQuery();

                        Session["currentName"] = _NewFirstName;
                        Session["currentUserName"] = _NewUsername;
                        Session["currentUserId"] = currentUserId;
                        Response.Redirect("MainMenu.aspx");
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}