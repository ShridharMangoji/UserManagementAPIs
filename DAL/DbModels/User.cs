using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DAL.DbModels
{
    [DataContract]
    public partial class User
    {
        public User()
        {
            Home = new HashSet<Home>();
            Kid = new HashSet<Kid>();
        }
        [DataMember(Name = "userId")]
        public long Id { get; set; }
        [DataMember(Name = "userName")]
        public string Name { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }

        [DataMember(Name = "home")]
        public virtual ICollection<Home> Home { get; set; }
        [DataMember(Name = "kids")]
        public virtual ICollection<Kid> Kid { get; set; }
    }
}
