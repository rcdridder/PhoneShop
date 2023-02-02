using Business.Domain.Models;
using Business.Services;

namespace Business.UnitTests
{
    public class GetAll
    {
        PhoneService phoneService = new();

        private List<Phone> phoneList = new List<Phone>()
            { new Phone {Id = 1,
                Brand = "Huawei",
                Type = "P30",
                PriceNoVat = 576.03M,
                PriceVat = 697,
                Stock = 5,
                Description = @"6.47"" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1" },
            new Phone {Id = 2,
                Brand = "Samsung",
                Type = "Galaxy A52",
                PriceNoVat = 329.75M,
                PriceVat = 399,
                Stock = 5,
                Description = @"64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig (IP67)" },
            new Phone {Id = 3,
                Brand = "Apple",
                Type = "iPhone 11",
                PriceNoVat = 511.57M,
                PriceVat = 619,
                Stock = 5,
                Description = @"Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13-chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor" },
            new Phone {Id = 4,
                Brand = "Google",
                Type = "Pixel 4a",
                PriceNoVat = 339.67M,
                PriceVat = 411,
                Stock = 5,
                Description = @"12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm, 128 GB opslaggeheugen 3140 mAh accucapaciteit" },
            new Phone {Id = 5,
                Brand = "Xiaomi",
                Type = "Redmi Note 10 Pro",
                PriceNoVat = 238.84M,
                PriceVat = 298,
                Stock = 5,
                Description = @"108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm, 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd). Water- en stofbestendig (IP53)" }
            };
        [Fact]
        public void GetAllReturnsAllPhones()
        {
            //Assert, Act
            List<Phone> phones = phoneService.GetAll();
            //Assert
            Assert.Equal(5, phones.Count);
        }

    }
}