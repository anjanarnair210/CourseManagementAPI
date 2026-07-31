using CourseManagementAPI.interfaces;
using CourseManagementAPI.models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CourseManagementAPI.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AssignmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<Assignment> GetAllAssignments()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Assignment>(
                    "sp_GetAllAssignments",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public Assignment? GetAssignmentById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.QueryFirstOrDefault<Assignment>(
                    "sp_GetAssignmentById",
                    new { AssignmentId = id },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void AddAssignment(Assignment assignment)
        {
            string query = @"INSERT INTO Assignment
                    (
                        AssignmentId,
                        UserId,
                        CourseId,
                        ModifiedBy,
                        ModifiedAt,
                        CreatedBy,
                        CreatedAt,
                        IsActive
                    )
                    VALUES
                    (
                        @AssignmentId,
                        @UserId,
                        @CourseId,
                        @ModifiedBy,
                        @ModifiedAt,
                        @CreatedBy,
                        @CreatedAt,
                        @IsActive
                    )";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(query, assignment);
            }
        }

        public void UpdateAssignment(Assignment assignment)
        {
            string query = @"UPDATE Assignment
                             SET UserId=@UserId,
                                 CourseId=@CourseId,
                                 ModifiedBy=@ModifiedBy,
                                 ModifiedAt=@ModifiedAt,
                                 CreatedBy=@CreatedBy,
                                 CreatedAt=@CreatedAt,
                                 IsActive=@IsActive
                             WHERE AssignmentId=@AssignmentId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(query, assignment);
            }
        }

        public void DeleteAssignment(int id)
        {
            string query = "DELETE FROM Assignment WHERE AssignmentId=@AssignmentId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(query, new { AssignmentId = id });
            }
        }
    }
}