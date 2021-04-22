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
    string getUser()
    {
        // Check for Authentication Cookie
        FormsAuthenticationTicket ticket;
        if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
            return ticket.Name;
        }
        else return null;
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        // Check for Authentication Cookie
        string user = getUser();

        // Redirect to login if not logged in
        if (user == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        
        

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}