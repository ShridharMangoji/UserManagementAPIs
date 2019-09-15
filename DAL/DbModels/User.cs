using System;
using System.Collections.Generic;
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

        public long Id { get; set; }
        public string Name { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "home")]
        public virtual ICollection<Home> Home { get; set; }
        [DataMember(Name = "kids")]
        public virtual ICollection<Kid> Kid { get; set; }
    }
}
