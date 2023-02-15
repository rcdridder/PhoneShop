using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string FullName { get => $"{Brand.BrandName} {Model}"; }
        public decimal PriceNoVat { get; set; }
        public decimal PriceVat { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

    }
}
