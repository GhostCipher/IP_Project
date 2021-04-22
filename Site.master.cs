using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check for Authentication Cookie
        FormsAuthenticationTicket ticket;
        if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
            UserNameTxtBox.Text = ticket.Name;
        }
        else UserNameTxtBox.Text = null;
    }

    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
      
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
