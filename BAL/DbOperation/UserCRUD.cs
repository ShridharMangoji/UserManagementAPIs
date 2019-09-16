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
        readonly Entities db;
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
            user.LastUpdate = DateTime.Now;
            user.IsActive = true;
            db.User.Add(user);
            db.SaveChanges();

        }

        public bool IsUserExists(long id)
        {
            return db.User.Any(x => x.Id == id && x.IsActive == true);
        }

        public User GetUser(long id)
        {
            var data = db.User.Where(x => x.Id == id && x.IsActive == true).Include(x => x.Kid).Include(x => x.Home).FirstOrDefault();
            return data;
        }

        public List<User> GetUsers()
        {
            var data = db.User.Where(x => x.IsActive == true).Include(x => x.Kid).Include(x => x.Home).ToList();
            return data;
        }

        public List<User> GetUsers(List<string> states, List<string> homeType, List<string> homeZipCode, List<string> numberOfKids, bool isAgeFilterExists, int minAge, int maxAge)
        {
            var userList = new List<User>();
            var userIdList = db.Home.
                Where(x => !states.Contains(x.State) && !homeType.Contains(x.HomeType) && !homeZipCode.Contains(x.Zipcode) && !numberOfKids.Contains(x.User.Kid.Count.ToString())).
                Select(x => x.UserId).ToList();

            if (isAgeFilterExists)
                userList = db.User.Where(x => !userIdList.Contains(x.Id) && x.IsActive == true && x.Age >= minAge && x.Age <= maxAge).Include(x => x.Kid).Include(x => x.Home).ToList();
            else
                userList = db.User.Where(x => !userIdList.Contains(x.Id)).Include(x => x.Kid).Include(x => x.Home).ToList();
            return userList;
        }




        public void UpdateUser(User user)
        {
            user.LastUpdate = DateTime.Now;
            db.User.Update(user);
            db.SaveChanges();
        }

        public int InActivateUser(long id)
        {
            var status = 1;
            var home = db.User.FirstOrDefault(x => x.Id == id);
            if (home != null)
            {
                home.LastUpdate = DateTime.Now;
                home.IsActive = false;
                status = db.SaveChanges();
            }
            return status;
        }

        public bool IsUserExists(string phoneNumber, string email)
        {
            return db.User.Any(x => x.PhoneNumber == phoneNumber && x.Email == email && x.IsActive == true);
        }
    }
}
