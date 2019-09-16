using System.Collections.Generic;
using DAL.DbModels;

namespace BAL.DbOperation
{
    public interface IUserCRUD
    {
        void AddUser(User user);
        User GetUser(long id);
        List<User> GetUsers();
        List<User> GetUsers(List<string> states, List<string> homeType, List<string> homeZipCode, List<string> numberOfKids, bool isAgeFilterExists, int minAge, int maxAge);
        int InActivateUser(long id);
        bool IsUserExists(long id);
        bool IsUserExists(string phoneNumber, string email);
        void UpdateUser(User user);
    }
}