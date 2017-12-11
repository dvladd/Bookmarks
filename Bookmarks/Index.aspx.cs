using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               MostVotedBooksAndLatestBooksAdd("timesClicked", "MostViewd");
               MostVotedBooksAndLatestBooksAdd("addedTime", "Latest");
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True");
            try
            {
                con.Open();
                string query = "SELECT * FROM Bookmarks";
                SqlCommand com = new SqlCommand(query, con);

                string currentTitle = "";
                string currenDescription = "";
                string currentLink = "";
                //int currentUserId = -1;
                using (SqlDataReader myReader = com.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        currentTitle = myReader["title"].ToString();
                        currenDescription = myReader["description"].ToString();
                        currentLink = myReader["link"].ToString();
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
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        HtmlGenericControl a2 = new HtmlGenericControl("a") { InnerText = "s" };
                        //    li.Controls.Add(a2);




                        div3.Controls.Add(h4);
                        div3.Controls.Add(a);
                        div3.Controls.Add(p);
                        div2.Controls.Add(img);
                        div2.Controls.Add(div3);
                        div1.Controls.Add(div2);
                        //       this.Controls.Add(div1);
                        li.Controls.Add(div1);
                        //UL.Controls.Add(li);
                        roww.Controls.Add(div1);

                        //currentUserId = (int)myReader["userId"];
                    }
                }
            }
            catch (Exception)
            {

            }


        }

        private void LatestBooksAdd()
        {

        }

        private void MostVotedBooksAndLatestBooksAdd(string column, string choise)
        {
            try
            {
                int nr = 0;
                List<string> topPopularList = new List<string>();
                // Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Asus\\source\\repos\\Bookmarks\\Bookmarks\\App_Data\\Database.mdf; Integrated Security = True
                //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf; Integrated Security = True
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vlad\Source\Repos\Bookmarks\Bookmarks\App_Data\Database.mdf;Integrated Security=True"))
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
    }
}