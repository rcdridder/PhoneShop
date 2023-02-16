using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class Add
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public Add() => brandService = new(brandRepository.Object);

        [Fact]
        public void AddBrandToEmptyDatabase()
        {
            //Arrange
            List<Brand> brands = new();
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            Brand newBrand = new()
            {
                BrandId = 1,
                BrandName = "Apple",
            };
            //Act
            brandService.Add(newBrand);
            //Assert
            brandRepository.Verify(b => b.Add(newBrand), Times.Once());
        }

        [Fact]
        public void AddNewBrandToExistingDatabase()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple"
                }
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            Brand newBrand = new()
            {
                BrandId = 2,
                BrandName = "Huawei",
            };
            //Act
            brandService.Add(newBrand);
            //Assert
            brandRepository.Verify(b => b.Add(newBrand), Times.Once());
        }

        [Fact]
        public void DontAddExistingBrandToDatabase()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple"
                }
            };
            IQueryable<Brand> dbBrands = brands.AsQueryable();
            brandRepository.Setup(b => b.GetAll()).Returns(dbBrands);
            Brand newBrand = new()
            {
                BrandId = 1,
                BrandName = "Apple",
            };
            //Act
            brandService.Add(newBrand);
            //Assert
            brandRepository.Verify(b => b.Add(newBrand), Times.Never());
        }
    }
}
