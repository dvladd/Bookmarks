using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookmarks
{
    public partial class AddBookmark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBookmarkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool valid = true;
                int _visibility = -1;
                if (RadioButtonList1.SelectedIndex > -1)
                {
                    //EroareRadio.Text = "Your bookmark will be " + RadioButtonList1.SelectedItem.Text;
                    if (RadioButtonList1.SelectedItem.Value == "private")
                        _visibility = 0;
                    else if (RadioButtonList1.SelectedItem.Value == "public")
                        _visibility = 1;
                    else if (RadioButtonList1.SelectedItem.Value == "both")
                        _visibility = 2;
                }
                String _Title = title.Text;
                String _Link = link.Text;
                String _Description = description.Text;
                String _Tags = tags.Text;
                String _Category = category.Text;
                String _likes = category.Text;
                byte[] _Sir = null;
                int _userId = (int)Session["currentUserId"];
                if(photoUpload.HasFile == true)
                {
                    _Sir = new byte[photoUpload.PostedFile.ContentLength];
                    photoUpload.PostedFile.InputStream.Read(_Sir, 0,photoUpload.PostedFile.ContentLength);
                    //Image2.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(sir);
                }

                if(_visibility == -1)
                {
                    valid = false;
                    EroareRadio.Text = "Error: Select the visibility of the bookmark!";
                }

                if(_Title == "")
                {
                    valid = false;
                    EroareTitle.Text = "Error: Title cannot be blank!";
                }

                if(_Link == "")
                {
                    valid = false;
                    EroareLink.Text = "Error: Link cannot be blank!";
                }

                if(_Description == "")
                {
                    valid = false;
                    EroareDescriere.Text = "Error: Description cannot be blank!";
                }

                if (_Category == "")
                {
                    valid = false;
                    EroareDescriere.Text = "Error: Category cannot be blank!";
                }

                if (_Tags == "")
                {
                    valid = false;
                    EroareTags.Text = "Error: No tags inserted, please insert atleast 2 Tags!";
                }

                if(valid)
                {
                    string query = "INSERT INTO Bookmarks(visibility, userId, title, link, description, tags, addedDate, timesClicked, addedTime, picture, category, numberOfLikes) OUTPUT INSERTED.bookmarkId "
                     + "VALUES (@visibility, @userId, @title, @link, @description, @tags, @addedDate, @timesClicked, @addedTime, @picture, @category , @likes)";
                    DateTime _localDate = DateTime.Now.Date;
                    TimeSpan _localTime = DateTime.Now.TimeOfDay;
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Desktop\DatabaseForProject\Database.mdf;Integrated Security=True");
                    try
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        com.Parameters.AddWithValue("visibility", _visibility);
                        com.Parameters.AddWithValue("userId", _userId);
                        com.Parameters.AddWithValue("title", _Title);
                        com.Parameters.AddWithValue("link", _Link);
                        com.Parameters.AddWithValue("description", _Description);
                        com.Parameters.AddWithValue("tags", _Tags);
                        com.Parameters.AddWithValue("addedDate", _localDate);
                        com.Parameters.AddWithValue("timesClicked", 0);
                        com.Parameters.AddWithValue("addedTime", _localTime);
                        com.Parameters.AddWithValue("picture", _Sir);
                        Session["imagetest"] = _Sir;
                        com.Parameters.AddWithValue("category", _Category);
                        com.Parameters.AddWithValue("likes", 0);
                        int id = (int)com.ExecuteScalar();

                        if(id > 0)
                        {
                            EroareBazaDate.Text = "Bookmark created successfully!";
                        }
                        else
                        {
                            EroareBazaDate.Text = "Error while creating bookmark!";
                        }

                    }
                    catch (Exception ex)
                    {
                        EroareBazaDate.Text = "Error while inserting bookmark: " + ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])Session["imagetest"]);
        }
    }
}