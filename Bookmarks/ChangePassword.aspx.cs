using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal1.Text = "";
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
            try
            {
                var userName = (string)(Session["currentUserName"]);
                con.Open();
                string query = "Select * from Users where userName = @user";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("user", userName);
                using (SqlDataReader myReader = com.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        var id = myReader["userId"];
                        string passWord = (string)myReader["passWord"];

                        if (passWord.Trim().Equals(oldPassWord.Text.Trim()) == false || newPassWord.Text.Trim().Equals(confirmNewPassWord.Text.Trim()) == false )
                        {
                            Literal1.Text = "Incorect Password";
                        }
                        else
                        {
                            SqlConnection updateConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
                            updateConnection.Open();
                            string updateQuery = "UPDATE Users set passWord = @pass where userId = @id ";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection);
                            updateCommand.Parameters.AddWithValue("pass", newPassWord.Text);
                            updateCommand.Parameters.AddWithValue("id", id);
                            updateCommand.ExecuteNonQuery();
                            FinishUpdate.InnerText = "Password succesfully updated";
                            updateConnection.Close();
                        }
                        //TO DO TEST FOR PASSWORD CHECK

                    }
                }
            }
            catch (Exception ex)
            {
                Literal1.Text = ex.Message;
            }




        }
    }
}