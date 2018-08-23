using System.Threading.Tasks;

namespace Borrower.Services
{
    public interface IUserService
    {
        Task<Dto.User> GetCurrentUserAsync();
        Task<Dto.User> MakeWithdrawAsync(Dto.Withdraw withdraw);
    }
}