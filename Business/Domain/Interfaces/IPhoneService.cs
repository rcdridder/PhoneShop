using Business.Domain.Models;

namespace Business.Domain.Interfaces
{
    public interface IPhoneService
    {
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
    }
}
