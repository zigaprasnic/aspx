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
    public partial class upload : System.Web.UI.Page
    {

        //SqlConnection con = new SqlConnection("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (UploadTest.HasFile == false)
            {
                // No file uploaded!
                UploadDetails.Text = "Please first select a file to upload...";
            }

            else
            {
                var path = Server.MapPath("~/uploads");

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

                var upime = Session["username"];
                string str = UploadTest.FileName;
                string fileExtension = System.IO.Path.GetExtension(str);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {

                    UploadTest.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
                    path = "/uploads/" + str.ToString();

                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        //Stored Procedures Workbench
                        using (MySqlCommand cmd = new MySqlCommand("user_upload"))
                        {
                            using (MySqlDataAdapter sda = new MySqlDataAdapter())
                            {

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("upime", upime);
                                cmd.Parameters.AddWithValue("str", str);
                                cmd.Parameters.AddWithValue("path", path);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                            }
                        }

                        /*string message = string.Empty;

                            message = "Uspešna prijava! Čez nekaj trenutkov boste preusmerjeni na vašo stran.";
                            Response.AddHeader("REFRESH", "3;URL=prijavljen.aspx");
                            //Response.Redirect("prijavljen.aspx");*/
                    }

                    /*string str = UploadTest.FileName;
                    UploadTest.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
                    string path = "~//uploads//" + str.ToString();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into uploads values('" + UploadTest.FileName + "','" + path + "')");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    UploadDetails.Text = "Slika se je nalozila";*/

                    // Display the uploaded file's details
                    UploadDetails.Text = string.Format(
                            @"Uploaded file: {0}<br />
                  File size (in bytes): {1:N0}<br />
                  Content-type: {2}",
                              UploadTest.FileName,
                              UploadTest.FileBytes.Length,
                              UploadTest.PostedFile.ContentType);
                    // Save the file
                    String filePath = Server.MapPath("/uploads/");
                    UploadTest.PostedFile.SaveAs(filePath + UploadTest.FileName);
                }

                else
                {
                    UploadDetails.Text = "Napaka. Dovoljene končnice so samo JPG, JPEG, PNG in BMP.";
                }

            }


        }
    }
}