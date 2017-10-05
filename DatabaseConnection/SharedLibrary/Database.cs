using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharedLibrary
{
     public class Database
    {
        private string CONN_STRING = @"Server=tcp:mihoaka.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID=sqladmin;Password=Mihoaka0215;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection();
            conn.ConnectionString = CONN_STRING;
            conn.Open();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM People ORDER BY Id", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int xId = (int)reader["Id"];
                    string xName = (string)reader["Name"];
                    int xAge = (int)reader["Age"];
                    double xHeight = (float)reader["Height"]; // float -> double
                    Employee p = new Employee { Id = xId, Name = xName, Age = xAge, Height = xHeight };
                    result.Add(p);
                }
            }
            return result;
        }

        // NOTE add modified so that it returns ID of the record just created
        public int AddEmployee(Employee p)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age, Height) VALUES (@Name, @Age, @Height); SELECT SCOPE_IDENTITY();", conn);
            insertCommand.Parameters.Add(new SqlParameter("Name", p.Name));
            insertCommand.Parameters.Add(new SqlParameter("Age", p.Age));
            insertCommand.Parameters.Add(new SqlParameter("Height", p.Height));
            //insertCommand.ExecuteNonQuery();
            int id = (int)insertCommand.ExecuteScalar(); // return ID of the record just created
            return id;
        }
    }
}
