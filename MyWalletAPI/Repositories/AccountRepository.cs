using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWalletAPI.DbContexts;
using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyWalletAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyWalletApiDbContext _db;
        private IMapper _mapper;

        public AccountRepository(MyWalletApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FullAccountInfoDto> GetById(Guid id)
        {
            var account = await _db.Accounts
                .Where(x => x.Id == id)
                .Include(x => x.Transactions)
                .ThenInclude(x => x.AuthorizedAccount)
                .Include(x => x.PointsStatistics)
                .FirstOrDefaultAsync();

            var mappedDto = _mapper.Map<FullAccountInfoDto>(account);
            var latestTransactions = account.Transactions.Skip(Math.Max(0, _db.Transactions.Count() - 10)).ToList();
            
            mappedDto.LatestTransactions = _mapper.Map<List<TransactionDto>>(latestTransactions);
            var rnd = new Random();
            mappedDto.CardBalance = rnd.Next(1500);
            mappedDto.AvailableFunds = 1500 - mappedDto.CardBalance;
            var points = account.PointsStatistics.Last().ChangeAmount;
            mappedDto.DailyPoints = points > 1000 ? $"{points/1000}K" : points.ToString();

            mappedDto.PaymentDue = DateTime.Now.ToString("MMMM");
            return mappedDto;
        }
    }
}
