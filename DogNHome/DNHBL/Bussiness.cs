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
                throw new Exception("Dog already exists.");
            }
            return await _repo.AddDogAsync(dog);
        }

        public async Task<Dog> RemoveDog(Dog dog)
        {
            Dog toBeDeleted = await _repo.GetDogAsync(dog);
            if (toBeDeleted != null) return await _repo.DeleteDogAsync(toBeDeleted);
            else throw new Exception("Dog does not exist. You may have already processed this request.");
        }

        public async Task<Dog> RemoveDogByID(int dogID)
        {
            Dog toBeDeleted = await _repo.GetDogByIdAsync(dogID);
            if (toBeDeleted != null) return await _repo.DeleteDogAsync(toBeDeleted);
            else throw new Exception("Dog does not exist. You may have already processed this request.");
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
                throw new Exception("DogList already exists");
            }
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

        public async Task<User> AddUser(User user)
        {
            if (await _repo.GetUserAsync(user) != null)
            {
                throw new Exception("Looks like you already have an account!");
            }
            return await _repo.AddUserAsync(user);
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
            if (await _repo.GetCommentsByIdAsync(comment.CommentID) != null)
                throw new Exception("Looks like this comment already exists");
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

        public async Task<Posts> GetPostForForumWithID(int id)
        {
            return await _repo.GetPostForForumWithID(id);
        }

        public async Task<Posts> AddPost(Posts post)
        {
            if ( await _repo.GetPostsByIdAsync(post.PostID) != null)
                throw new Exception("This post already exists.");
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
            throw new NotImplementedException();
        }

        public async Task<Like> GetLike(int likeID)
        {
            return await _repo.GetLikeByIdAsync(likeID);
        }

        public async Task<Like> AddLike(Like like)
        {
            if (await _repo.GetLikeAsync(like) != null)
                throw new Exception("This Like already exists.");
            return await _repo.AddLikesAsync(like);
        }

        public async Task<Like> RemoveLike(Like like)
        {
            throw new NotImplementedException();
        }

        public async Task<Like> UpdateLike(Like like)
        {
            return await _repo.UpdateLikeAsync(like);
        }

        public async Task<List<Preference>> GetAllPreferences()
        {
            return await _repo.GetAllPreferencesAsync();
        }

        public async  Task<List<Preference>> GetPreferencesFor(string userName)
        {
            //return await _repo.GetPreferenceByIdAsync(userName);
            throw new NotImplementedException();
        }

        public async Task<List<Preference>> GetRelatedPreferences(int tagID)
        {
            //return await _repo.GetPreferenceByIdAsync(tagID);
            throw new NotImplementedException();
        }

        public async Task<Preference> GetPreference(string userName, int tagID)
        {
            return await _repo.GetPreferenceAsync(new Preference(userName, tagID));
        }

        public async Task<Preference> AddPreference(Preference preference)
        {
            throw new NotImplementedException(); // Not implemented in RepoDB
        }

        public async Task<Preference> RemovePreference(Preference preference)
        {
            //return await _repo.DeletePreference(preference);
            throw new NotImplementedException();
        }

        public async Task<Preference> UpdatePreference(Preference preference)
        {
            //return await _repo.UpdatePreference(preference);
            throw new NotImplementedException();
        }

        public async Task<List<ListedDog>> GetAllListedDogs()
        {
            return await _repo.GetAllListedDogsAsync();
        }

        public async Task<List<ListedDog>> GetListedDogsForDog(int dogID)
        {
            throw new NotImplementedException(); // Not implemented in RepoDB
        }

        public async Task<List<ListedDog>> GetListedDogsForList(int listID)
        {
            throw new NotImplementedException(); // Not implemented in RepoDB
        }

        public async Task<ListedDog> GetListedDog(int dogID, int listID)
        {
            return await _repo.GetListedDogByIdAsync(dogID); // ...???? this is a composite key, searching by a single id will return a list
        }

        public async Task<ListedDog> AddListedDog(ListedDog dog)
        {
            if (_repo.GetListedDogAsync(dog) != null)
                throw new Exception("ListedDog already exists!");
            return await _repo.AddListedDogasync(dog);
        }

        public async Task<ListedDog> RemoveListedDog(ListedDog dog)
        {
            if (_repo.GetListedDogAsync(dog) != null)
            return await _repo.DeleteListedDogAsync(dog);
            throw new Exception("ListedDog does not exist. We may have already processed this reques!");
        }

        public async Task<ListedDog> UpdateListedDog(ListedDog dog)
        {
            return await _repo.UpdateListedDogAsync(dog);
        }

        public async Task<List<Tags>> GetAllTags()
        {
            throw new NotImplementedException(); // Not implemented in RepoDB
        }

        public async Task<Tags> GetTag(int tagID)
        {
            throw new NotImplementedException();
           //return await _repo.GetTagsAsync(tagID); // ??? is this for all tags, if so, why do we pass an int
        }

        public async Task<Tags> AddTag(Tags tag)
        {
            //return await _repo.AddTag();
            throw new NotImplementedException(); // Not implemented in RepoDB
        }

        public async Task<Tags> RemoveTag(Tags tag)
        {
            //return _repo.DeleteTag(tag);
            throw new NotImplementedException(); // Not implemented in RepoDB
        } 

        public async Task<Tags> UpdateTag(Tags tag)
        {
            //return await _repo.UpdateTag(tag);
            throw new NotImplementedException(); // Not implemented in RepoDB
        }
    }
}
