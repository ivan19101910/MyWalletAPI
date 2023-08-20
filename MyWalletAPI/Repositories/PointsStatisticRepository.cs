using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWalletAPI.DbContexts;
using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Repositories
{
    public class PointsStatisticRepository : IPointsStatisticRepository
    {
        private readonly MyWalletApiDbContext _db;
        private IMapper _mapper;

        public PointsStatisticRepository(MyWalletApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PointsStatistic> Create(PointsStatistic pointsStatistic)
        {
            _db.PointsStatistics.Add(pointsStatistic);

            await _db.SaveChangesAsync();
            return pointsStatistic;
        }

        public async Task<IEnumerable<PointsStatistic>> GetByAccountId(Guid id)
        {
            var statistics = await _db.PointsStatistics.Where(x => x.AccountId == id).ToListAsync();
            return statistics;
        }
    }
}
