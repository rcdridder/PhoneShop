using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests
{
    public class GetById
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService= new Mock<IBrandService>();
        PhoneService phoneService;

        public GetById()
        {
           phoneService = new(phoneRepository.Object, brandService.Object);
        }

        [Fact]
        public void ValidNumberRetursValidPhone()
        {
            //Arrange
            Phone dbPhone = new()
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
            phoneRepository.Setup(x => x.GetById(1)).Returns(dbPhone);        
            //Act
            Phone phone = phoneService.GetById(1);
            //Assert
            Assert.Equal("iPhone 11", phone.Model);
        }
        [Fact]
        public void InvalidNumberThrowsException()
        {
            //Arrange
            Phone dbPhone = new()
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
            phoneRepository.Setup(x => x.GetById(1)).Returns(dbPhone);
            //Act
            Phone phone = phoneService.GetById(10);
            //Assert
            Assert.Null(phone);

        }
    }
}
