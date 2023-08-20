namespace MyWalletAPI.Models.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string AuthorizedAccoutName { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public bool IsPending { get; set; }
    }
}
