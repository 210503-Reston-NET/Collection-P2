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
            return await _repo.AddDogListasync(list);
        }
        public async Task<DogList> RemoveDogList(int dogID)
        {
            DogList toBeDeleted = await _repo.GetDogListByIdAsync(dogID);
            if (toBeDeleted != null) return await _repo.DeleteDogListAsync(toBeDeleted);
            else throw new Exception("DogList does not exist. You may have already processed this request, or the DogList may not exist");
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
            else throw new Exception("User does not exist. You may have already processed this request, or the User may not exist");
        }
        
        public async Task<User> UpdateUser(User user)
        {
            return await _repo.UpdateUserAsync(user);
        }

        public async Task<User> AddUser(string uid)
        {
            if (await this.GetUser(uid) != null)
                return null;
            return await _repo.AddUserAsync(uid);
        }

        public async Task<List<Comments>> GetAllComments()
        {
            return await _repo.GetAllCommentsAsync();
        }

        public async Task<Comments> GetComment(int commentID)
        {
            return await _repo.GetCommentsByIdAsync(commentID);
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            return await _repo.AddCommentsAsync(comment);
        }

        public async Task<Comments> RemoveComments(Comments comments)
        {
            if (await _repo.GetCommentsByIdAsync(comments.CommentID) != null)
                return await _repo.DeleteCommentsAsync(comments);
            else throw new Exception("This comment does not exist. We may have already processed this request.");
        }

        public async Task<Comments> UpdateComment(Comments comments)
        {
            return await _repo.UpdateCommentsAsync(comments);
        }

        public async Task<List<Posts>> GetAllPosts()
        {
            return await _repo.GetAllPostsAsync();
        }

        public async Task<Posts> GetPost(int postID)
        {
            return await _repo.GetPostsByIdAsync(postID);
        }

        public async Task<List<Posts>> GetPostForForumWithID(int id)
        {
            return await _repo.GetPostForForumWithID(id);
        }

        public async Task<Posts> AddPost(Posts post)
        {
            return await _repo.AddPostsAsync(post);
        }

        public async Task<Posts> RemovePost(Posts post)
        {
            if (await _repo.GetPostsByIdAsync(post.PostID) != null)
                return await _repo.DeletePostsAsync(post);
            else throw new Exception("Looks like this post doesn't exist. We may have already processed this request.");
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            return await _repo.UpdatePostsAsync(post);
        }

        public async Task<List<Forum>> GetAllForums()
        {
            return await _repo.GetAllForumsAsync();
        }

        public async Task<Forum> GetForum(int forumID)
        {
            return await _repo.GetForumByIdAsync(forumID);
        }

        public async Task<Forum> AddForum(Forum forum)
        {
            /*
            if (await _repo.GetForumAsync(forum) != null)
                throw new Exception("This forum already exists.");
            */
            return await _repo.AddForumAsync(forum);
        }

        public async Task<Forum> RemoveForum(Forum forum)
        {
            if (await _repo.GetForumAsync(forum) != null)
                return await _repo.DeleteForumAsync(forum);
            throw new Exception("This Forum does not exist. We may have already processed this request.");
        }

        public async Task<Forum> UpdateForum(Forum forum)
        {
            return await _repo.UpdateForumAsync(forum);
        }

        public async Task<List<Like>> GetAllLikes()
        {
            return await _repo.GetAllLikesAsync();
        }

        public async Task<Like> GetLike(int likeID)
        {
            return await _repo.GetLikeByIdAsync(likeID);
        }

        public async Task<Like> AddLike(Like like)
        {
            return await _repo.AddLikesAsync(like);
        }

        public async Task<Like> RemoveLike(Like like)
        {
            return await _repo.DeleteLikeAsync(like);
        }

        public async Task<Like> UpdateLike(Like like)
        {
            return await _repo.UpdateLikeAsync(like);
        }

        public async Task<List<Preference>> GetAllPreferences()
        {
            return await _repo.GetAllPreferencesAsync();
        }

        public async  Task<List<Preference>> GetPreferencesFor(string UserID)
        {
            return await _repo.GetPreferenceForAsync(UserID);
        }

        public async Task<List<Preference>> GetRelatedPreferences(int tagID)
        {
            return await _repo.GetPreferenceByIdAsync(tagID);
        }

        public async Task<Preference> GetPreference(string userName, int tagID)
        {
            return await _repo.GetPreferenceAsync(new Preference(userName, tagID));
        }

        public async Task<Preference> AddPreference(Preference preference)
        {
            return await _repo.AddPreferenceAsync(preference); 
        }

        public async Task<Preference> RemovePreference(Preference preference)
        {
            return await _repo.DeletePreferenceAsync(preference);
        }

        public async Task<Preference> UpdatePreference(Preference preference)
        {
            return await _repo.UpdatePreferenceAsync(preference);
        }

        public async Task<List<ListedDog>> GetAllListedDogs()
        {
            return await _repo.GetAllListedDogsAsync();
        }

        public async Task<List<ListedDog>> GetListedDogsForDog(string dogID)
        {
            return await _repo.GetListedDogByDogIdAsync(dogID);
        }

        public async Task<List<ListedDog>> GetListedDogsForList(int listID)
        {
            return await _repo.GetListedDogByListIdAsync(listID); 
        }

        public async Task<ListedDog> GetListedDog(ListedDog dog)
        {
            return await _repo.GetListedDogAsync(dog); 
        }

        public async Task<ListedDog> AddListedDog(ListedDog dog)
        {
            return await _repo.AddListedDogasync(dog);
        }
        public async Task<bool> AddsListOfDogs(int id, string[] dogs)
        {
            try
            {
                foreach (string apiID in dogs)
                {
                    ListedDog toBeAddedDog = new ListedDog()
                    {
                        APIID = apiID,
                        ListID = id
                    };
                    await this.AddListedDog(toBeAddedDog);
                }
                return true;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<ListedDog> RemoveListedDog(ListedDog dog)
        {
            if (_repo.GetListedDogAsync(dog) != null)
            {
                return await _repo.DeleteListedDogAsync(dog);
            }
            throw new Exception("ListedDog does not exist. We may have already processed this reques!");
        }

        public async Task<ListedDog> UpdateListedDog(ListedDog dog)
        {
            return await _repo.UpdateListedDogAsync(dog);
        }

        public async Task<List<Tags>> GetAllTags()
        {
            return await _repo.GetAllTagsAsync();
        }

        public async Task<Tags> GetTag(int tagID)
        {
           return await _repo.GetTagsByIdAsync(tagID);
        }

        public async Task<Tags> AddTag(Tags tag)
        {
            return await _repo.AddTagsAsync(tag);
        }

        public async Task<Tags> RemoveTag(Tags tag)
        {
            return await _repo.DeleteTagsAsync(tag);
        } 

        public async Task<Tags> UpdateTag(Tags tag)
        {
            return await _repo.UpdateTagsAsync(tag);
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            return await _repo.GetAllAlertsAsync();
        }

        public async Task<List<Alert>> GetAlertsForUser(string userId)
        {
            return await _repo.GetAlertsForUserAsync(userId);
        }

        public async Task<Alert> AddAlert(Alert alert)
        {
            return await _repo.AddAlertAsync(alert);
        }

        public async Task<Alert> UpdateAlert(Alert alert)
        {
            return await _repo.UpdateAlertAsync(alert);
        }

        public async Task<Alert> RemoveAlert(Alert alert)
        {
            return await _repo.RemoveAlertAsync(alert);
        }
    }
}
