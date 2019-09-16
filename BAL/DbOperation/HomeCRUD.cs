using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.DbOperation
{
    public class HomeCRUD : IHomeCRUD
    {
        readonly Entities db;
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
            home.Id = 0;
            home.LastUpdate = DateTime.Now;
            db.Home.Add(home);
            db.SaveChanges();
        }

        public void UpdateHome(Home home)
        {
            db.Entry(home).State = EntityState.Modified;
            db.Entry(home).Property(x => x.UserId).IsModified = false;
            home.LastUpdate = DateTime.Now;
            db.Home.Update(home);
            db.SaveChanges();
        }

        public bool IsUserHomeExists(long id)
        {
            return db.User.Any(x => x.Id == id);
        }

    }
}
