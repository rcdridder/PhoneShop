using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Phones
{

    public class Update
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService = new Mock<IBrandService>();
        PhoneService phoneService;

        public Update()
        {
            phoneService = new(phoneRepository.Object, brandService.Object);
        }

        [Fact]
        public void UpdatesPhoneInDatabase()
        {
            //Arrange
            Phone phone = new()
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
                Description = "Simple test phone"
            };
            //Act
            phoneService.Update(phone);
            //Assert
            phoneRepository.Verify(p => p.Update(phone), Times.Once);
        }
    }
}
