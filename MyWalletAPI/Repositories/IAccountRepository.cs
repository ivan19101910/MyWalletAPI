using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Repositories
{
    public interface IAccountRepository
    {
        Task<FullAccountInfoDto> GetById(Guid id);
    }
}
