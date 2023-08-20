using Microsoft.AspNetCore.Mvc;
using MyWalletAPI.Models.Dtos;
using MyWalletAPI.Services;

namespace MyWalletAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetAllInfoById(Guid id)
        {
            await _accountService.CalculateDailyPoints(id);
            return await _accountService.GetById(id);
        }
    }
}
