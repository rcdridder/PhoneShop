using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Phones
{
    public class GetAll
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService = new Mock<IBrandService>();
        PhoneService phoneService;

        public GetAll() => phoneService = new(phoneRepository.Object, brandService.Object);


        [Fact]
        public void ReturnsAllPhones()
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
            List<Phone> phones = phoneService.GetAll();
            //Assert
            Assert.Equal(2, phones.Count);
        }
    }
}