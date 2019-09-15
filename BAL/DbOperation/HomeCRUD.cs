using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.DbOperation
{
  public  class HomeCRUD
    {
        Entities db;
        public HomeCRUD()
        {
            db = new Entities();
        }
        ~HomeCRUD()
        {
            db.Dispose();
        }

        public void AddHome(Home home)
        {
            home.LastUpdate = DateTime.Now;
            db.Home.Add(home);
            db.SaveChanges();
        }

        public void UpdateHome(Home home)
        {
            home.LastUpdate = DateTime.Now;
            db.Home.Update(home);
            db.SaveChanges();
        }

        public bool IsUserHomeExists(long id)
        {
            return db.User.Any(x => x.Id == id);
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
    }
}
