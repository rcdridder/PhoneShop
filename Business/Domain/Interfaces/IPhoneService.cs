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

    }
}
