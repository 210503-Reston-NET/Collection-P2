using System;
using System.Threading.Tasks;
using DNHModels;

namespace DNHBL
{
    public interface IBussiness
    {
        /// <summary>
        /// Returns a complete list of all Dogs for a given listID
        /// </summary>
        /// <returns></returns>
        Task<Dog> getAllDogsForList(int ListID);
        /// <summary>
        /// Returns the Dog object for a referenced dog and its API Key
        /// </summary>
        /// <param name="dogID"> an incremental Primary Key for local object Dog</param>
        /// <returns></returns>
        Task<Dog> getDogByID(int dogID);
        /// <summary>
        /// Adds the given Dog obj to Database
        /// </summary>
        /// <param name="dog">Object holding API reference for select Dog</param>
        /// <returns></returns>
        Task<Dog> AddDog(Dog dog);
        /// <summary>
        /// Removes the given Dog obj from Database
        /// </summary>
        /// <param name="dog">Object holding API reference for select Dog</param>
        /// <returns></returns>
        Task<Dog> RemoveDog(Dog dog);
        /// <summary>
        /// Removes a Dog from Database with given dogID
        /// </summary>
        /// <param name="dogID">an incremental Primary Key for local object Dog</param>
        /// <returns></returns>
        Task<Dog> RemoveDogByID(int dogID);

    }
}
