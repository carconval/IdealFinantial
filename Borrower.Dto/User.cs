using System;
using System.Runtime.Serialization;

namespace Borrower.Dto
{
    [DataContract]
    public class User
    {
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal CreditLimit { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal Balance { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal AvailableFunds { get; set; }
    }
}
