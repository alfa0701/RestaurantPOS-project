using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WaierPOS
{
    public class Database
    {
        private string CONN_STRING = @"Server=tcp:mihoaka.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee ORDER BY EmpId", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int xId = (int)reader["EmpId"];
                    string xFName = (string)reader["FirstName"];
                    string xLName = (string)reader["LastName"];
                    string xStreet = (string)reader["Street"];
                    string xCity = (string)reader["City"];
                    string xPostal = (string)reader["Postal"];
                    string xPhone = (string)reader["Phone"];
                    string xSIN = (string)reader["SIN"];
                    string xPassword = (string)reader["Password"];

                    Employee emp = new Employee { EmpId = xId, FName = xFName, LName = xLName, Phone = xPhone, SIN = xSIN, Street = xStreet, City = xCity, Postal = xPostal, Password = xPassword };
                    result.Add(emp);
                }
            }
            return result;
        }

        public int AddEmployee(Employee p)
        {
            int newID;
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Employee (FirstName ,LastName, Phone , SIN , Street,City ,Postal,Password ) VALUES ( @FName ,@LName, @Phone, @SIN,@Street,@City,@Postal,@Password); SELECT SCOPE_IDENTITY() as INT;", conn);
            insertCommand.Parameters.Add(new SqlParameter("FName", p.FName));
            insertCommand.Parameters.Add(new SqlParameter("LName", p.LName));
            insertCommand.Parameters.Add(new SqlParameter("Phone", p.Phone));
            insertCommand.Parameters.Add(new SqlParameter("SIN", p.SIN));
            insertCommand.Parameters.Add(new SqlParameter("Street", p.Street));
            insertCommand.Parameters.Add(new SqlParameter("City", p.City));
            insertCommand.Parameters.Add(new SqlParameter("Postal", p.Postal));

            insertCommand.Parameters.Add(new SqlParameter("Password", p.Password));



            newID = Convert.ToInt32(insertCommand.ExecuteScalar());
            return newID;


        }
        public void DeleteEmployeeByID(int ID)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE  Employee Where EmpId =@id", conn);
            deleteCommand.Parameters.Add(new SqlParameter("id", ID));
            deleteCommand.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee e)
        {
            SqlCommand updateCommand = new SqlCommand("Update Employee SET FirstName=@fname ,LastName = @lname, Phone=@phone , SIN=@sin" +
                " , Street = @street,City=@city ,Postal = @postal,Password = @pswd Where EmpId = @empId", conn);
            updateCommand.Parameters.Add(new SqlParameter("fname", e.FName));
            updateCommand.Parameters.Add(new SqlParameter("lname", e.LName));
            updateCommand.Parameters.Add(new SqlParameter("phone", e.Phone));
            updateCommand.Parameters.Add(new SqlParameter("sin", e.SIN));
            updateCommand.Parameters.Add(new SqlParameter("street", e.Street));
            updateCommand.Parameters.Add(new SqlParameter("city", e.City));
            updateCommand.Parameters.Add(new SqlParameter("postal", e.Postal));
            updateCommand.Parameters.Add(new SqlParameter("pswd", e.Password));
            updateCommand.Parameters.Add(new SqlParameter("empId", e.EmpId));
            updateCommand.ExecuteNonQuery();
        }


        ////////////// for ChooseTable Window  //////////////////////////////////////////
        public int AddOrder(Order o)
        {
            int newID;
            SqlCommand insertCommand = new SqlCommand("INSERT INTO [Order] (TableNumber, GuestCount,OrderDate) VALUES (@table,@guest ,@date); SELECT SCOPE_IDENTITY() as INT;", conn);
            insertCommand.Parameters.Add(new SqlParameter("table", o.TableNo));
            insertCommand.Parameters.Add(new SqlParameter("date", o.OrderDate));
            insertCommand.Parameters.Add(new SqlParameter("guest", o.GuestCount));


            newID = Convert.ToInt32(insertCommand.ExecuteScalar());
            return newID;


        }



        ////////////////////////////////for OrderWindow///////////////////////////////////////////
        public List<OrderedItem> GetAllOrderDetails(int orderId)
        {
            List<OrderedItem> result = new List<OrderedItem>();
            SqlCommand selectCommand = new SqlCommand("SELECT m.MenuName as Item,Count(od.qty) as Qty" +
                " FROM [Order] as o INNER Join [OrderDetail] as od on o.OrderId = od.OrderId" +
                " INNER JOIN [Menu] as m on m.MenuId = od.MenuId Where od.OrderId = @orderId Group by m.MenuName ", conn);
            selectCommand.Parameters.Add(new SqlParameter("orderId", orderId));
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string MenuName = (string)reader["Item"];

                    int qty = (int)reader["Qty"];



                    OrderedItem item = new OrderedItem { MenuName = MenuName, qty = qty };
                    result.Add(item);
                }
            }
            return result;
        }



        public void AddNewOrderDetail(OrderDetail o)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO [OrderDetail] (MenuId,Qty,OrderId) VALUES ( @MenuId, @Qty,@OrderId);", conn);
            insertCommand.Parameters.Add(new SqlParameter("OrderId", o.OrderId));
            insertCommand.Parameters.Add(new SqlParameter("MenuId", o.MenuId));
            insertCommand.Parameters.Add(new SqlParameter("Qty", o.Qty));
            insertCommand.ExecuteNonQuery();
        }

        public void DeleteOrderByOrderId(int OrderId)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE FROM [Order] Where OrderId =@id", conn);
            deleteCommand.Parameters.Add(new SqlParameter("id", OrderId));
            deleteCommand.ExecuteNonQuery();
        }

        public void DeleteOrderDetailByOrderDetailId(int OrderDetailId)
        {

            SqlCommand deleteCommand = new SqlCommand("DELETE  From [OrderDetail] Where OrderDetailId =@id", conn);
            deleteCommand.Parameters.Add(new SqlParameter("id", OrderDetailId));
            deleteCommand.ExecuteNonQuery();
        }


        public void DeleteAllOrderDetailByOrderId(int OrderId)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE  From [OrderDetail] Where OrderId =@id", conn);
            deleteCommand.Parameters.Add(new SqlParameter("id", OrderId));
            deleteCommand.ExecuteNonQuery();
        }

        ////////////////////////////////for logIn///////////////////////////////////////////
        public string PasswordByID(int Id)
        {
            string pswd = "";
            SqlCommand selectCommand = new SqlCommand("SELECT  Password  FROM [Employee] where Empid =Id");
            pswd = (string)selectCommand.ExecuteScalar();
            return pswd;
        }


        public void DeleteOrderDetailById(int OrderDetailId)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE  OrderDetail Where OrderDetailId =@id", conn);
            deleteCommand.Parameters.Add(new SqlParameter("id", OrderDetailId));
            deleteCommand.ExecuteNonQuery();
        }
        ////////////////////////////////for Printing Bill(list1)///////////////////////////////////////////
        public List<OrderedItem> GetAllOrders(int orderId)
        {
            List<OrderedItem> result = new List<OrderedItem>();
            SqlCommand selectCommand = new SqlCommand("SELECT  od.OrderDetailId as Id, m.MenuName as Item, od.qty as Qty,m.Price as Price FROM [Order] as o" +
                " INNER Join [OrderDetail] as od on o.OrderId = od.OrderId" +
                " INNER JOIN [Menu] as m on m.MenuId = od.MenuId Where od.OrderId = @orderId and PaymentId is null ", conn);
            selectCommand.Parameters.Add(new SqlParameter("orderId", orderId));
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    int qty = (int)reader["Qty"];
                    string MenuName = (string)reader["Item"];
                    decimal Price = (decimal)reader["Price"];
                    OrderedItem item = new OrderedItem { OrderedItemId = id, MenuName = MenuName, qty = qty, price = Price };
                    result.Add(item);
                }
            }
            return result;
        }




        ////////////////////////////////for Printing Bill(list2)///////////////////////////////////////////
        public List<OrderedItem> GetAllOrderDetailByPaymentId(int orderId, int paymentId)
        {
            List<OrderedItem> result = new List<OrderedItem>();
            SqlCommand selectCommand = new SqlCommand("SELECT  od.OrderDetailId as Id, m.MenuName as Item, od.qty as Qty,m.Price as Price FROM [Order] as o" +
                " INNER Join [OrderDetail] as od on o.OrderId = od.OrderId" +
                " INNER JOIN [Menu] as m on m.MenuId = od.MenuId Where od.OrderId = @orderId and PaymentId =paymentId ", conn);
            selectCommand.Parameters.Add(new SqlParameter("orderId", orderId));
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    int qty = (int)reader["Qty"];
                    string MenuName = (string)reader["Item"];
                    decimal Price = (decimal)reader["Price"];
                    OrderedItem item = new OrderedItem { OrderedItemId = id, MenuName = MenuName, qty = qty, price = Price };
                    result.Add(item);
                }
            }
            return result;
        }
        ///////UpdateOrderDetailsByPaymentId//////////// 
        public void UpdateOrderDetailsByPaymentId(int orderdetalid, int PaymentId)
        {
            SqlCommand updateCommand = new SqlCommand("Update  OrderDetail SET PaymentId =@paymentId where OrderDetailId =@orderId;", conn);
            updateCommand.Parameters.Add(new SqlParameter("orderId", orderdetalid));
            updateCommand.Parameters.Add(new SqlParameter("@paymentId", PaymentId));
            updateCommand.ExecuteNonQuery();
        }

        ///////Inset method//////////// 
        public int AddNewPayment()
        {
            SqlCommand InserteCommand = new SqlCommand("INSERT INTO Payment(IsPaid) VALUES (0) ; SELECT SCOPE_IDENTITY() as INT;", conn);

            int m = Convert.ToInt32(InserteCommand.ExecuteScalar());
            return m;

        }

    }
}
