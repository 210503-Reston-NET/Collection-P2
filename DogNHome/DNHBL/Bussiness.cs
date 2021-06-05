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


        public List<Task<Dog>> GetAllDogs()
        {


        }
        List<Task<Dog>> GetAllDogsForList(int ListID)
        {

        }
        Task<Dog> GetDogByID(int dogID)
        {

        }

        Task<Dog> AddDog(Dog dog)
        {

        }

        public async Task<Dog> RemoveDog(Dog dog)
        {
            Dog toBeDeleted = await _repo.GetDogAsync(dog);
            if (toBeDeleted != null) return await _repo.DeleteDogAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        Task<Dog> RemoveDogByID(int dogID)
        {


        }

        Task<Dog> UpdateDog(Dog dog)
        {


        }

        List<Task<DogList>> GetAllDogLists()
        {

        }
        List<Task<DogList>> GetDogListsFor(string UserName)
        {

        }

        Task<DogList> GetDogListByID(int ListID)
        {        
           
        }

Task<DogList> AddNewDogList(DogList list);
    
        Task<DogList> RemoveDogList(int dogID);
  
        Task<DogList> UpdateDogList(DogList list);
  
        List<Task<User>> GetAllUsers();
   
        Task<User> GetUser(string Username);
 
        Task<User> RemoveUser(string Username);
        
        Task<User> UpdateUser(User user);
    }
}
