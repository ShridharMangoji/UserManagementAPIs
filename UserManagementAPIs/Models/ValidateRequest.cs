using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BAL.BalConstants;
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

        internal static bool AddUser(UserRequest req)
        {
            if (req == null || req.User==null || req.User.Age <= 0 || string.IsNullOrEmpty(req.User.Email) ||
                string.IsNullOrEmpty(req.User.Name) || string.IsNullOrEmpty(req.User.PhoneNumber))
                return false;
            else
            {
                bool isEmail = Regex.IsMatch(req.User.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                    return true;
                else
                    return false;
            }
               
        }

        internal static bool AddKid(long id, KidRequest req)
        {
            if (id <= 0 || req == null ||req.Kid==null|| req.Kid.Age <= 0 || string.IsNullOrEmpty(req.Kid.FirstName) ||
                string.IsNullOrEmpty(req.Kid.LastName))
                return false;
            else
                return true;
        }

        internal static bool AddHome(long id, HomeRequest home)
        {
            if (home == null || home.Home==null ||string.IsNullOrEmpty(home.Home.Address) || string.IsNullOrEmpty(home.Home.HomeType) ||
                string.IsNullOrEmpty(home.Home.State) || string.IsNullOrEmpty(home.Home.Zipcode))
                return false;
            else
                return true;
        }

        internal static bool UpdateUser(UserRequest req)
        {
            if (req == null || req.User == null || req.User.Id <= 0 || req.User.Age <= 0 || string.IsNullOrEmpty(req.User.Email) ||
                string.IsNullOrEmpty(req.User.Name) || string.IsNullOrEmpty(req.User.PhoneNumber))
                return false;
            else
            {
                bool isEmail = Regex.IsMatch(req.User.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                    return true;
                else
                    return false;
            }
        }

        internal static bool UpdateKid(long id, KidRequest req)
        {
            if (id <= 0 || req == null || req.Kid==null || req.Kid.Id <= 0 || req.Kid.Age <= 0 || string.IsNullOrEmpty(req.Kid.FirstName) || 
                string.IsNullOrEmpty(req.Kid.LastName))
                return false;
            else
                return true;
        }

        internal static bool UpdateHome(long id, HomeRequest req)
        {
            
            if (req == null ||req.Home==null|| req.Home.Id <= 0 || string.IsNullOrEmpty(req.Home.Address) 
                || string.IsNullOrEmpty(req.Home.HomeType) || string.IsNullOrEmpty(req.Home.State) || 
                string.IsNullOrEmpty(req.Home.Zipcode))
                return false;
            else
                return true;
        }

        internal static bool InActivateUser(long id)
        {
            if (id <= 0)
                return false;
            else
                return true;
        }

        internal static bool SearchRequest(SearchRequest req)
        {
            if (req == null || req.Filters == null || req.Filters.Count == 0||req.Filters.Count> Enum.GetNames(typeof(eFilters)).Length)
                return false;
            else
                return true;
        }
    }
}
