using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Services
{
    public interface ITransactionService
    {
        Task<ResponseDto> Get10Latest();
        Task<ResponseDto> GetById(int id);
        Task<ResponseDto> Create(TransactionDto dto);
        Task<ResponseDto> Edit(TransactionDto dto);
        Task<ResponseDto> Delete(int id);
    }
}
