using crud.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace crud.DAL
{
    public class AccountDAL
    {
        private readonly string connectionString = MyConfiguration.GetConnectionString();

        // SignUp
        public void SignUp(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // You should hash the password before storing it in the database (not shown here for simplicity)
                string insertQuery = "UserSignup";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Hash the password in a real-world scenario

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // Checking If the Email Exists
        public bool CheckEmailExists(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string spName = "CheckEmailExists";

                using (SqlCommand cmd = new SqlCommand(spName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result) == 1;
                    }
                }

                return false;
            }
        }


        public (bool success, string errorMessage) Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // You should hash the password before comparing it with the database (not shown here for simplicity)
                string selectQuery = "UserLogin";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Hash the password in a real-world scenario

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        // Handle NULL result, for example, user not found
                        connection.Close();
                        return (false, "Invalid email or password.");
                    }

                    if (result is string loginResult && loginResult.Equals("Login successful", StringComparison.OrdinalIgnoreCase))
                    {
                        // Successfully obtained a login success string
                        connection.Close();
                        return (true, null); // Success, no error message
                    }
                    else
                    {
                        // Unexpected result, provide details for debugging
                        connection.Close();
                        return (false, "Invalid email or password.");
                    }
                }
            }
        }


    }
}