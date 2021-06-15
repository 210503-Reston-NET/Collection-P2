using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNHModels;

namespace DNHDL
{
    public interface IRepository
    {
        //User
        Task<User> AddUserAsync(string uid);
        Task<User> DeleteUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(User user);
        //Dog
        //Likes
        Task<Like> AddLikesAsync(Like like);
        Task<Like> DeleteLikeAsync(Like like);
        Task<Like> UpdateLikeAsync(Like like);
        Task<Like> GetLikeByIdAsync(int id);
        Task<List<Like>> GetAllLikesAsync();
        Task<Like> GetLikeAsync(Like like);
        //Tags
        Task<Tags> AddTagsAsync(Tags tags);
        Task<Tags> DeleteTagsAsync(Tags tags);
        Task<Tags> UpdateTagsAsync(Tags tags);
        Task<List<Tags>> GetAllTagsAsync();
        Task<Tags> GetTagsByIdAsync(int id);
        Task<Tags> GetTagsAsync(Tags tags);
        //Forums
        Task<Forum> AddForumAsync(Forum forum);
        Task<Forum> DeleteForumAsync(Forum forum);
        Task<Forum> UpdateForumAsync(Forum forum);
        Task<Forum> GetForumByIdAsync(int id);
        Task<List<Forum>> GetAllForumsAsync();
        Task<Forum> GetForumAsync(Forum forum);
        //Posts
        Task<Posts> AddPostsAsync(Posts posts);
        Task<Posts> DeletePostsAsync(Posts posts);
        Task<Posts> UpdatePostsAsync(Posts posts);
        Task<Posts> GetPostsByIdAsync(int id);
        Task<List<Posts>> GetPostForForumWithID(int id);
        Task<List<Posts>> GetAllPostsAsync();
        Task<Posts> GetPostsAsync(Posts posts);
        //Comments
        Task<Comments> AddCommentsAsync(Comments comments);
        Task<Comments> DeleteCommentsAsync(Comments comments);
        Task<Comments> UpdateCommentsAsync(Comments comments);
        Task<Comments> GetCommentsByIdAsync(int id);
        Task<List<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentsAsync(Comments comments);
        //Preference
        Task<Preference> AddPreferenceAsync(Preference preference);
        Task<Preference> DeletePreferenceAsync(Preference preference);
        Task<Preference> UpdatePreferenceAsync(Preference preference);
        Task<List<Preference>> GetPreferenceByIdAsync(int id);
        Task<List<Preference>> GetPreferenceForAsync(string userName);
        Task<List<Preference>> GetAllPreferencesAsync();
        Task<Preference> GetPreferenceAsync(Preference preference);
        //DogList
        Task<DogList> AddDogListasync(DogList dogList);

        Task<DogList> DeleteDogListAsync(DogList dogList);
        Task<DogList> UpdateDogListAsync(DogList dogList);
        Task<DogList> GetDogListByIdAsync(int id);
        Task<List<DogList>> GetAllDogListsAsync();
        Task<DogList> GetDogListAsync(DogList dogList);
        Task<List<DogList>> GetDogListForAsync(string Username);
        //ListedDog
        Task<ListedDog> AddListedDogasync(ListedDog listDog);
        Task<ListedDog> DeleteListedDogAsync(ListedDog listedDog);
        Task<ListedDog> UpdateListedDogAsync(ListedDog listedDog);
        Task<List<ListedDog>> GetListedDogByDogIdAsync(string id);
        Task<List<ListedDog>> GetListedDogByListIdAsync(int id);
        Task<List<ListedDog>> GetAllListedDogsAsync();  
        Task<ListedDog> GetListedDogAsync(ListedDog listedDog);

        // Alerts
        Task<List<Alert>> GetAllAlertsAsync();
        Task<List<Alert>> GetAlertsForUserAsync(string userId);
        Task<Alert> AddAlertAsync(Alert alert);
        Task<Alert> UpdateAlertAsync(Alert alert);
        Task<Alert> RemoveAlertAsync(Alert alert);


    }
}
