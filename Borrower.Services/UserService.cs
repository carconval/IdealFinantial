using System;
using System.Threading;
using System.Threading.Tasks;
using Borrower.Dal;
using Borrower.Dto;
using MongoDB.Bson;
using MongoDB.Driver;
using DtoUser = Borrower.Dto.User;
using DalUser = Borrower.Dal.User;

namespace Borrower.Services
{
    internal class UserService : IUserService
    {
        private readonly BorrowerContext _context;
        private readonly CancellationToken _cancellationToken;

        public UserService(BorrowerContext context, CancellationToken cancellationToken)
        {
            _context = context;
            _cancellationToken = cancellationToken;
        }

        public async Task<DtoUser> GetCurrentUserAsync()
        {
            var users = _context.Users;
            var filter = Builders<DalUser>.Filter.Empty;
            var user = await users.Find(filter).FirstOrDefaultAsync(cancellationToken: _cancellationToken);
            if (user != null) return user.ToDto();

            user = CreateUser();
            await users.InsertOneAsync(user, cancellationToken: _cancellationToken);
            return user.ToDto();
        }

        private static DalUser CreateUser()
        {
            return new DalUser
            {
                Id = ObjectId.GenerateNewId().ToString(),
                FirstName = "Carlos",
                LastName = "Contreras",
                CreditLimit = 100000,
                Balance = 50000,
                AvailableFunds = 50000,
            };
        }

        public async Task<DtoUser> MakeWithdrawAsync(Withdraw withdraw)
        {
            if (withdraw == null) return null;

            var users = _context.Users;
            var filter = Builders<DalUser>.Filter.Eq(nameof(DtoUser.Id), withdraw.UserId);
            var user = await users.Find(filter).FirstOrDefaultAsync(cancellationToken: _cancellationToken);
            if (user == null) return null;

            user.MakeWithdraw(withdraw.Amount);
            var update = Builders<DalUser>.Update
                .Set(u => u.AvailableFunds, user.AvailableFunds)
                .Set(u => u.Balance, user.Balance);
            await users.UpdateOneAsync(filter, update, cancellationToken: _cancellationToken);

            return user.ToDto();
        }

    }
}
