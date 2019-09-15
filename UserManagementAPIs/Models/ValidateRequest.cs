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
            throw new NotImplementedException();
        }

        internal static bool AddKid(Kid kid)
        {
            throw new NotImplementedException();
        }
    }
}
