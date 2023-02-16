using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class GetBrandId
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public GetBrandId() => brandService = new(brandRepository.Object);

        [Fact]
        public void ValidBrandNameReturnsId()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName ="Apple"
                },
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            //Act
            int brandId = brandService.GetBrandId("Apple");
            //Assert
            Assert.Equal(1, brandId);
        }

        [Fact]
        public void InvalidBrandNameThrowsException()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName ="Apple"
                },
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            //Act & Assert
            Assert.Throws<NullReferenceException>(() => brandService.GetBrandId("Huawei"));
        }
    }
}
