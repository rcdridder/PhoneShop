using Business.Domain.Interfaces;
using Business.Domain.Models;

namespace Business.Services
{
    public class PhoneService : IPhoneService
    {
        private IPhoneRepository phoneRepository;
        private IBrandService brandService;

        public PhoneService(IPhoneRepository phoneRepository, IBrandService brandService)
        {
            this.phoneRepository = phoneRepository;
            this.brandService = brandService;
        }

        public void Add(Phone phone)
        {
            bool phoneInDatabase = phoneRepository.GetAll().Any(p => p.Brand.BrandName.Equals(phone.Brand.BrandName) && p.Model.Equals(phone.Model)); 
            if (!phoneInDatabase)
            {
                brandService.Add(phone.Brand);
                phone.BrandId = brandService.GetBrandId(phone.Brand.BrandName);
                phone.Brand = null;
                phoneRepository.Add(phone);
            }   
        }

        public void Delete(Phone phone) => phoneRepository.Delete(phone);

        public List<Phone> GetAll() => phoneRepository.GetAll().ToList();

        public Phone GetById(int id) => phoneRepository.GetById(id);

        public List<Phone> Search(string query)
        {
            query = query.ToLower();
            return phoneRepository.GetAll().Where(phone => phone.Brand.BrandName.ToLower().Contains(query) || 
                phone.Model.ToLower().Contains(query) || 
                phone.Description.ToLower().Contains(query)).ToList();
        }

        public List<Phone> Sort() => phoneRepository.GetAll().OrderBy(phone => phone.Brand.BrandName).ThenBy(phone => phone.Model).ToList(); 

        public void Update(Phone phone) => phoneRepository.Update(phone);

        private static decimal CalculatePriceNoVat(decimal priceVat) => priceVat / Convert.ToDecimal(1.21);

    }
}
