using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using global::LINQwithMVC.Models;
using Microsoft.Extensions.Configuration;


namespace LINQwithMVC.Data
{
    public class EmployeeRepo
    {
        private readonly string _connectionString;
        public EmployeeRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetFilteredEmployees()
        {
            List<Employee> employee = new List<Employee>();
            using (SqlConnection con = new SqlConnection(_connectionString)) 
            {
                string query = "select Id, Name, Department, Salary from Employees";
                SqlCommand cmd = new SqlCommand(query,con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employee.Add(new Employee
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = (decimal)reader["Salary"]
                    });
                }
            }
            return employee;
        }
    }
}
