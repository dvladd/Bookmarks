using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cred ca o sa trebuiasca sa chimbi si tu connection string-ul ca sa iti mearga.Nu sunt sigur de asta.Sa incerci
            try
            {
                int nr = 0;
                List<string> topPopularList = new List<string>();
                using (SqlConnection connection =
                 new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\source\\repos\\Bookmarks\\Bookmarks\\App_Data\\Database.mdf;Integrated Security=True"))
                {
                    SqlCommand command =
                        new SqlCommand("Select *  from Bookmarks b inner join Users u on b.userId = u.userId ORDER BY timesClicked DESC", connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                   
                    while (reader.Read() && nr != 4)
                    {
                       topPopularList.Add(reader["firstName"].ToString());
                        nr++;
                    }
                    if (topPopularList.Count == 4)
                    {
                        TBR1.InnerHtml = topPopularList[0];
                        TBR2.InnerHtml = topPopularList[1];
                        TBR3.InnerHtml = topPopularList[2];
                        TBR4.InnerHtml = topPopularList[3];
                    }
                    reader.Close();
                }
            }
            catch (Exception ei)
            {

            }

        }
    }
}