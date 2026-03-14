using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString ="Data Source=RITIKPC\\SQLEXPRESS;" +"initial catalog=ADONET;Integrated Security=True;Connect Timeout=30;" +"Encrypt=True;TrustServerCertificate=True;";

        Console.Write("Enter Department: ");
        string department = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            Console.WriteLine("-----------------------------PART 1---------------------------------");
            //part 1
            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment",conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Department",department);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No employees found");
                        return;
                    }
                    while (reader.Read())
                    {
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"EmpId      : {reader["EmpId"]}");
                        Console.WriteLine($"Name       : {reader["Name"]}");
                        Console.WriteLine($"Department : {reader["Department"]}");
                        Console.WriteLine($"Phone      : {reader["Phone"]}");
                        Console.WriteLine($"Email      : {reader["Email"]}");
                    }
                }

            }

            Console.WriteLine("-----------------------------PART 2---------------------------------");

            //part 2 
            using (SqlCommand cmd2 = new SqlCommand("sp_GetDepartmentEmployeeCount", conn))
            {
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Department", department);

                SqlParameter outputPram = new SqlParameter
                {
                    ParameterName = "@TotalEmployees",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd2.Parameters.Add(outputPram);
                cmd2.ExecuteNonQuery();

                int totalEmployees = (int)cmd2.Parameters["@TotalEmployees"].Value;
                Console.WriteLine($"\nTotal employees in {department}: {totalEmployees}");



            }

            Console.WriteLine("-----------------------------PART 3---------------------------------");

            //part 3

            using (SqlCommand cmd3 = new SqlCommand("sp_GetEmployeeOrders", conn))
            {
                cmd3.CommandType = CommandType.StoredProcedure;

               

                using (SqlDataReader reader = cmd3.ExecuteReader())
                {
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine($"{"Name",-15} {"Dept",-10} {"OrderId",-8} {"Amount",-12} {"Date",-20}");
                    Console.WriteLine("---------------------------------------------------------------");

                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["Name"],-15} " +
                            $"{reader["Department"],-10} " +
                            $"{reader["OrderId"],-8} " +
                            $"{reader["OrderAmount"],-12} " +
                            $"{Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),-20}"
                        );
                    }

                }
            }


            Console.WriteLine("-----------------------------PART 4---------------------------------");

            //part 4

            using (SqlCommand cmd4 = new SqlCommand("sp_GetDuplicateEmployees", conn))
            {
                cmd4.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd4.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No duplicate phone numbers found.");
                        return;
                    }

                    Console.WriteLine("Duplicate Employees:");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"{"EmpId",-6} {"Name",-15} {"Dept",-10} {"Phone",-15} {"Email",-20}");
                    Console.WriteLine("----------------------------------------------------");

                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["EmpId"],-6} " +
                            $"{reader["Name"],-15} " +
                            $"{reader["Department"],-10} " +
                            $"{reader["Phone"],-15} " +
                            $"{reader["Email"],-20}"
                        );
                    }
                }
            }
        }
    }
}