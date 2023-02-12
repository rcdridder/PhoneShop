namespace Business.Domain.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string FullName { get => $"{Brand} {Type}"; }
        public decimal PriceNoVat { get; set; }
        public decimal PriceVat { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

    }
}
