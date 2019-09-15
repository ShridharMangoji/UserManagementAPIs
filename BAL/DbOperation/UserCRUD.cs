using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DbOperation
{
    public class UserCRUD
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

        public bool IsUserExists(long id)
        {
            return db.User.Any(x => x.Id == id);
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

        public int MapUserKid(long kidId, long userId)
        {
            var status = 1;
            var kid = db.Kid.FirstOrDefault(x => x.Id == kidId);
            if (kid != null)
            {
                kid.UserId = userId;
                status = db.SaveChanges();
            }
            return status;
        }

        public int MapUserHome(long homeId, long userId)
        {
            var status = 1;
            var home = db.Home.FirstOrDefault(x => x.Id == homeId);
            if (home != null)
            {
                home.UserId = userId;
                status = db.SaveChanges();
            }
            return status;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
