using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wechatApi.Models
{
    public class dbHelper
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "mpdatabaseserver.mysql.database.azure.com",
            Database = "mpdb",
            UserID = "helloworld@mpdatabaseserver",
            Password = "Mpdatabase!",
            SslMode = MySqlSslMode.Required,
        };
        public async Task select(string script)
        {
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                //this part to connect; manage database here;


                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    
                }

                // connection will be closed by the 'using' block
                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }
    }
}
