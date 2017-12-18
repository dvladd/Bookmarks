using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class SearchElements : System.Web.UI.Page
    {
        Button specialButton = new Button();
        protected void Page_Load(object sender, EventArgs e)
        {
            roww1.Controls.Clear();
            MostVotedBooksAndLatestBooksAdd("timesClicked", "MostViewd");
            MostVotedBooksAndLatestBooksAdd("addedTime", "Latest");


            string searchBy = (string)Session["searchBy"];
            string textToSearch = (string)Session["textToSearch"];
            List<string> sortByList = (List<string>)Session["sortByList"];

            if (sortByList != null && string.IsNullOrEmpty(searchBy) == false && string.IsNullOrEmpty(textToSearch) == false)
            {
                AddBookmarkToMainMenu(searchBy, textToSearch, sortByList);

            }
        }

        public void HiddenBook()
        {
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "col-xs-18 col-sm-6 col-md-3");
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Attributes.Add("class", "thumbnail");
            HtmlGenericControl div3 = new HtmlGenericControl("div");
            div3.Attributes.Add("class", "caption");
            HtmlGenericControl img = new HtmlGenericControl("img");
       //     img.Attributes.Add("src", "data:image/jpg;base64," + Convert.ToBase64String(currentPicture));
            HtmlGenericControl h4 = new HtmlGenericControl("h4") ;
            HtmlGenericControl p = new HtmlGenericControl("p");
            HtmlGenericControl a = new HtmlGenericControl("a") { InnerText = "JUMP TO ADRESS" };
          //  a.Attributes.Add("href", currentLink);
            Button b = new Button() { Text = "Like" };
            b.Attributes.Add("class", "btn-primary");


            div3.Controls.Add(h4);
            div3.Controls.Add(a);
            div3.Controls.Add(p);
            div3.Controls.Add(b);
            div2.Controls.Add(img);
            div2.Controls.Add(div3);
            div1.Controls.Add(div2);

            //       this.Controls.Add(div1);
            div1.Visible = false;
            roww1.Controls.Add(div1);
            b.Click += new EventHandler(likeButton_Click);
        }
        private void AddBookmarkToMainMenu(string searchBy, string textToSearch, List<string> sortByList)
        {
            var splitText = textToSearch.Split(' ');
            int nr = 0;
            HiddenBook();
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True"))
            {
                connection.Open();

                var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.Text;
                var sql = "SELECT * FROM Bookmarks WHERE " + searchBy + " IN ({0}) ORDER BY " + sortByList[0];

                List<string> idList = new List<string>();
                idList.AddRange(splitText);

                var idParameterList = new List<string>();
                var index = 0;
                foreach (var id in idList)
                {
                    var paramName = "@idParam" + index;
                    sqlCommand.Parameters.AddWithValue(paramName, id);
                    idParameterList.Add(paramName);
                    index++;
                }

                //var nameList = new List<String> { "sebastian", "kuuro", "svenbit" };
                //var nameParameter = new List<string>();
                //index = 0; // Reset the index
                //foreach (var name in nameList)
                //{
                //    var paramName = "@nameParam" + index;
                //    sqlCommand.Parameters.AddWithValue(paramName, name);
                //    nameParameter.Add(paramName);
                //    index++;
                //}

                sqlCommand.CommandText = String.Format(sql, string.Join(",", idParameterList));

                using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                {
                    //var resultTable = new DataTable();
                    //resultTable.Load(sqlReader);
                    //resultTable.get
                    while (myReader.Read())
                    {
                        var currentTitle = myReader["title"].ToString();
                        var currenDescription = myReader["description"].ToString();
                        var currentLink = myReader["link"].ToString();
                        var currentPicture = (byte[])myReader["picture"];
                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.Attributes.Add("class", "col-xs-18 col-sm-6 col-md-3");
                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.Attributes.Add("class", "thumbnail");
                        HtmlGenericControl div3 = new HtmlGenericControl("div");
                        div3.Attributes.Add("class", "caption");
                        HtmlGenericControl img = new HtmlGenericControl("img");
                        img.Attributes.Add("src", "data:image/jpg;base64," + Convert.ToBase64String(currentPicture));
                        HtmlGenericControl h4 = new HtmlGenericControl("h4") { InnerText = currentTitle };
                        HtmlGenericControl p = new HtmlGenericControl("p") { InnerText = currenDescription };
                        HtmlGenericControl a = new HtmlGenericControl("a") { InnerText = "JUMP TO ADRESS" };
                        a.Attributes.Add("href", currentLink);
                        Button b = new Button() { Text = "Like", ID = myReader["bookmarkId"].ToString() };
                        b.Attributes.Add("class", "btn-primary");


                        div3.Controls.Add(h4);
                        div3.Controls.Add(a);
                        div3.Controls.Add(p);
                        div3.Controls.Add(b);
                        div2.Controls.Add(img);
                        div2.Controls.Add(div3);
                        div1.Controls.Add(div2);

                        //       this.Controls.Add(div1);
                        roww1.Controls.Add(div1);
                        b.Click += new EventHandler(likeButton_Click);

                    }

                }
            }
        }
        private void MostVotedBooksAndLatestBooksAdd(string column, string choise)
        {

            try
            {
                int nr = 0;
                List<string> topPopularList = new List<string>();
                // Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Asus\\source\\repos\\Bookmarks\\Bookmarks\\App_Data\\Database.mdf; Integrated Security = True
                //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True"))
                {

                    SqlCommand command = new SqlCommand("Select *  from Bookmarks b inner join Users u on b.userId = u.userId ORDER BY  " + column + "  DESC", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && nr != 4)
                    {
                        topPopularList.Add(reader["firstName"].ToString());
                        nr++;
                    }
                    if (topPopularList.Count == 4 && choise == "MostViewd")
                    {
                        TBR1.InnerHtml = topPopularList[0];
                        TBR2.InnerHtml = topPopularList[1];
                        TBR3.InnerHtml = topPopularList[2];
                        TBR4.InnerHtml = topPopularList[3];
                    }
                    else if (topPopularList.Count == 4 && choise == "Latest")
                    {
                        TBL1.InnerHtml = topPopularList[0];
                        TBL2.InnerHtml = topPopularList[1];
                        TBL3.InnerHtml = topPopularList[2];
                        TBL4.InnerHtml = topPopularList[3];
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void likeButton_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            string id = (sender as Button).ID;

            if (b.BackColor.Equals(System.Drawing.Color.Red))
            {
                b.BackColor = System.Drawing.Color.Blue;
                ChangeNumberOfLikes(id,"unlike");
            }
            else
            {
                b.BackColor = System.Drawing.Color.Red;
                ChangeNumberOfLikes(id, "like");
            }
            
          

        }

        private void ChangeNumberOfLikes(string id,string tip)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
            try
            {
                con.Open();
                string query = "Select * from Bookmarks where bookmarkId = @id";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("id", id);
                using (SqlDataReader myReader = com.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        int currentNumberOfLikes = (int)myReader["numberOfLikes"];
                        SqlConnection updateConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
                        updateConnection.Open();
                        string updateQuery = "UPDATE Bookmarks set numberOfLikes = @nblike where bookmarkId = @id ";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection);
                        if(tip.Equals("unlike"))
                        {
                            updateCommand.Parameters.AddWithValue("nblike", currentNumberOfLikes - 1);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("nblike", currentNumberOfLikes + 1);
                        }
                        
                        updateCommand.Parameters.AddWithValue("id", id);
                        updateCommand.ExecuteNonQuery();
                        updateConnection.Close();
                    }
                    //TO DO TEST FOR PASSWORD CHECK

                }
            }

            catch (Exception ex)
            {
                //   Literal1.Text = ex.Message;
            }
        }
    }
}
