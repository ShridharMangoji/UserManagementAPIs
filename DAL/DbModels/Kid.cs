using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.DbModels
{
    [DataContract]
    public partial class Kid
    {
        public Kid()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "age")]
        public int? Age { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
