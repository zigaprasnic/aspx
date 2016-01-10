using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Security;
using System.IO;
using System.Collections;
using System.Web.Security;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb; 

namespace Projekt
{
    public partial class prijavljen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void Logout_btn_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.Remove("username");
            Response.Redirect("index.aspx"); 
        }
    }
}
