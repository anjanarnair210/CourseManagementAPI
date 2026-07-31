using CourseManagementAPI.interfaces;
using CourseManagementAPI.models;
using Microsoft.Data.SqlClient;

namespace CourseManagementAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString()!,
                        LastName = reader["LastName"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        PhoneNumber = reader["PhoneNumber"].ToString()!,
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        UserRole = reader["UserRole"].ToString()!,
                        Password = reader["Password"].ToString()!,
                        RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"]),
                        Status = reader["Status"].ToString()!,
                        ModifiedBy = reader["ModifiedBy"].ToString()!,
                        ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                        CreatedBy = reader["CreatedBy"].ToString()!,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsInAdvance = Convert.ToBoolean(reader["IsInAdvance"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        Age = Convert.ToInt32(reader["Age"])
                    };

                    users.Add(user);
                }

                con.Close();
            }

            return users;
        }

        public User? GetUserById(int id)
        {
            User? user = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString()!,
                        LastName = reader["LastName"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        PhoneNumber = reader["PhoneNumber"].ToString()!,
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        UserRole = reader["UserRole"].ToString()!,
                        Password = reader["Password"].ToString()!,
                        RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"]),
                        Status = reader["Status"].ToString()!,
                        ModifiedBy = reader["ModifiedBy"].ToString()!,
                        ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                        CreatedBy = reader["CreatedBy"].ToString()!,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsInAdvance = Convert.ToBoolean(reader["IsInAdvance"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        Age = Convert.ToInt32(reader["Age"])
                    };
                }

                con.Close();
            }

            return user;
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Users
        (
            UserId,
            FirstName,
            LastName,
            Email,
            PhoneNumber,
            DepartmentId,
            UserRole,
            Password,
            RegisteredDate,
            Status,
            ModifiedBy,
            ModifiedAt,
            CreatedBy,
            CreatedAt,
            IsInAdvance,
            IsActive,
            Age
        )
        VALUES
        (
            @UserId,
            @FirstName,
            @LastName,
            @Email,
            @PhoneNumber,
            @DepartmentId,
            @UserRole,
            @Password,
            @RegisteredDate,
            @Status,
            @ModifiedBy,
            @ModifiedAt,
            @CreatedBy,
            @CreatedAt,
            @IsInAdvance,
            @IsActive,
            @Age
        )";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RegisteredDate", user.RegisteredDate);
                cmd.Parameters.AddWithValue("@Status", user.Status);
                cmd.Parameters.AddWithValue("@ModifiedBy", user.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedAt", user.ModifiedAt);
                cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                cmd.Parameters.AddWithValue("@IsInAdvance", user.IsInAdvance);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Users
                        SET
                            FirstName = @FirstName,
                            LastName = @LastName,
                            Email = @Email,
                            PhoneNumber = @PhoneNumber,
                            DepartmentId = @DepartmentId,
                            UserRole = @UserRole,
                            Password = @Password,
                            RegisteredDate = @RegisteredDate,
                            Status = @Status,
                            ModifiedBy = @ModifiedBy,
                            ModifiedAt = @ModifiedAt,
                            CreatedBy = @CreatedBy,
                            CreatedAt = @CreatedAt,
                            IsInAdvance = @IsInAdvance,
                            IsActive = @IsActive,
                            Age = @Age
                        WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RegisteredDate", user.RegisteredDate);
                cmd.Parameters.AddWithValue("@Status", user.Status);
                cmd.Parameters.AddWithValue("@ModifiedBy", user.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedAt", user.ModifiedAt);
                cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                cmd.Parameters.AddWithValue("@IsInAdvance", user.IsInAdvance);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public List<User> SearchUsers(UserSearchRequest request)
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM Users WHERE 1=1";

                // Global Search
                if (!string.IsNullOrWhiteSpace(request.Search))
                {
                    query += @" AND (
                            FirstName LIKE @Search OR
                            LastName LIKE @Search OR
                            Email LIKE @Search OR
                            PhoneNumber LIKE @Search OR
                            UserRole LIKE @Search
                        )";
                }

                // Department Filter
                if (request.DepartmentId.HasValue)
                {
                    query += " AND DepartmentId = @DepartmentId";
                }

                // Role Filter
                if (!string.IsNullOrWhiteSpace(request.Role))
                {
                    query += " AND UserRole = @Role";
                }

                // Status Filter
                if (!string.IsNullOrWhiteSpace(request.Status))
                {
                    query += " AND Status = @Status";
                }

                // Sorting
                if (!string.IsNullOrWhiteSpace(request.SortBy))
                {
                    switch (request.SortBy.ToLower())
                    {
                        case "firstname":
                            query += " ORDER BY FirstName";
                            break;

                        case "email":
                            query += " ORDER BY Email";
                            break;

                        case "phonenumber":
                            query += " ORDER BY PhoneNumber";
                            break;

                        case "registereddate":
                            query += " ORDER BY RegisteredDate";
                            break;

                        default:
                            query += " ORDER BY UserId";
                            break;
                    }
                }
                else
                {
                    query += " ORDER BY UserId";
                }

                // Ascending / Descending
                query += request.Ascending ? " ASC" : " DESC";

                // Pagination
                query += " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Search", "%" + (request.Search ?? "") + "%");

                if (request.DepartmentId.HasValue)
                    cmd.Parameters.AddWithValue("@DepartmentId", request.DepartmentId.Value);

                if (!string.IsNullOrWhiteSpace(request.Role))
                    cmd.Parameters.AddWithValue("@Role", request.Role);

                if (!string.IsNullOrWhiteSpace(request.Status))
                    cmd.Parameters.AddWithValue("@Status", request.Status);

                cmd.Parameters.AddWithValue("@Offset", (request.Page - 1) * request.PageSize);
                cmd.Parameters.AddWithValue("@PageSize", request.PageSize);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString()!,
                        LastName = reader["LastName"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        PhoneNumber = reader["PhoneNumber"].ToString()!,
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        UserRole = reader["UserRole"].ToString()!,
                        Password = reader["Password"].ToString()!,
                        RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"]),
                        Status = reader["Status"].ToString()!,
                        ModifiedBy = reader["ModifiedBy"].ToString()!,
                        ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                        CreatedBy = reader["CreatedBy"].ToString()!,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsInAdvance = Convert.ToBoolean(reader["IsInAdvance"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        Age = Convert.ToInt32(reader["Age"])
                    };

                    users.Add(user);
                }

                con.Close();
            }

            return users;
        }
    }
}