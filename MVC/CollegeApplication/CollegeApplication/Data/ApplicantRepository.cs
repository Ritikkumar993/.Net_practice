using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CollegeApplication.Models;
namespace CollegeApplication.Data
{
    public class ApplicantRepository
    {
        private readonly string _connectionString;
        public ApplicantRepository(string connectionString)
        {

            _connectionString = connectionString;
        }

        public int AddApplicant(Applicant app)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO CollegeApplicants 
                                 (FullName, Email, DateOfBirth, Course, PhoneNo, Gender, Address) 
                                 OUTPUT INSERTED.RegistrationNo 
                                 VALUES 
                                 (@FullName, @Email, @DateOfBirth, @Course, @PhoneNo, @Gender, @Address)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", app.FullName);
                    cmd.Parameters.AddWithValue("@Email", app.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", app.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Course", app.Course);
                    cmd.Parameters.AddWithValue("@PhoneNo", app.PhoneNo);
                    cmd.Parameters.AddWithValue("@Gender", app.Gender);
                    cmd.Parameters.AddWithValue("@Address", app.Address);

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public List<Applicant> GetAllApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM CollegeApplicants ORDER BY RegistrationNo DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicants.Add(new Applicant
                            {
                                RegistrationNo = Convert.ToInt32(reader["RegistrationNo"]),
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Course = reader["Course"].ToString(),
                                PhoneNo = reader["PhoneNo"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Address = reader["Address"].ToString()
                            });
                        }
                    }
                }
            }
            return applicants;
        }

        public Applicant GetApplicantById(int regNo)
        {
            Applicant applicant = new Applicant();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM CollegeApplicants WHERE RegistrationNo = @RegistrationNo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegistrationNo", regNo);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicant.RegistrationNo = Convert.ToInt32(reader["RegistrationNo"]);
                            applicant.FullName = reader["FullName"].ToString();
                            applicant.Email = reader["Email"].ToString();
                            applicant.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            applicant.Course = reader["Course"].ToString();
                            applicant.PhoneNo = reader["PhoneNo"].ToString();
                            applicant.Gender = reader["Gender"].ToString();
                            applicant.Address = reader["Address"].ToString();
                        }
                    }
                }
            }
            return applicant;
        }

        public void UpdateApplicant(Applicant app)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE CollegeApplicants SET 
                                 FullName=@FullName, Email=@Email, DateOfBirth=@DateOfBirth, 
                                 Course=@Course, PhoneNo=@PhoneNo, Gender=@Gender, Address=@Address 
                                 WHERE RegistrationNo=@RegistrationNo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegistrationNo", app.RegistrationNo);
                    cmd.Parameters.AddWithValue("@FullName", app.FullName);
                    cmd.Parameters.AddWithValue("@Email", app.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", app.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Course", app.Course);
                    cmd.Parameters.AddWithValue("@PhoneNo", app.PhoneNo);
                    cmd.Parameters.AddWithValue("@Gender", app.Gender);
                    cmd.Parameters.AddWithValue("@Address", app.Address);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteApplicant(int regNo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM CollegeApplicants WHERE RegistrationNo=@RegistrationNo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegistrationNo", regNo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool isEmailExists(string email, int regNo)
        {
            string query = "SELECT COUNT(1) FROM CollegeApplicants WHERE Email= @Email AND RegistrationNo != @RegistrationNo";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@RegistrationNo", regNo);
                    con.Open();

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }



    }
}
