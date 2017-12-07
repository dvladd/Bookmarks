using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MostVotedBooksAndLatestBooksAdd("timesClicked", "MostViewd");
            MostVotedBooksAndLatestBooksAdd("addedTime", "Latest");
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