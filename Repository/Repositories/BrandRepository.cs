using Business;
using Business.Domain.Interfaces;
using Business.Domain.Models;

namespace Repository.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly PhoneShopDataContext dataContext;

        public BrandRepository(PhoneShopDataContext dataContext) => this.dataContext = dataContext;

        public void Add(Brand entity)
        {
            dataContext.Add(entity);
            dataContext.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            dataContext.Remove(entity);
            dataContext.SaveChanges();
        }

        public IQueryable<Brand> GetAll() => dataContext.Set<Brand>().AsQueryable();

        public Brand GetById(int id) => dataContext.Set<Brand>().Find(id);

        public void Update(Brand entity)
        {
            dataContext.Update(entity);
            dataContext.SaveChanges();
        }
    }
}
