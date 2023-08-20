using Microsoft.EntityFrameworkCore;
using MyWalletAPI.Models;

namespace MyWalletAPI.DbContexts
{
    public class MyWalletApiDbContext : DbContext
    {
        public MyWalletApiDbContext(DbContextOptions<MyWalletApiDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<PointsStatistic> PointsStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Account);
            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.AuthorizedAccount);


            var guid = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = guid,
                Name = "Ivan"
            });
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = guid2,
                Name = "Roman"
            });
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = Guid.NewGuid(),
                Name = "Dmytro"
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 1,
                AccountId = guid,
                TransactionType = TransactionType.Payment,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 2),
                IsPending = true,
                IconId = 1,
            }) ;
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 2,
                AccountId = guid,
                TransactionType = TransactionType.Payment,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 3),
                IsPending = false,
                IconId = 2
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 3,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 4),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 4,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 5),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 5,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 6),
                IsPending = false,
                AuthorizedAccountId = guid2,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 6,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 7),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 7,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 9),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 8,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 10),
                IsPending = false,
                AuthorizedAccountId = guid2,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 9,
                AccountId = guid,
                TransactionType = TransactionType.Payment,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 15),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 10,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 18),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 11,
                AccountId = guid,
                TransactionType = TransactionType.Credit,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 19),
                IsPending = false,
                IconId = 1
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 12,
                AccountId = guid,
                TransactionType = TransactionType.Payment,
                Amount = 500,
                Name = "Amazon",
                Description = "Time earth spent misery had the seemed for yet it",
                Date = new DateTime(2023, 8, 20),
                IsPending = false,
                IconId = 1
            });

            modelBuilder.Entity<Icon>().HasData(new Icon
            {
                Id = 1,
                Url= "https://ibb.co/Y06rfps"
            });
            modelBuilder.Entity<Icon>().HasData(new Icon
            {
                Id = 2,
                Url = "https://ibb.co/dB3ty5W"
            });

            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 1,
                AccountId = guid2,
                TotalNumber = 10,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 2),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 2,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 10,
                CreatedDateTime = new DateTime(2023, 8, 3),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 3,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 5,
                CreatedDateTime = new DateTime(2023, 8, 4),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 4,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 5),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 5,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 6),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 6,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 7),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 7,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 8),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 8,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 9),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 9,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 10),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 10,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 11),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 11,
                AccountId = guid,
                TotalNumber = 500,
                ChangeAmount = 0,
                CreatedDateTime = new DateTime(2023, 8, 12),
            });
            modelBuilder.Entity<PointsStatistic>().HasData(new PointsStatistic
            {
                Id = 12,
                AccountId = guid,
                TotalNumber = 505,
                ChangeAmount = 5,
                CreatedDateTime = new DateTime(2023, 8, 13),
            });
        }
    }
}
