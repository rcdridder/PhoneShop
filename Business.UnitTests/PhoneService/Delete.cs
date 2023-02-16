using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Phones
{
    public class Delete
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService = new Mock<IBrandService>();
        PhoneService phoneService;

        public Delete()
        {
            phoneService = new(phoneRepository.Object, brandService.Object);
        }
        [Fact]
        public void DeletesPhoneFromDatabase()
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
            phoneService.Delete(phone);
            //Assert
            phoneRepository.Verify(p => p.Delete(phone), Times.Once);
        }
    }
}
