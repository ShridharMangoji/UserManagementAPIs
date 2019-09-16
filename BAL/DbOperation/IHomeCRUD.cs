using DAL.DbModels;

namespace BAL.DbOperation
{
    public interface IHomeCRUD
    {
        void AddHome(Home home);
        bool IsUserHomeExists(long id);
        void UpdateHome(Home home);
    }
}