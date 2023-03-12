using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.Pages.Clients;
using System.Data.SqlClient;

namespace MOGILEVZAGS.Pages.Client1
{
    public class Create1Model : PageModel
    {
        public Client1Info client1Info = new Client1Info();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {

        }

        public void OnPost()
        {
            client1Info.name = Request.Form["name"];
            client1Info.surname = Request.Form["surname"];
            client1Info.secondname = Request.Form["secondname"];
            client1Info.email = Request.Form["email"];
            client1Info.phone = Request.Form["phone"];



            if (client1Info.name.Length == 0 || client1Info.surname.Length == 0 ||
                client1Info.secondname.Length == 0 || client1Info.email.Length == 0 ||
                client1Info.phone.Length == 0)
            {
                errorMessage = "Все поля должны быть заполнены!";
                return;

            }

            try
            {
                String connectionString = "Data Source=NEKET\\SQL1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "USE [Client]\r\n INSERT INTO dbo.Clients " + "(name,surname,secondname,email, phone) VALUES " +
                        "(@name,@surname,@secondname,@email, @phone);";

                    using (SqlCommand command =new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("name", client1Info.name);
                        command.Parameters.AddWithValue("surname", client1Info.surname);
                        command.Parameters.AddWithValue("secondname", client1Info.secondname);
                        command.Parameters.AddWithValue("email", client1Info.email);
                        command.Parameters.AddWithValue("phone", client1Info.phone);
                        //command.Parameters.AddWithValue("birthday", clientInfo.birthday);

                        command.ExecuteNonQuery();
                    }
                }
            }  
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
                
            }


            client1Info.name = "";  client1Info.surname = ""; client1Info.secondname = ""; client1Info.email = "";
                 client1Info.phone = "";
            successMessage = "New client Added Correctly";

            Response.Redirect("/Client1/Index");

        }
    }
}


