using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.DbModels
{
    [DataContract]
    public partial class Home
    {
        public long Id { get; set; }
        [DataMember(Name = "homeType")]
        public string HomeType { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
