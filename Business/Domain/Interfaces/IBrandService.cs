using Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain.Interfaces
{
    public interface IBrandService
    {
        /// <summary>
        /// Adds a single brand to database.
        /// </summary>
        /// <param name="brand"></param>
        void Add(Brand brand);
        /// <summary>
        /// Deletes single brand from database.
        /// </summary>
        /// <param name="phone"></param>
        void Delete(Brand brand);
        /// <summary>
        /// Returns all brands from list.
        /// </summary>
        /// <returns></returns>
        List<Brand> GetAll();
        /// <summary>
        /// Returns single brand from list based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Brand GetById(int id);
        /// <summary>
        /// Returns single brandId based on brand name.
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        int GetBrandId(string brandName);
        /// <summary>
        /// Returns all brands from list sorted by brand and type.
        /// </summary>
        /// <returns></returns>
        List<Brand> Sort();
        /// <summary>
        /// Returns a list of all brands that have the search query in brand name.
        /// </summary>
        /// <returns></returns>
        List<Brand> Search(string query);
    }
}
