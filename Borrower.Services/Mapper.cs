namespace Borrower.Services
{
    internal static class Mapper
    {
        public static Dto.User ToDto(this Dal.User user)
        {
            return new Dto.User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreditLimit = user.CreditLimit,
                Balance = user.Balance,
                AvailableFunds = user.AvailableFunds,
            };
        }
    }
}