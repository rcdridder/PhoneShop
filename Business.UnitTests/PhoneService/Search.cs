using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UnitTests
{
    public class Search
    {
        Mock<IPhoneRepository> phoneRepository = new Mock<IPhoneRepository>();
        Mock<IBrandService> brandService= new Mock<IBrandService>();
        PhoneService phoneService;

        public Search() => phoneService = new(phoneRepository.Object, brandService.Object);

        [Fact]
        public void QueryReturnsSinglePhone()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("Apple");
            //Assert
            Assert.Single(searchResults);
        }

        [Fact]
        public void QueryReturnsMultiplePhones()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("Google");
            //Assert
            Assert.Equal(2, searchResults.Count);
        }

        [Fact]
        public void InvalidQueryReturnsNoPhones()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("qqq");
            //Assert
            Assert.Empty(searchResults);
        }

        [Fact]
        public void EmptyQueryReturnsAllPhones()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("");
            //Assert
            Assert.Equal(3, searchResults.Count);
        }

        [Theory]
        [InlineData("ApplE")]
        [InlineData("apple")]
        [InlineData("APPLE")]
        public void QueryReturnsPhoneRegardlessOfCase(string query)
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search(query);
            //Assert
            Assert.Single(searchResults);
        }

        [Fact]
        public void FindsPhoneOnModel()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                    Description = "A simple test phone."
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("iph");
            //Assert
            Assert.Single(searchResults);
        }

        [Fact]
        public void FindsPhoneOnDescription()
        {
            //Arrange
            List<Phone> dbPhones = new()
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
                    Description = "Find this simple test phone."
                },
                new Phone
                {
                    PhoneId = 2,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 4a",
                    PriceVat = 411,
                    Stock = 5,
                    Description = "Another simple test phone."
                },
                new Phone
                {
                    PhoneId = 3,
                    Brand = new()
                    {
                        BrandId = 2,
                        BrandName = "Google"
                    },
                    BrandId = 2,
                    Model = "Pixel 7 Pro",
                    PriceVat = 899,
                    Description = "Yet another simple test phone."
                }
            };
            IQueryable<Phone> mockList = dbPhones.AsQueryable();
            phoneRepository.Setup(x => x.GetAll()).Returns(mockList);
            //Act
            List<Phone> searchResults = phoneService.Search("find");
            //Assert
            Assert.Single(searchResults);
        }
    }
}
