using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.DbModels
{
    [DataContract]
    public partial class Kid
    {
        public long Id { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
        public long UserId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual User User { get; set; }
    }
}
