using CourseManagementAPI.models;

namespace CourseManagementAPI.interfaces
{
    public interface IAssignmentRepository
    {
        List<Assignment> GetAllAssignments();

        Assignment? GetAssignmentById(int id);

        void AddAssignment(Assignment assignment);

        void UpdateAssignment(Assignment assignment);

        void DeleteAssignment(int id);
    }
}