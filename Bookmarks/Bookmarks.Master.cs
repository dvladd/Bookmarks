using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class Bookmarks : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void OnLogInClock(object sender, EventArgs e)
        {         
           //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
            try
            {
                con.Open();
                string query = "SELECT * FROM Users WHERE email = @email AND passWord = @pass";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("email", email.Value);
                com.Parameters.AddWithValue("pass", password.Value);
                //com.Parameters.AddWithValue("lastname", _Name);
                string currentName = "";
                string currentUserName = "";
                int currentUserId = -1;
                using (SqlDataReader myReader = com.ExecuteReader())
                {
                    while(myReader.Read())
                    {
                        currentName = myReader["firstName"].ToString();
                        currentUserName = myReader["userName"].ToString();
                        currentUserId = (int)myReader["userId"];
                    }
                }

                Session["currentName"] = currentName;
                Session["currentUserName"] = currentUserName;
                Session["currentUserId"] = currentUserId;


                    //  SqlDataReader reader = com.ExecuteReader();
                    int id = (int)com.ExecuteScalar();

                

                if (com.ExecuteScalar() != null)
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

        protected void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}