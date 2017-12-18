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
    public partial class BookmarksMainMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            NumeUser.InnerHtml = "Welcome back, " + (string)(Session["currentName"])
                + " (" + (string)(Session["currentUserName"] + ")");

        }





        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searchBy = "";
            string textToSearch = searchTextbox.Text;
            List<string> sortByList = new List<string>();
            if (radioButtonTags.Checked == true) { searchBy = "tags"; }
            else if (radioButtonTitle.Checked == true) { searchBy = "Title"; }
            else if (radioButtonDescription.Checked == true) { searchBy = "description"; }

            if (ckBoxTagSort.Checked == true) { sortByList.Add("tags"); }
            if (ckBoxTitleSort.Checked == true) { sortByList.Add("Title"); }
            if (ckBoxDescriptionSort.Checked == true) { sortByList.Add("description"); }

            Session["searchBy"] = searchBy;
            Session["textToSearch"] = textToSearch;
            Session["sortByList"] = sortByList;
            Response.Redirect("SearchElements.aspx");

      //      AddBookmarkToMainMenu(searchBy, textToSearch, sortByList);

            //if(sear)
        }

    
    }
}
