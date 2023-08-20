using FluentAssertions;
using Moq;
using MyWalletAPI;
using MyWalletAPI.Models;
using MyWalletAPI.Repositories;
using MyWalletAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyWalletApi.UnitTests
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<IPointsStatisticRepository> _pointsStatisticRepository;
        private List<PointsStatistic> _statisticList;
        private Guid _userGuid;  
        //private readonly IMapper _mapper;
        public AccountServiceTests()
        {
            _statisticList = GetNewStatisticsRecords().ToList();
            _pointsStatisticRepository = new Mock<IPointsStatisticRepository>();
            _accountRepository = new Mock<IAccountRepository>();
            _accountService = new AccountService(_accountRepository.Object, _pointsStatisticRepository.Object);
            _userGuid = Guid.NewGuid();
            //_mapper = MappingConfig.RegisterMaps().CreateMapper();
        }

        [Fact]
        public async void CalculateDailyPoints_ShouldReturnNewPointsStatistic_WhenRecordsExist()
        {
            _pointsStatisticRepository.Setup(x => x.GetByAccountId(_userGuid)).ReturnsAsync(_statisticList);

            var response = await _accountService.CalculateDailyPoints(_userGuid);

            response.Should().NotBeNull();
            response.TotalNumber.Should().Be(511);
            response.ChangeAmount.Should().Be(11);
        }

        [Fact]
        public async void CalculateDailyPoints_ShouldReturnNewPointsStatistic_WhenRecordsDoNotExist()
        {
            _pointsStatisticRepository.Setup(x => x.GetByAccountId(_userGuid)).ReturnsAsync(new List<PointsStatistic>());

            var response = await _accountService.CalculateDailyPoints(_userGuid);

            response.Should().NotBeNull();
            response.AccountId.Should().Be(_userGuid);
            response.ChangeAmount.Should().Be(0);
            response.TotalNumber.Should().Be(0);
        }

        [Fact]
        public async void CalculateDailyPoints_ShouldReturnValidTotalNumber_WhenRecordsOlderThan2Days()
        {
            _pointsStatisticRepository.Setup(x => x.GetByAccountId(_userGuid)).ReturnsAsync(GetOldStatisticsRecords());

            var response = await _accountService.CalculateDailyPoints(_userGuid);

            response.Should().NotBeNull();
            response.ChangeAmount.Should().Be(0);
            response.TotalNumber.Should().Be(500);
        }

        private IEnumerable<PointsStatistic> GetNewStatisticsRecords()
        {
            var statistics = new List<PointsStatistic>
            {
                new PointsStatistic()
                {
                    Id = 1,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 0,
                    CreatedDateTime = new DateTime(2023, 8, 16),
                },
                new PointsStatistic()
                {
                    Id = 2,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 10,
                    CreatedDateTime = new DateTime(2023, 8, 17),
                },
                new PointsStatistic()
                {
                    Id = 3,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 5,
                    CreatedDateTime = new DateTime(2023, 8, 18),
                }
            };

            return statistics;
        }

        private IEnumerable<PointsStatistic> GetOldStatisticsRecords()
        {
            var statistics = new List<PointsStatistic>
            {
                new PointsStatistic()
                {
                    Id = 1,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 0,
                    CreatedDateTime = new DateTime(2023, 8, 10),
                },
                new PointsStatistic()
                {
                    Id = 2,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 10,
                    CreatedDateTime = new DateTime(2023, 8, 11),
                },
                new PointsStatistic()
                {
                    Id = 3,
                    AccountId = _userGuid,
                    TotalNumber = 500,
                    ChangeAmount = 5,
                    CreatedDateTime = new DateTime(2023, 8, 12),
                }
            };

            return statistics;
        }
    }
}
