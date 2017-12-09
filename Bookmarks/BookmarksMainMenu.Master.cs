using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    }
}