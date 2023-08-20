using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;
using MyWalletAPI.Repositories;

namespace MyWalletAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPointsStatisticRepository _pointsStatisticRepository;
        protected ResponseDto _response;

        public AccountService(IAccountRepository accountRepository, IPointsStatisticRepository pointsStatisticRepository)
        {
            _accountRepository = accountRepository;
            _pointsStatisticRepository = pointsStatisticRepository;
            _response = new ResponseDto();
        }
        private async Task<ResponseDto> PerformRequest<TInput, TReturn>(Func<TInput, Task<TReturn>> Action, TInput parameter)
        {
            try
            {
                _response.Result = await Action(parameter);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        public Task<ResponseDto> GetById(Guid id) => PerformRequest(_accountRepository.GetById, id);

        public async Task<PointsStatistic> CalculateDailyPoints(Guid id)
        {
            var pointsStatistic = (await _pointsStatisticRepository.GetByAccountId(id)).ToList();

            var date = DateTime.Now;
            double pointsToAdd = 0;

            var record = new PointsStatistic()
            {
                AccountId = id,
                TotalNumber = 0,
                ChangeAmount = 0,
                CreatedDateTime = date
            };
            if (pointsStatistic.LastOrDefault()?.CreatedDateTime.Day < date.Day)//if true, the last day when we counted point was yesterday or earlier
            {
                if(date.Month % 3 == 0)
                {
                    switch (date.Day)
                    {
                        case 1:
                            pointsToAdd = 2;
                            break;
                        case 2:
                            pointsToAdd = 3;
                            break;

                    }                    
                }
                else
                {
                    if (pointsStatistic.Count > 0)
                    {
                        var dayBeforeYesterdayPoints = pointsStatistic.Where(x => x.CreatedDateTime.Day == date.Day - 2).FirstOrDefault();
                        var yesterdayPoints = pointsStatistic.Where(x => x.CreatedDateTime.Day == date.Day - 1).FirstOrDefault();

                        if (dayBeforeYesterdayPoints != null)
                            pointsToAdd += dayBeforeYesterdayPoints.ChangeAmount * 0.6;

                        if(yesterdayPoints != null)
                            pointsToAdd += yesterdayPoints.ChangeAmount;
                    }
                    
                }
                var totalAmount = 0d;
                var lastRecord = pointsStatistic.LastOrDefault();
                if (lastRecord != null)
                {
                    totalAmount = lastRecord.TotalNumber + pointsToAdd;
                }

                record.TotalNumber = totalAmount;
                record.ChangeAmount = pointsToAdd;

                await _pointsStatisticRepository.Create(record);
                return record;
            }

            record.TotalNumber = 0;
            record.ChangeAmount = 0;

            return record;
        }
    }
}
