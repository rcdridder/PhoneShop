using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class GetAll
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public GetAll() => brandService = new(brandRepository.Object);

        [Fact]
        public void ReturnsAllBrands()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName ="Apple"
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Huawei"
                }
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            //Act
            List<Brand> getAllBrands = brandService.GetAll();
            //Assert
            Assert.Equal(2, getAllBrands.Count);
        }
    }
}
