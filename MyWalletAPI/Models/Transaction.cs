using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace MyWalletAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsPending { get; set; }
        public Guid? AuthorizedAccountId { get; set; }
        public virtual Account? AuthorizedAccount { get; set; }
        public int IconId { get; set; }
        [ForeignKey("IconId")]
        public virtual Icon? Icon { get; set; }
    }
}
