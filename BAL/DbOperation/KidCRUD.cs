using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.DbOperation
{
    public class KidCRUD
    {
        Entities db;
        public KidCRUD()
        {
            db = new Entities();
        }
        ~KidCRUD()
        {
            db.Dispose();
        }

        public void AddKid(Kid kid)
        {
            kid.LastUpdate = DateTime.Now;
            db.Kid.Add(kid);
            db.SaveChanges();
        }

        public void UpdateKid(Kid kid)
        {
            kid.LastUpdate = DateTime.Now;
            db.Kid.Update(kid);
            db.SaveChanges();
        }

        public bool IsUserKidExists(long id)
        {
            return db.Kid.Any(x => x.Id == id);
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

    }
}
