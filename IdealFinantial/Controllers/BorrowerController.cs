using System.Threading.Tasks;
using Borrower.Dto;
using Borrower.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdealFinantial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : Controller
    {
        private readonly IUserService _svc;

        public BorrowerController(IUserService svc)
        {
            _svc = svc;
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> GetAsync()
        {
            var user = await _svc.GetCurrentUserAsync();
            if (user == null) return BadRequest();
            return user;
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> MakeWithdrawAsync([FromBody] Withdraw withdraw)
        {
            var user = await _svc.MakeWithdrawAsync(withdraw);
            if (user == null) return BadRequest();
            return user;
        }
    }
}