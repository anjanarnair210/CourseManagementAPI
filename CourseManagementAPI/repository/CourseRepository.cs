using CourseManagementAPI.interfaces;
using CourseManagementAPI.models;
using Microsoft.Data.SqlClient;

namespace CourseManagementAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Course";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"]),
                        Name = reader["Name"].ToString()!,
                        Description = reader["Description"].ToString()!,
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Duration = reader["Duration"].ToString()!,
                        StartOfCourse = Convert.ToDateTime(reader["StartOfCourse"]),
                        EndOfCourse = Convert.ToDateTime(reader["EndOfCourse"]),
                        Status = reader["Status"].ToString()!,
                        PriceOfCourse = Convert.ToDecimal(reader["PriceOfCourse"]),
                        ModifiedBy = reader["ModifiedBy"].ToString()!,
                        ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                        CreatedBy = reader["CreatedBy"].ToString()!,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        DepartmentId = reader["DepartmentId"] == DBNull.Value ? null : Convert.ToInt32(reader["DepartmentId"]),
                        Fees = reader["Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Fees"])
                    };

                    courses.Add(course);
                }

                con.Close();
            }

            return courses;
        }
        public Course? GetCourseById(int id)
        {
            Course? course = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Course WHERE CourseId = @CourseId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CourseId", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"]),
                        Name = reader["Name"].ToString()!,
                        Description = reader["Description"].ToString()!,
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Duration = reader["Duration"].ToString()!,
                        StartOfCourse = Convert.ToDateTime(reader["StartOfCourse"]),
                        EndOfCourse = Convert.ToDateTime(reader["EndOfCourse"]),
                        Status = reader["Status"].ToString()!,
                        PriceOfCourse = Convert.ToDecimal(reader["PriceOfCourse"]),
                        ModifiedBy = reader["ModifiedBy"].ToString()!,
                        ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                        CreatedBy = reader["CreatedBy"].ToString()!,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        DepartmentId = reader["DepartmentId"] == DBNull.Value ? null : Convert.ToInt32(reader["DepartmentId"]),
                        Fees = reader["Fees"] == DBNull.Value ? null : Convert.ToDecimal(reader["Fees"])
                    };
                }

                con.Close();
            }

            return course;
        }

        public void AddCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Course
        (
            CourseId,
            Name,
            Description,
            UserId,
            Duration,
            StartOfCourse,
            EndOfCourse,
            Status,
            PriceOfCourse,
            ModifiedBy,
            ModifiedAt,
            CreatedBy,
            CreatedAt,
            IsActive,
            DepartmentId,
            Fees
        )
        VALUES
        (
            @CourseId,
            @Name,
            @Description,
            @UserId,
            @Duration,
            @StartOfCourse,
            @EndOfCourse,
            @Status,
            @PriceOfCourse,
            @ModifiedBy,
            @ModifiedAt,
            @CreatedBy,
            @CreatedAt,
            @IsActive,
            @DepartmentId,
            @Fees
        )";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@UserId", course.UserId);
                cmd.Parameters.AddWithValue("@Duration", course.Duration);
                cmd.Parameters.AddWithValue("@StartOfCourse", course.StartOfCourse);
                cmd.Parameters.AddWithValue("@EndOfCourse", course.EndOfCourse);
                cmd.Parameters.AddWithValue("@Status", course.Status);
                cmd.Parameters.AddWithValue("@PriceOfCourse", course.PriceOfCourse);
                cmd.Parameters.AddWithValue("@ModifiedBy", course.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedAt", course.ModifiedAt);
                cmd.Parameters.AddWithValue("@CreatedBy", course.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", course.CreatedAt);
                cmd.Parameters.AddWithValue("@IsActive", course.IsActive);
                cmd.Parameters.AddWithValue("@DepartmentId", (object?)course.DepartmentId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fees", (object?)course.Fees ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Course
        SET
            Name = @Name,
            Description = @Description,
            UserId = @UserId,
            Duration = @Duration,
            StartOfCourse = @StartOfCourse,
            EndOfCourse = @EndOfCourse,
            Status = @Status,
            PriceOfCourse = @PriceOfCourse,
            ModifiedBy = @ModifiedBy,
            ModifiedAt = @ModifiedAt,
            CreatedBy = @CreatedBy,
            CreatedAt = @CreatedAt,
            IsActive = @IsActive,
            DepartmentId = @DepartmentId,
            Fees = @Fees
        WHERE CourseId = @CourseId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@UserId", course.UserId);
                cmd.Parameters.AddWithValue("@Duration", course.Duration);
                cmd.Parameters.AddWithValue("@StartOfCourse", course.StartOfCourse);
                cmd.Parameters.AddWithValue("@EndOfCourse", course.EndOfCourse);
                cmd.Parameters.AddWithValue("@Status", course.Status);
                cmd.Parameters.AddWithValue("@PriceOfCourse", course.PriceOfCourse);
                cmd.Parameters.AddWithValue("@ModifiedBy", course.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedAt", course.ModifiedAt);
                cmd.Parameters.AddWithValue("@CreatedBy", course.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", course.CreatedAt);
                cmd.Parameters.AddWithValue("@IsActive", course.IsActive);
                cmd.Parameters.AddWithValue("@DepartmentId", (object?)course.DepartmentId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fees", (object?)course.Fees ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Course WHERE CourseId = @CourseId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CourseId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}