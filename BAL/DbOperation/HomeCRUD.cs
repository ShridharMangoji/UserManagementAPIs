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
            db.Home.Add(home);
            db.SaveChanges();
        }

        public void UpdateHome(Home home)
        {
            db.Home.Update(home);
            db.SaveChanges();
        }

        public bool IsUserHomeExists(long id)
        {
            return db.User.Any(x => x.Id == id);
        }
    }
}
