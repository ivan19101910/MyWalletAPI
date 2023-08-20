using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionDto>> Get10Latest();
        Task<TransactionDto> GetById(int id);
        Task<TransactionDto> Create(TransactionDto dto);
        Task<TransactionDto> Edit(TransactionDto dto);
        Task<bool> Delete(int id);
    }
}
