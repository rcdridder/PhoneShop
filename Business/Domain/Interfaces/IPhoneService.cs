using Business.Domain.Models;

namespace Business.Domain.Interfaces
{
    public interface IPhoneService
    {
        /// <summary>
        /// Adds a single phone to database.
        /// </summary>
        /// <param name="phone"></param>
        void Add(Phone phone);
        /// <summary>
        /// Deletes single phone from database.
        /// </summary>
        /// <param name="phone"></param>
        void Delete(Phone phone);
        /// <summary>
        /// Returns all phones from list.
        /// </summary>
        /// <returns></returns>
        List<Phone> GetAll();
        /// <summary>
        /// Returns single phone from list based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Phone GetById(int id);
        /// <summary>
        /// Returns all phones from list sorted by brand and type.
        /// </summary>
        /// <returns></returns>
        List<Phone> Sort();
        /// <summary>
        /// Returns a list of all phones that have the search query in brand, type and/or description.
        /// </summary>
        /// <returns></returns>
        List<Phone> Search(string query);
        /// <summary>
        /// Updates phone in database.
        /// </summary>
        /// <param name="phone"></param>
        void Update(Phone phone);
    }
}
