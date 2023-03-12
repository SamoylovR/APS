using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace MOGILEVZAGS.Pages.Client1
{
    public class Index1Model : PageModel
    {
        public List<Client1Info> ListClients = new List<Client1Info>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=ANRLT\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    String sql = "USE [Client]\r\nSELECT * FROM dbo.Clients";   
                    using (SqlCommand command = new SqlCommand(sql, connection))
                   
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Client1Info clientInfo = new Client1Info  
                                {
                                    id = "" + reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    surname = reader.GetString(2),
                                    secondname = reader.GetString(3),
                                    email = reader.GetString(4),
                                    phone = reader.GetString(5),
                                    //birthday = reader.GetDateTime(6),
                                    created_at = reader.GetDateTime(7).ToString()
                                };


                                ListClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception  " + ex.ToString());
            }
        }
    }

    public class Client1Info
    {
        public String id;
        public String name;
        public String surname;
        public String secondname;
        public String email;
        public String phone;
        //public DateTime birthday;
        public String created_at;
    }



}
