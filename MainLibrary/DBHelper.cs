using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainLibrary
{


    public class DBHelper

    {
        private readonly string connectionString = " Data Source=NAOMI\\SQLEXPRESS01;Initial Catalog=LoanManagementSystem;Integrated Security=True;";
        public DBHelper() { }



        //SqlConnection sqlConnection = new SqlConnection(connectionString);

        /* public List<User> getAllUser()
         {
             List<User> allUser = new List<User>();

             //connection
             SqlConnection sqlConnection = new SqlConnection(connectionString);

             //command
             string sql = "Select * from Users";
             SqlCommand cmd = new SqlCommand(sql, sqlConnection);

             //open database connection
             sqlConnection.Open();

             //get data
             SqlDataReader reader = cmd.ExecuteReader();

             while (reader.Read())
             {

                 User user = new User();
                 //user.UserID = Convert.ToInt16(reader["id"]);
                 user.Username = reader["username"].ToString();
                 user.Password = reader["password"].ToString();
                // user.Role = reader["role"].ToString();
                 allUsers.Add(user);
             }




             return allUser;
         }*/

        // Read logih information
        public User Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Userr WHERE username=@username AND password=@password";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["userId"]),
                            Username = reader["username"].ToString(),
                            Role = reader["role"].ToString()
                        };
                    }
                }
            }

            return null;


        }

        public void saveCustomer(Customer customer)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sql = "INSERT INTO Customers (firstName, lastName, idTrn, phoneNumber, email, address, employmentStatus, monthlyIncome) " +
                         "VALUES (@firstName, @lastName, @idTrn, @phoneNumber, @email, @address, @employmentStatus, @monthlyIncome)";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            cmd.Parameters.AddWithValue("@firstName", customer.firstName);
            cmd.Parameters.AddWithValue("@lastName", customer.lastName);
            cmd.Parameters.AddWithValue("@idTrn", customer.idTrn);
            cmd.Parameters.AddWithValue("@phoneNumber", customer.phoneNumber);
            cmd.Parameters.AddWithValue("@email", customer.email);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@employmentStatus", customer.employmentStatus);
            cmd.Parameters.AddWithValue("@monthlyIncome", customer.monthlyIncome);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Customer getCustomerById(int customerId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Customer WHERE customerId = @customerId";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@customerId", customerId);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Customer customer = null;

            if (reader.Read())
            {
                customer = new Customer();
                customer.customerId = Convert.ToInt16(reader["customerId"]);
                customer.firstName = reader["firstName"].ToString();
                customer.lastName = reader["lastName"].ToString();
                customer.idTrn = reader["idTrn"].ToString();
                customer.phoneNumber = reader["phoneNumber"].ToString();
                customer.email = reader["email"].ToString();
                customer.Address = reader["address"].ToString();
                customer.employmentStatus = reader["employmentStatus"].ToString();
                customer.monthlyIncome = Convert.ToDecimal(reader["monthlyIncome"]);
            }

            sqlConnection.Close();
            return customer;
        }

        public void deleteCustomer(int customerId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sql = "DELETE FROM Customer WHERE customerId=@customerId";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", customerId);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        

        public List<Customer> getAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>();

             //connection
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

             //open database connection
            sqlConnection.Open(); 

             //get data
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new Customer();

                customer.customerId = Convert.ToInt32(reader["customerId"]);
                customer.firstName = reader["firstName"].ToString();
                customer.lastName = reader["lastName"].ToString();

                allCustomers.Add(customer);
            }

            sqlConnection.Close();

            return allCustomers;
        }


        public void saveLoan(Loan loan)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sql = "INSERT INTO Loan (customerId, loanAmount, interestRate, loanTerm, applicationDate, status) " +
                         "VALUES (@customerId, @loanAmount, @interestRate, @loanTerm, @applicationDate, @status)";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            cmd.Parameters.AddWithValue("@customerId", loan.customerId);
            cmd.Parameters.AddWithValue("@loanAmount", loan.loanAmount);
            cmd.Parameters.AddWithValue("@interestRate", loan.interestRate);
            cmd.Parameters.AddWithValue("@loanTerm", loan.loanTerm);
            cmd.Parameters.AddWithValue("@applicationDate", loan.applicationDate);
            cmd.Parameters.AddWithValue("@status", loan.status);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }

}
