using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWalletAPI.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<PointsStatistic> PointsStatistics { get; set; }
    }
}
