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
using System.Text.RegularExpressions;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    bool IsValidEmail(string str)
    {
        return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }


    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (IsValidEmail(EmailTxtBox.Text))
        {
            // Get User Information
            string name = NameTxtBox.Text;
            string email = EmailTxtBox.Text;
            string pass = PasswordTxtBox.Text;

            // Get connection String
            string constr = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;

            // Set up SQL Query
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("AddUser");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", pass);
            cmd.Parameters.AddWithValue("@Role", "Member");
            cmd.Connection = con;

            // Execute Query
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
        }
        else
        {
            // Add Error Message
        }
    }
}