using System.ComponentModel.DataAnnotations.Schema;

namespace MyWalletAPI.Models
{
    public class PointsStatistic
    {
        public int Id { get; set; }
        [ForeignKey("AccountId")]
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }   
        public double TotalNumber { get; set; }
        public double ChangeAmount { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
