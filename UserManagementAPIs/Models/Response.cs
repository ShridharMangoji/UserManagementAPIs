using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserManagementAPIs.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    [DataContract]
    public class BaseResponse
    {
        [DataMember(Name ="status_code")]
        public HttpStatusCode HttpStatusCode { get; set; }
        [DataMember(Name = "status_message")]

        public string HttpStatusMessage { get; set; }
    }
    public class UserListResponse:BaseResponse
    {
        [DataMember(Name = "user_list")]
        public List<User> User { get; set; }
    }

    public class UserResponse : BaseResponse
    {
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
