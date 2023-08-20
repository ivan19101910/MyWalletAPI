using Azure;
using MyWalletAPI.Models.Dtos;
using MyWalletAPI.Repositories;

namespace MyWalletAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        protected ResponseDto _response;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _response = new ResponseDto();
        }
        private async Task<ResponseDto> PerformRequest<TInput, TReturn>(Func<TInput, Task<TReturn>> Action, TInput parameter)
        {
            try
            {
                _response.Result = await Action(parameter);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        public Task<ResponseDto> Create(TransactionDto dto) => PerformRequest(_transactionRepository.Create, dto);

        public Task<ResponseDto> Delete(int id) => PerformRequest(_transactionRepository.Delete, id);

        public Task<ResponseDto> Edit(TransactionDto dto) => PerformRequest(_transactionRepository.Edit, dto);

        public async Task<ResponseDto> Get10Latest()
        {
            try
            {
                IEnumerable<TransactionDto> transactionDtos = await _transactionRepository.Get10Latest();
                _response.Result = transactionDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        public Task<ResponseDto> GetById(int id) => PerformRequest(_transactionRepository.GetById, id);
    }
}
