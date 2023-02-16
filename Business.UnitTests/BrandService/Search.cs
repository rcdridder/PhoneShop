using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;

namespace Business.UnitTests.Brands
{
    public class Search
    {
        Mock<IBrandRepository> brandRepository = new Mock<IBrandRepository>();
        BrandService brandService;

        public Search() => brandService = new(brandRepository.Object);

        [Fact]
        public void QueryReturnsSingleBrand()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple",
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
            List<Brand> searchResults = brandService.Search("Apple");
            //Assert
            Assert.Single(searchResults);
        }

        [Fact]
        public void QueryReturnsMultipleBrands()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple",
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
            List<Brand> searchResults = brandService.Search("e");
            //Assert
            Assert.Equal(2, searchResults.Count);
        }

        [Fact]
        public void InvalidQueryReturnsNoBrands()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple",
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
            List<Brand> searchResults = brandService.Search("qqq");
            //Assert
            Assert.Empty(searchResults);
        }

        [Fact]
        public void EmptyQueryReturnsAllBrands()
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple",
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
            List<Brand> searchResults = brandService.Search("");
            //Assert
            Assert.Equal(2, searchResults.Count);
        }

        [Theory]
        [InlineData("ApplE")]
        [InlineData("apple")]
        [InlineData("APPLE")]
        public void QueryReturnsBrandRegardlessOfCase(string query)
        {
            //Arrange
            List<Brand> brands = new()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Apple",
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
            List<Brand> searchResults = brandService.Search(query);
            //Assert
            Assert.Single(searchResults);
        }
    }
}
