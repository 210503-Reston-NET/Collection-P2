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
        public async Task<List<Dog>> GetAllDogsForList(int ListID)
        {

            return await _repo.GetAllDogsForList(ListID);
        }

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

        public async Task<List<DogList>> GetAllDogLists()
        {
            return await _repo.GetAllDogListsAsync();
        }
        public async Task<List<DogList>> GetDogListsFor(string UserName)
        {
            return await _repo.GetDogListForAsync(UserName);
        }

        public async Task<DogList> GetDogListByID(int ListID)
        {
            return await _repo.GetDogListByIdAsync(ListID);
        }

        public async Task<DogList> AddNewDogList(DogList list)
        {
            if (await _repo.GetDogListAsync(list) != null)
            {
                throw new Exception("Restaurant already exists :<");
            }
            return await _repo.AddDogListasync(list) ;
        }
        public async Task<DogList> RemoveDogList(int dogID)
        {
            DogList toBeDeleted = await _repo.GetDogListByIdAsync(dogID);
            if (toBeDeleted != null) return await _repo.DeleteDogListAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public async Task<DogList> UpdateDogList(DogList list)
        {
            return await _repo.UpdateDogListAsync(list);
        }

  
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
