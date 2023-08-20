using Microsoft.AspNetCore.Mvc;
using MyWalletAPI.Models.Dtos;
using MyWalletAPI.Services;

namespace MyWalletAPI.Controllers
{
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<object> Get10Latest()
        {
            return await _transactionService.Get10Latest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetByAccountId(int id)
        {
            return await _transactionService.GetById(id);
        }

        [HttpPost]
        public async Task<object> Create([FromBody] TransactionDto dto)
        {
            return await _transactionService.Create(dto);
        }
        [HttpPut]
        public async Task<object> Edit([FromBody] TransactionDto dto)
        {
            return await _transactionService.Edit(dto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            return await _transactionService.Delete(id);
        }
    }
}
