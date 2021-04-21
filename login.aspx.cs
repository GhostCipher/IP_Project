using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e) { }
	bool IsValidEmail(string str)
	{
		return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
	}
	void WriteCookie(string cookieName, string keyName, string value)
    {
		HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

		if (cookie == null) cookie = new HttpCookie(cookieName);
		cookie.Values.Set(keyName, value);
		cookie.HttpOnly = true;

		HttpContext.Current.Response.Cookies.Set(cookie);
	}

	protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
	{
		int userId;
		string constr = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;

		if (!IsValidEmail(Login1.UserName))
		{
			Login1.InstructionText = "You must enter a valid email address.";
		}
		else
		{
			Login1.InstructionText = String.Empty;
		}

		SqlConnection con = new SqlConnection(constr);
		SqlCommand cmd = new SqlCommand("ValidateUser");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@Username", Login1.UserName);
		cmd.Parameters.AddWithValue("@Password", Login1.Password);
		cmd.Connection = con;
		con.Open();
		userId = Convert.ToInt32(cmd.ExecuteScalar());
		con.Close();

		if (userId != 0)
		{
			WriteCookie("Auth","User",Convert.ToString(userId));
			e.Authenticated = true;
			Response.Redirect("Default.aspx");
		}
	}
}
