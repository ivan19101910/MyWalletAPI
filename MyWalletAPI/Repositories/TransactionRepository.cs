using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWalletAPI.DbContexts;
using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyWalletApiDbContext _db;
        private IMapper _mapper;

        public TransactionRepository(MyWalletApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<TransactionDto> Create(TransactionDto dto)
        {
            var transaction = _mapper.Map<TransactionDto, Transaction>(dto);

            _db.Transactions.Add(transaction);

            await _db.SaveChangesAsync();
            return _mapper.Map<Transaction, TransactionDto>(transaction);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var transaction = await _db.Transactions.FirstOrDefaultAsync(u => u.Id == id);
                if (transaction == null)
                {
                    return false;
                }
                _db.Transactions.Remove(transaction);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TransactionDto> Edit(TransactionDto dto)
        {
            var transaction = _mapper.Map<TransactionDto, Transaction>(dto);
            _db.Transactions.Update(transaction);

            await _db.SaveChangesAsync();
            return _mapper.Map<Transaction, TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> Get10Latest()
        {
            var transactionsList = await _db.Transactions.Skip(Math.Max(0, _db.Transactions.Count() - 10)).ToListAsync();
            return _mapper.Map<List<TransactionDto>>(transactionsList);
        }

        public async Task<TransactionDto> GetById(int id)
        {
            var transaction = await _db.Transactions.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
