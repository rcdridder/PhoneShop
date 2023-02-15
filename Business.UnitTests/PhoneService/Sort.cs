using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests
{
    public class Sort
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService = new Mock<IBrandService>();
        PhoneService phoneService;

        public Sort() => phoneService = new(phoneRepository.Object, brandService.Object);

        [Fact]
        public void RetursAllPhonesSortedByBrand()
        {
            //Arrange
            List<Phone> dbPhones = new()
            {
                new Phone
                {
                    PhoneId = 1,
                    Brand = new()
                    {
                        BrandId = 1,
                        BrandName = "Apple"
                    },
                    BrandId = 1,
                    Model = "iPhone 11",
                    PriceVat = 619,
                    Stock = 5,
                    Description = "Simple test phone."
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> phonesSorted = phoneService.Sort();
            //Assert
            Assert.Equal("iPhone 11", phonesSorted[0].Model);
            Assert.Equal(2, phonesSorted.Count);
        }

        [Fact]
        public void SortsByBrandAndType()
        {
            //Arrange
            List<Phone> dbPhones = new()
            {
                new Phone
                {
                    PhoneId = 1,
                    Brand = new()
                    {
                        BrandId = 1,
                        BrandName = "Apple"
                    },
                    BrandId = 1,
                    Model = "iPhone 11",
                    PriceVat = 619,
                    Stock = 5,
                    Description = "Simple test phone."
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> phonesSorted = phoneService.Sort();
            //Assert
            Assert.Equal("Pixel 4a", phonesSorted[1].Model);
        }
    }
}
