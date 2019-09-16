using BAL.Model;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPIs.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Request
    {
        public string AppVersion { get; set; }
        public string OsType { get; set; }
    }


    public class SearchRequest : Request
    {
        public List<FilterModel> Filters { get; set; }
    }

    public class UserRequest : Request
    {
        public  User User { get; set; }
    }

    public class KidRequest : Request
    {
        public Kid Kid { get; set; }
    }
    public class HomeRequest : Request
    {
        public Home Home { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member


}
