using Business.Domain.Models;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UnitTests
{
    public class Search
    {
        PhoneService phoneService = new();

        [Fact]
        public void QueryReturnsSinglePhone()
        {
            //Arrange + Act
            List<Phone> searchResults = phoneService.Search("Huawei");
            //Assert
            Assert.Single(searchResults);
        }

        [Fact]
        public void QueryReturnsMultiplePhones()
        {
            //Arrange + Act
            List<Phone> searchResults = phoneService.Search("came");
            //Assert
            Assert.Equal(4, searchResults.Count);
        }

        [Fact]
        public void InvalidQueryReturnsNoPhones()
        {
            //Arrange + Act
            List<Phone> searchResults = phoneService.Search("qqq");
            //Assert
            Assert.Empty(searchResults);
        }

        [Fact]
        public void EmptyQueryReturnsAllPhones()
        {
            //Arrange + Act
            List<Phone> searchResults = phoneService.Search("");
            //Assert
            Assert.Equal(5, searchResults.Count);
        }

        [Theory]
        [InlineData("HUAWEI")]
        [InlineData("huawei")]
        [InlineData("HuAwEi")]
        public void QueryReturnsPhoneRegardlessOfCase(string query)
        {
            //Arrange + Act
            List<Phone> searchResults = phoneService.Search("Huawei");
            //Assert
            Assert.Single(searchResults);
        }
    }
}
