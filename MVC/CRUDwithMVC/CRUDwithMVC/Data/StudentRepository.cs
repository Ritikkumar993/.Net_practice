using CRUDwithMVC.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRUDwithMVC.Data
{

    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // 🔹 READ
        public List<Student> GetAll()
        {
            List<Student> students = new();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsMaster", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"],
                        City = reader["City"].ToString()
                    });
                }
            }

            return students;
        }

        // 🔹 CREATE
        public void Add(Student student)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "INSERT INTO StudentsMaster (Name, Age, City) VALUES (@Name, @Age, @City)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@City", student.City);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // 🔹 UPDATE
        public void Update(Student student)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "UPDATE StudentsMaster SET Name=@Name, Age=@Age, City=@City WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@City", student.City);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // 🔹 DELETE
        public void Delete(int id)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("DELETE FROM StudentsMaster WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // 🔹 GET BY ID
        public Student GetById(int id)
        {
            Student student = null;

            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsMaster WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                student = new Student
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Age = (int)reader["Age"],
                    City = reader["City"].ToString()
                };
            }

            return student;
        }
    }
}
