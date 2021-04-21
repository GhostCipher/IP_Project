using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class ControlPanel : System.Web.UI.Page
{
    string ReadCookie(string cookieName, string key)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        {
            return cookie[key];
        }
        return null;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = ReadCookie("auth", "user");
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}