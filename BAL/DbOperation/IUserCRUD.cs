using DAL.DbModels;

namespace BAL.DbOperation
{
    public interface IUserCRUD
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void GetUser(long id);
        void UpdateUser(User user);
    }
}