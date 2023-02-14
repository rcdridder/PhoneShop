using Business;
using Business.Domain.Interfaces;
using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly PhoneShopDataContext dataContext;

        public PhoneRepository(PhoneShopDataContext dataContext) => this.dataContext = dataContext;

        public void Add(Phone entity)
        {
            dataContext.Add(entity);
            dataContext.SaveChanges();
        }

        public void Delete(Phone entity)
        {
            dataContext.Remove(entity);
            dataContext.SaveChanges();
        }

        public IQueryable<Phone> GetAll() => dataContext.Set<Phone>().Include(b => b.Brand).AsQueryable();

        public Phone GetById(int id) => dataContext.Set<Phone>().Include(b => b.Brand).FirstOrDefault(p => p.PhoneId == id);

        public void Update(Phone entity)
        {
            dataContext.Update(entity);
            dataContext.SaveChanges();
        }
    }
}
