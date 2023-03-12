using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MOGILEVZAGS.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.surname = Request.Form["surname"];
            clientInfo.secondname = Request.Form["secondname"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];



            if (clientInfo.name.Length == 0 || clientInfo.surname.Length == 0 ||
                clientInfo.secondname.Length == 0 || clientInfo.email.Length == 0 ||
                clientInfo.phone.Length == 0)
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
                        command.Parameters.AddWithValue("name", clientInfo.name);
                        command.Parameters.AddWithValue("surname", clientInfo.surname);
                        command.Parameters.AddWithValue("secondname", clientInfo.secondname);
                        command.Parameters.AddWithValue("email", clientInfo.email);
                        command.Parameters.AddWithValue("phone", clientInfo.phone);
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


            clientInfo.name = "";  clientInfo.surname = ""; clientInfo.secondname = ""; clientInfo.email = "";
                 clientInfo.phone = "";
            successMessage = "New client Added Correctly";

            Response.Redirect("/Clients/Index");

        }
    }
}


