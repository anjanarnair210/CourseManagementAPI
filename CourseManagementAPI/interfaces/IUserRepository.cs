using CourseManagementAPI.models;

namespace CourseManagementAPI.interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User? GetUserById(int id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        List<User> SearchUsers(UserSearchRequest request);
    }
}