using System.Runtime.Serialization;

namespace Borrower.Dto
{
    [DataContract]
    public class Withdraw
    {
        [DataMember(EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal Amount { get; set; }
    }
}