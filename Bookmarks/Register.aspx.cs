using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool valid = true;

                String _FirstName = firstname.Text;
                String _Name = name.Text;
                String _Email = email.Text;
                String _Username = username.Text;
                String _Password = password.Text;
                String _PasswordCon = passwordcon.Text;

                if (_FirstName == "")
                {
                    valid = false;
                    EroarePrenume.Text = "Error: Name cannot be blank!";
                    //Response.Write("Error: Name cannot be blank!");
                }

                if (_Name == "")
                {
                    valid = false;
                    EroareNume.Text = "Error: Name cannot be blank!";
                    //Response.Write("Error: Name cannot be blank!");
                }

                if (_Email == "")
                {
                    valid = false;
                    EroareEmail.Text = "Error: Email cannot be blank!";

                }

                if (_Username == "")
                {
                    valid = false;
                    EroareUsername.Text = "Error: Username cannot be blank!";
                }

                if (_Password == "")
                {
                    valid = false;
                    EroareParola.Text = "Error: Password cannot be blank!";
                }

                if (_PasswordCon == "")
                {
                    valid = false;
                    EroareConfirmareParola.Text = "Error: Confirm Password cannot be blank!";
                }

                if (_PasswordCon != _Password)
                {
                    valid = false;
                    EroareConfirmareParola.Text = "Error: Passwords are not the same!";
                }

                if (valid)
                {
                    string query = "INSERT INTO Users(firstName, lastName, email, registerDate, userName, passWord) OUTPUT INSERTED.userId "
                   + " VALUES (@firstname, @lastname, @email, @registerDate, @userName, @passWord)";
                    DateTime _localDate = DateTime.Now;
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\source\repos\Bookmarks\Bookmarks\App_Data\Database.mdf;Integrated Security=True
                    //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");

                    try
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        com.Parameters.AddWithValue("firstname", _FirstName);
                        com.Parameters.AddWithValue("lastname", _Name);
                        com.Parameters.AddWithValue("email", _Email);
                        com.Parameters.AddWithValue("registerDate", _localDate.GetDateTimeFormats()[3]);
                        com.Parameters.AddWithValue("userName", _Username);
                        com.Parameters.AddWithValue("passWord", _Password);

                        int id = (int)com.ExecuteScalar();

                        if (id > 0)
                        {
                            EroareBazaDate.Text = "Account created successfully!";
                        }
                        else
                        {
                            EroareBazaDate.Text = "Error while creating account!";
                        }

                    }
                    catch (Exception ex)
                    {
                        EroareBazaDate.Text = "Error while creating account: " + ex.Message;
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