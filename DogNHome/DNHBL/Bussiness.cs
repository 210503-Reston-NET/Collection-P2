using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNHDL;
using DNHModels;

namespace DNHBL
{
    public class Bussiness : IBussiness
    {
        private IRepository _repo;

        public Bussiness(IRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<Dog>> GetAllDogs()
        {
            return await _repo.GetAllDogsAsync();
        }
       /* public async Task<List<Dog>> GetAllDogsForList(int ListID)
        {
            return _repo.GetAllDogsForList(ListId);
        }*/
        public async Task<Dog> GetDogByID(int dogID)
        {
            return await _repo.GetDogByIdAsync(dogID);
        }

        public async Task<Dog> AddDog(Dog dog)
        {
            if (await _repo.GetDogAsync(dog) != null)
            {
                throw new Exception("Restaurant already exists :<");
            }
            return await _repo.AddDogAsync(dog);
        }

        public async Task<Dog> RemoveDog(Dog dog)
        {
            Dog toBeDeleted = await _repo.GetDogAsync(dog);
            if (toBeDeleted != null) return await _repo.DeleteDogAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public async Task<Dog> RemoveDogByID(int dogID)
        {
            Dog toBeDeleted = await _repo.GetDogByIdAsync(dogID);
            if (toBeDeleted != null) return await _repo.DeleteDogAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public async Task<Dog> UpdateDog(Dog dog)
        {
            return await _repo.UpdateDogAsync(dog);
        }

        /*List<Task<DogList>> GetAllDogLists()
        {

        }
        List<Task<DogList>> GetDogListsFor(string UserName)
        {

        }

        Task<DogList> GetDogListByID(int ListID)
        {        
           
        }

        Task<DogList> AddNewDogList(DogList list)
        {

        }
        Task<DogList> RemoveDogList(int dogID)
        {

        }
  
        Task<DogList> UpdateDogList(DogList list)
        {

        }*/
  
        public async Task<List<User>> GetAllUsers()
        {
            return await _repo.GetAllUsersAsync();
        }
   
        public async Task<User> GetUser(string Username)
        {
            return await _repo.GetUserByIdAsync(Username);
        }
 
        public async Task<User> RemoveUser(string Username)
        {
            User toBeDeleted = await _repo.GetUserByIdAsync(Username);
            if (toBeDeleted != null) return await _repo.DeleteUserAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }
        
        public async Task<User> UpdateUser(User user)
        {
            return await _repo.UpdateUserAsync(user);
        }
    }
}
