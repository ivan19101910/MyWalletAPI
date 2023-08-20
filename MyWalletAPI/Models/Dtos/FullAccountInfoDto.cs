namespace MyWalletAPI.Models.Dtos
{
    public class FullAccountInfoDto
    {
        public string Name { get; set; }
        public int CardBalance { get; set; }//random
        public int AvailableFunds { get; set; }// 1500 - cardbalance
        public string PaymentDue { get; set; }
        public string DailyPoints { get; set; }
        public IEnumerable<TransactionDto> LatestTransactions { get; set; }
    }
}
