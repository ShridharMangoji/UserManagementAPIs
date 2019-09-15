using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User GetUser(long id)
        {
            var data = db.User.Find(id);
            return data;
        }

        public List<User> GetUsers()
        {
            var data = db.User.ToList();
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

        public void AddKid(Kid kid)
        {
            throw new NotImplementedException();
        }
    }
}
