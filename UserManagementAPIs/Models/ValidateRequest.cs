using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
