using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Business
{
    public class PhoneShopDataContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PhoneShop"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, BrandName = "Apple" },
                new Brand { BrandId = 2, BrandName = "Google" },
                new Brand { BrandId = 3, BrandName = "Huawei" },
                new Brand { BrandId = 4, BrandName = "Samsung" },
                new Brand { BrandId = 5, BrandName = "Xiaomi" });
            modelBuilder.Entity<Phone>().HasData(
                new Phone { PhoneId = 1, BrandId = 1, Model = "iPhone 11", PriceVat = 619, Stock = 5, Description = @"Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13-chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor" },
                new Phone { PhoneId = 2, BrandId = 2, Model = "Pixel 4a", PriceVat = 411, Stock = 5, Description = @"12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm, 128 GB opslaggeheugen 3140 mAh accucapaciteit" },
                new Phone { PhoneId = 3, BrandId = 3, Model = "P30", PriceVat = 697, Stock = 5, Description = @"6.47"" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1" },
                new Phone { PhoneId = 4, BrandId = 4, Model = "Galaxy A52", PriceVat = 399, Stock = 5, Description = @"64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig (IP67)" },
                new Phone { PhoneId = 5, BrandId = 5, Model = "Redmi Note 10 Pro", PriceVat = 298, Stock = 5, Description = @"108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm, 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd). Water- en stofbestendig (IP53)" });
        }
    }
}
