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
        Task<User> AddUserAsync(User user);
        Task<User> DeleteUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserAsync(User user);
        //Dog
        Task<Dog> AddDogAsync(Dog dog);
        Task<Dog> DeleteDogAsync(Dog dog);
        Task<Dog> UpdateDogAsync(Dog dog);
        Task<Dog> GetDogByIdAsync(int id);
        Task<List<Dog>> GetAllDogsAsync();
        Task<Dog> GetDogAsync(Dog dog);
        //Likes
        Task<Like> AddLikesAsync(Like like);
        Task<Like> UpdateLikeAsync(Like like);
        Task<Like> GetLikeByIdAsync(int id);
        Task<Like> GetLikeAsync(Like like);
        //Tags
        Task<Tags> GetTagsAsync(int id);
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
        Task<Preference> GetPreferenceByIdAsync(int id);
        Task<List<Preference>> GetAllPreferencesAsync();
        Task<Preference> GetPreferenceAsync(Preference preference);
    }
}
