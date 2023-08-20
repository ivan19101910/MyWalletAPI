using System.ComponentModel.DataAnnotations;

namespace MyWalletAPI.Models
{
    public class Icon
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
