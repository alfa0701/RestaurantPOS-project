using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WaiterUI
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

        public string GetPasswordById(int id) {
            string password = "";
            return password;
        }// to be called in WaiterUI log in window.

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee ORDER BY Id", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int xId = (int)reader["Id"];
                    string xFName = (string)reader["FirstName"];
                    string xLName = (string)reader["LastName"];
                    string xStreet = (string)reader["Street"];
                    string xCity = (string)reader["City"];
                    string xPostal = (string)reader["Postal"];
                    string xPhone = (string)reader["Phone"];
                    string xSIN = (string)reader["SIN"];
                    string xPassword = (string)reader["Password"];

                    Employee emp = new Employee{ Id = xId, FName = xFName, LName = xLName, Phone = xPhone, SIN = xSIN, Street=xStreet,City = xCity,Postal=xPostal,Password=xPassword };
                    result.Add(emp);
                }
            }
            return result;
        }

        // NOTE add modified so that it returns ID of the record just created
        public void AddEmployee(Employee p)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Employee (FirstName ,LastName, Phone , SIN , Street,City ,Postal,Password ) VALUES ( @FName ,@LName, @Phone, @SIN,@Street,@City,@Postal,@Password); SELECT SCOPE_IDENTITY();", conn);
            insertCommand.Parameters.Add(new SqlParameter("FName", p.FName));
            insertCommand.Parameters.Add(new SqlParameter("LName", p.LName));
            insertCommand.Parameters.Add(new SqlParameter("Phone", p.Phone));
            insertCommand.Parameters.Add(new SqlParameter("SIN", p.SIN));
            insertCommand.Parameters.Add(new SqlParameter("Street", p.Street));
            insertCommand.Parameters.Add(new SqlParameter("City", p.City));
            insertCommand.Parameters.Add(new SqlParameter("Postal", p.Postal));

            insertCommand.Parameters.Add(new SqlParameter("Password", p.Password));



            insertCommand.ExecuteNonQuery();
           
        }
    }
}
