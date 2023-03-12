using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace MOGILEVZAGS.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=ANRLT\\SQLEXPRESS;Initial Catalog=Client;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.surname = reader.GetString(2);
                                clientInfo.secondname = reader.GetString(3);
                                clientInfo.email = reader.GetString(4);
                                clientInfo.phone = reader.GetString(5);
                                //birthday = reader.GetDateTime(6),
                                clientInfo.created_at = reader.GetDateTime(7).ToString();
                                clientInfo.typeOfOperation = reader.GetString(8);
                                //
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

    public class ClientInfo
    {
        public String id;
        public String name;
        public String surname;
        public String secondname;
        public String email;
        public String phone;
        //public DateTime birthday;
        public String created_at;
        public String typeOfOperation;
    }
}