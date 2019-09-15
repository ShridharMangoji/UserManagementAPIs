using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UserManagementAPIs.Models
{
    public class ValidateRequest
    {
        public static bool GetUser(long id)
        {
            if (id <= 0)
                return false;
            else
                return true;
        }

        internal static bool AddUser(User user)
        {
            if (user == null || user.Age <= 0 || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.PhoneNumber))
                return false;
            else
                return true;
        }

        internal static bool AddKid(long id, Kid kid)
        {
            if (id <= 0 || kid == null || kid.Age <= 0 || string.IsNullOrEmpty(kid.FirstName) || string.IsNullOrEmpty(kid.LastName))
                return false;
            else
                return true;
        }

        internal static bool AddHome(long id, Home home)
        {
            if (home == null || string.IsNullOrEmpty(home.Address) || string.IsNullOrEmpty(home.HomeType) || string.IsNullOrEmpty(home.State) || string.IsNullOrEmpty(home.Zipcode))
                return false;
            else
                return true;
        }

        internal static bool UpdateUser(User user)
        {
            if (user == null || user.Id <= 0 || user.Age <= 0 || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.PhoneNumber))
                return false;
            else
                return true;
        }

        internal static bool UpdateKid(long id, Kid kid)
        {
            if (id <= 0 || kid == null || kid.Id <= 0 || kid.Age <= 0 || string.IsNullOrEmpty(kid.FirstName) || string.IsNullOrEmpty(kid.LastName))
                return false;
            else
                return true;
        }

        internal static bool UpdateHome(long id, Home home)
        {
            if (home == null || home.Id <= 0 || string.IsNullOrEmpty(home.Address) || string.IsNullOrEmpty(home.HomeType) || string.IsNullOrEmpty(home.State) || string.IsNullOrEmpty(home.Zipcode))
                return false;
            else
                return true;
        }
    }
}
