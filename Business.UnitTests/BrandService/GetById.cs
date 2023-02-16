using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class GetById
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public GetById() => brandService = new(brandRepository.Object);

        [Fact]
        public void ValidNumberReturnsValidPhone()
        {
            //Arrange
            Brand dbBrand = new()
            {
                BrandId = 1,
                BrandName = "Apple"
            };

            brandRepository.Setup(b => b.GetById(1)).Returns(dbBrand);
            //Act
            Brand brand = brandService.GetById(1);
            //Assert
            Assert.Equal("Apple", dbBrand.BrandName);
        }

        [Fact]
        public void InvalidNumberReturnsNull()
        {
            //Arrange
            Brand dbBrand = new()
            {
                BrandId = 1,
                BrandName = "Apple"
            };
            brandRepository.Setup(b => b.GetById(1)).Returns(dbBrand);
            //Act
            Brand brand = brandService.GetById(10);
            //Assert
            Assert.Null(brand);
        }
    }
}
