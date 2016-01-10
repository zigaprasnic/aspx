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

namespace Projekt
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        public string CalculateMD5Hash(string input)
        {
            //MD5 dekodiranje (v bazi so gesla kodirana z MD5, pri preverjanju prijave potrebno dekodiranje MD5 v geslo)

            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            var starogeslo = CalculateMD5Hash(TextBox1.Text);

            var novogeslo1 = CalculateMD5Hash(TextBox2.Text);
            var novogeslo2 = CalculateMD5Hash(TextBox3.Text);

            var upime = Session["username"];

            string id;

            if (novogeslo1 == novogeslo2)
            {
                string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    //Stored Procedures Workbench
                    using (MySqlCommand cmd = new MySqlCommand("change_pass"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("starogeslo", starogeslo);
                            cmd.Parameters.AddWithValue("novogeslo", novogeslo1);
                            cmd.Parameters.AddWithValue("upime", upime);
                            cmd.Connection = con;
                            con.Open();
                            id = Convert.ToString(cmd.ExecuteScalar());
                            con.Close();

                        }
                    }

                    if (id == "napaka")
                    {
                        Label4.Text = "Prišlo je do napake. Staro geslo je napačno!";
                        Response.AddHeader("REFRESH", "1;URL=settings.aspx");
                    }
                    else
                    {
                        Label4.Text = "Uspešno ste spremenili vaše geslo. Potrebna bo ponovna prijava!";
                        Session.Abandon();
                        Session.Clear();
                        Session.Remove("username");
                        Response.AddHeader("REFRESH", "3;URL=login.aspx");
                        //Response.Redirect("prijavljen.aspx");
                    }
                }
            }

            else
            {
                Label4.Text = "Gesli se ne ujemata!";
                Response.AddHeader("REFRESH", "1;URL=settings.aspx");
            }
        }
    }
}