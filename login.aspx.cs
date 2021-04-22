﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		FormsAuthenticationTicket ticket;
		if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
		{
			ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
			Login1.InstructionText = "Logged in as " + ticket.Name;
		}


	}
	


	protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
	{
		string userName;
		string constr = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;

		SqlConnection con = new SqlConnection(constr);
		SqlCommand cmd = new SqlCommand("ValidateUser");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@Username", Login1.UserName);
		cmd.Parameters.AddWithValue("@Password", Login1.Password);
		cmd.Connection = con;
		con.Open();
		userName = Convert.ToString(cmd.ExecuteScalar());
		con.Close();
		Login1.InstructionText = userName;
		if (userName != "")
		{
			//FormsAuthentication.SetAuthCookie(userName,false);
			e.Authenticated = true;
			FormsAuthentication.RedirectFromLoginPage(userName, false);
		}
	}

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

    }
}
