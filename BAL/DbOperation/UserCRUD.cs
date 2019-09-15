using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DbOperation
{
    public class UserCRUD : IUserCRUD
    {
        Entities db;
        public UserCRUD()
        {
            db = new Entities();

        }
        ~UserCRUD()
        {
            db.Dispose();
        }

        public void AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }

        public Task<User> GetUser(long id)
        {
            var data = db.User.FindAsync(id);
            return data;
        }

        public Task<List<User>> GetUsers()
        {
            var data = db.User.ToListAsync();
            return data;
        }

        public void DeleteUser(User user)
        {

        }
        public void UpdateUser(User user)
        {

        }

        void IUserCRUD.GetUser(long id)
        {
            throw new NotImplementedException();
        }
    }
}
