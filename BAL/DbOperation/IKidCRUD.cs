using DAL.DbModels;

namespace BAL.DbOperation
{
    public interface IKidCRUD
    {
        void AddKid(Kid kid);
        bool IsUserKidExists(long id);
        bool IsUserKidExists(long userId, long kidId);
        void UpdateKid(Kid kid);
    }
}