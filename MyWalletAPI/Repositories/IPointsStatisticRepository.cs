using MyWalletAPI.Models;

namespace MyWalletAPI.Repositories
{
    public interface IPointsStatisticRepository
    {
        Task<IEnumerable<PointsStatistic>> GetByAccountId(Guid id);
        Task<PointsStatistic> Create(PointsStatistic pointsStatistic);
    }
}
