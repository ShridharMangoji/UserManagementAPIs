using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.DbModels
{
    [DataContract]
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [DataMember(Name = "age")]
        public int? Age { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        public long? Kids { get; set; }
        public long? Home { get; set; }
        [DataMember(Name = "home")]
        public virtual Home HomeNavigation { get; set; }
        [DataMember(Name = "kids")]
        public virtual Kid KidsNavigation { get; set; }
    }
}
