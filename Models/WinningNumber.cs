using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LuckyD.Models
{
    public class WinningNumber
    {
        [Required]
        public int Id { get; set; }
        public string User { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Please Add Only Four Digits Number")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsNumberExist", "Winning", AdditionalFields = "Id",
                ErrorMessage = "This Luck Number already Pick!! Please Choose Another Good Luck")]
        public string Number { get; set; }
        public int Quantity { get; set; }
        public int AllQuentity { get; set; }

        public bool IsWinner { get; set; }
        public Price Price { get; set; }

        [Required]
        public int PriceId { get; set; }

    }
}