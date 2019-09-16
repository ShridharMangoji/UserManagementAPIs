using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.DbOperation
{
    public class KidCRUD : IKidCRUD
    {
        readonly Entities db;
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
        public bool IsUserKidExists(long userId, long kidId)
        {
            return db.Kid.Any(x => x.UserId == userId && x.Id == kidId);
        }


        public bool IsUserKidExists(long id)
        {
            return db.Kid.Any(x => x.Id == id);
        }


    }
}
