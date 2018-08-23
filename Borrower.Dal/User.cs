using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Borrower.Dal
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal CreditLimit { get; set; }

        public decimal Balance { get; set; }

        public decimal AvailableFunds { get; set; }

        public void MakeWithdraw(decimal amount)
        {
            AvailableFunds = AvailableFunds - amount;
            Balance = Balance + amount;
        }
    }
}
