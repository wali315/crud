using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using crud.Data;

public class StudentInfoDAL
{
    private readonly string connectionString = MyConfiguration.GetConnectionString();

    public void InsertStudent(int id, string name, int age, string gender, string hobbies)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "InsertStudentInfo";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Hobbies", hobbies);
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateStudent(int id, string name, int age, string gender, string hobbies)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UpdateStudentInfo";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Hobbies", hobbies);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteStudent(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DeleteStudentInfo";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public DataRow GetStudentById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "GetStudentInfoById";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                }
            }
        }
    }


    public DataTable GetStudents()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "GetStudentsInfo";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }
        return dataTable;
    }

}