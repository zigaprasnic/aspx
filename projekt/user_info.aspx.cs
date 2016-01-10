using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Data.SqlClient;

namespace Projekt
{
    public partial class user_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }

            else
            {
                var upime = Session["username"];

                string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    //Stored Procedures Workbench
                    using (MySqlCommand cmd = new MySqlCommand("user_info"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("upime", upime);
                            cmd.Connection = con;
                            con.Open();
                            DataTable dt = new DataTable();
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                            ListView1.DataSource = dt;
                            ListView1.DataBind();
                            con.Close();
                        }
                    }
                }
            }
        }
    }
}