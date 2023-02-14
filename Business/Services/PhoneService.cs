using Business.Domain.Interfaces;
using Business.Domain.Models;

namespace Business.Services
{
    public class PhoneService : IPhoneService
    {
        private IBrandRepository brandRepository;
        private IPhoneRepository phoneRepository;

        public PhoneService(IBrandRepository brandRepository, IPhoneRepository phoneRepository)
        {
            this.brandRepository = brandRepository;
            this.phoneRepository = phoneRepository;
        }
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

        private static decimal CalculatePriceNoVat(decimal priceVat) => priceVat / Convert.ToDecimal(1.21);

    }
}
