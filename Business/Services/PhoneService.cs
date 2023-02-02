using Business.Domain.Interfaces;
using Business.Domain.Models;

namespace Business.Services
{
    public class PhoneService : IPhoneService
    {
        private List<Phone> phoneList = new List<Phone>()
        { new Phone {Id = 1,
            Brand = "Huawei",
            Type = "P30",
            PriceNoVat = CalculatePriceNoVat(697),
            PriceVat = 697,
            Stock = 5,
            Description = @"6.47"" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1" },
          new Phone {Id = 2,
            Brand = "Samsung",
            Type = "Galaxy A52",
            PriceNoVat = CalculatePriceNoVat(399),
            PriceVat = 399,
            Stock = 5,
            Description = @"64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig (IP67)" },
          new Phone {Id = 3,
            Brand = "Apple",
            Type = "iPhone 11",
            PriceNoVat = CalculatePriceNoVat(619),
            PriceVat = 619,
            Stock = 5,
            Description = @"Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13-chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor" },
          new Phone {Id = 4,
            Brand = "Google",
            Type = "Pixel 4a",
            PriceNoVat = CalculatePriceNoVat(411),
            PriceVat = 411,
            Stock = 5,
            Description = @"12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm, 128 GB opslaggeheugen 3140 mAh accucapaciteit" },
          new Phone {Id = 5,
            Brand = "Xiaomi",
            Type = "Redmi Note 10 Pro",
            PriceNoVat = CalculatePriceNoVat(298),
            PriceVat = 298,
            Stock = 5,
            Description = @"108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm, 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd). Water- en stofbestendig (IP53)" }
        };

        public List<Phone> GetAll() => phoneList;

        public Phone GetById(int id) => phoneList.Find(phone => phone.Id == id);

        private static decimal CalculatePriceNoVat(decimal priceVat) => priceVat / Convert.ToDecimal(1.21);

    }
}
