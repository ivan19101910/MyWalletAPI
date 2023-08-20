using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Services
{
    public interface IAccountService
    {
        Task<ResponseDto> GetById(Guid id);
        Task<PointsStatistic> CalculateDailyPoints(Guid id);
    }
}
