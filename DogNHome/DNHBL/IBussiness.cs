using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNHModels;

namespace DNHBL
{
    public interface IBussiness
    {
        /// <summary>
        /// Returns all dogs in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Dog>> GetAllDogs();
        /// <summary>
        /// Returns a complete list of all Dogs for a given listID
        /// </summary>
        /// <returns></returns>
        //Task<List<Dog>> GetAllDogsForList(int ListID);
        /// <summary>
        /// Returns the Dog object for a referenced dog and its API Key
        /// </summary>
        /// <param name="dogID"> an incremental Primary Key for local object Dog</param>
        /// <returns></returns>
        Task<Dog> GetDogByID(int dogID);
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
        /// <summary>
        /// Updates Dog Object with given dog Reference
        /// </summary>
        /// <param name="dog"></param>
        /// <returns></returns>
        Task<Dog> UpdateDog(Dog dog);
        /// <summary>
        /// Returns a complete list of Dog Lists from Database. primarily for Development
        /// </summary>
        /// <returns></returns>
        //Task<List<DogList>> GetAllDogLists();
        /// <summary>
        /// Returns all DogList Objects from Database for given User
        /// </summary>
        /// <param name="UserName">Unique Username</param>
        /// <returns></returns>
        //Task<List<DogList>> GetDogListsFor(string UserName);
        /// <summary>
        /// Returns a single DogList Object for the given ListID
        /// </summary>
        /// <param name="ListID">Primary Key for the expected DogList</param>
        /// <returns></returns>
        //Task<DogList> GetDogListByID(int ListID);
        /// <summary>
        /// Adds a new List to the Database for a related User
        /// </summary>
        /// <param name="list">List Object to be added</param>
        /// <returns></returns>
        //Task<DogList> AddNewDogList(DogList list);
        /// <summary>
        /// Removes given DogList Object from the Database
        /// </summary>
        /// <param name="dogID">Primary Key for the expected Dog</param>
        /// <returns></returns>
        //Task<DogList> RemoveDogList(int dogID);
        /// <summary>
        /// Updates the given DogList Object in the Database
        /// </summary>
        /// <param name="list">new DogList Object to be updated</param>
        /// <returns></returns>
        //Task<DogList> UpdateDogList(DogList list);
        /// <summary>
        /// Returns a list of all Users subscribed to web app
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsers();
        /// <summary>
        /// Returns a UserObject with the given UserName
        /// </summary>
        /// <param name="Username">Primary Key for the expected User</param>
        /// <returns></returns>
        Task<User> GetUser(string Username);
        /// <summary>
        /// Removes a User from the Database with the given UserName 
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<User> RemoveUser(string Username);
        /// <summary>
        /// Updates the given User Object in the Database
        /// </summary>
        /// <param name="user">User Object to be updated</param>
        /// <returns></returns>
        Task<User> UpdateUser(User user);


    }
}
