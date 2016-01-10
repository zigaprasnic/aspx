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
    public partial class dodajanje_novic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            var upime = Session["username"];

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //Stored Procedures Workbench
                using (MySqlCommand cmd = new MySqlCommand("user_open_files"))
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

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}