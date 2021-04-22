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
        string user = getUser();
        if (user == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        
        

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}