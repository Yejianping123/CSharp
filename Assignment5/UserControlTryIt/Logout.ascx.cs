using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*
         * Clear sessions if created
         */ 
        Session.Clear();
        Session.Abandon();
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        try
        {
            Session.Abandon();
            /*
             * Deactivate the cookie if no longer required
             */ 
            if (Request.Cookies["userCookie"] != null)
            {
                HttpCookie userCookie = new HttpCookie("userCookie");
                userCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(userCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1000;
            Response.CacheControl = "no-cache";
            Response.Redirect("Login.aspx", true);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        /*
         * Redirect to login page
         */ 
        Response.Redirect("Login.aspx");
    }
}