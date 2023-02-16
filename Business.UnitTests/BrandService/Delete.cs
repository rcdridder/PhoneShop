using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class Delete
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public Delete() => brandService = new(brandRepository.Object);

        [Fact]
        public void DeletesBrandFromDatabase()
        {
            //Arrange
            Brand brand = new()
            {
                BrandId = 2,
                BrandName = "Huawei",
            };
            //Act
            brandService.Delete(brand);
            //Assert
            brandRepository.Verify(b => b.Delete(brand), Times.Once());
        }
    }
}
