using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class PersonalBookmarks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                        div3.Controls.Add(h4);
                        div3.Controls.Add(a);
                        div3.Controls.Add(p);
                        div2.Controls.Add(img);
                        div2.Controls.Add(div3);
                        div1.Controls.Add(div2);
                        //       this.Controls.Add(div1);
                        roww.Controls.Add(div1);
                        //currentUserId = (int)myReader["userId"];
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}