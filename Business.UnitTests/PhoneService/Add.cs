using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using MockQueryable.Moq;
using Moq;

namespace Business.UnitTests.Phones
{
    public class Add
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService = new Mock<IBrandService>();
        PhoneService phoneService;

        public Add()
        {
            phoneService = new(phoneRepository.Object, brandService.Object);
        }

        [Fact]
        public void AddPhoneToEmpyDatabase()
        {
            //Arrange
            List<Phone> phones = new();
            IQueryable<Phone> dbPhones = phones.AsQueryable();
            phoneRepository.Setup(p => p.GetAll()).Returns(dbPhones);
            Phone newPhone = new()
            {
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
            phoneService.Add(newPhone);
            //Assert
            phoneRepository.Verify(p => p.Add(newPhone), Times.Once());
        }

        [Fact]
        public void AddNewPhoneToExistingDatabase()
        {
            //Arrange
            List<Phone> phones = new()
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
                }
            };
            IQueryable<Phone> dbPhones = phones.AsQueryable();
            phoneRepository.Setup(p => p.GetAll()).Returns(dbPhones);
            Phone newPhone = new()
            {
                Brand = new()
                {
                    BrandId = 2,
                    BrandName = "Huawei"
                },
                BrandId = 2,
                Model = "P30",
                PriceVat = 697,
                Stock = 5,
                Description = "Simple test phone"
            };
            //Act
            phoneService.Add(newPhone);
            //Assert
            phoneRepository.Verify(p => p.Add(newPhone), Times.Once());
        }

        [Fact]
        public void DontAddExistingPhoneToDatabase()
        {
            //Arrange
            List<Phone> phones = new()
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
                }
            };
            IQueryable<Phone> dbPhones = phones.AsQueryable();
            phoneRepository.Setup(p => p.GetAll()).Returns(dbPhones);
            Phone newPhone = new()
            {
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
            phoneService.Add(newPhone);
            //Assert
            phoneRepository.Verify(p => p.Add(newPhone), Times.Never());
        }
    }
}
