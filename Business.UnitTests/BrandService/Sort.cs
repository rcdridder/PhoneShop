using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class Sort
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public Sort() => brandService = new(brandRepository.Object);

        [Fact]
        public void RetursAllBrandsSortedByBrandName()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Huawei",
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Apple"
                }
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            //Act
            List<Brand> sortedBrands = brandService.Sort();
            //Assert
            Assert.Equal("Huawei", sortedBrands[1].BrandName);
            Assert.Equal(2, sortedBrands.Count());
        }
    }
}
