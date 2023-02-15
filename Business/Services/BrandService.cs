using Business.Domain.Interfaces;
using Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository) => this.brandRepository = brandRepository;

        public void Add(Brand brand)
        {
            bool brandInDatabase = brandRepository.GetAll().Any(b => b.BrandName == brand.BrandName);
            if(!brandInDatabase)
                brandRepository.Add(brand);
        }

        public void Delete(Brand brand) => brandRepository.Delete(brand);

        public List<Brand> GetAll() => brandRepository.GetAll().ToList();

        public int GetBrandId(string brandName)
        {
            IQueryable<Brand> brands = brandRepository.GetAll().Where(brand => brand.BrandName == brandName);
            return brands.FirstOrDefault().BrandId;
        }

        public Brand GetById(int id) => brandRepository.GetById(id);

        public List<Brand> Search(string query)
        {
            query= query.ToLower();
            return brandRepository.GetAll().Where(brand => brand.BrandName.ToLower().Contains(query)).ToList();
        }

        public List<Brand> Sort() => brandRepository.GetAll().OrderBy(brand => brand.BrandName).ToList();

    }
}
