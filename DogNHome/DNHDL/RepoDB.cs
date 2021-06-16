using System.Collections.Generic;
using System.Linq;
using DNHModels;
using System.Threading.Tasks;
using Model = DNHModels;
using Microsoft.EntityFrameworkCore;

using Serilog;
using System;

//Still need to do DogList, Listed Dogs, and List of Dogs by List ID
namespace DNHDL
{
    public class RepoDB : IRepository
    {

        private DNHDBContext _context;

        public RepoDB(DNHDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// All of the User Functions
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(string uid)
        {
            User newUser = new User()
            {
                UserID = uid,
            };
            await _context.Users.AddAsync(
                newUser
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding {0} to the database.", uid);
            return newUser;
        }
        public async Task<User> DeleteUserAsync(User user)
        {
            
            User toBeDeleted = _context.Users.AsNoTracking().First(use => use.UserID == user.UserID);
            _context.Users.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing {0} from the database.", user.UserID);
            return user;
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            Log.Debug("Updating {0} in the database.", user.UserID);
            return user;
        }
        public async Task<User> GetUserByIdAsync(string uid)
        {
            Log.Debug("Getting {0} from the database.", uid);
            return await _context.Users.FirstAsync(use => use.UserID == uid);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            Log.Debug("Getting all user from the database.");
            return await _context.Users.AsNoTracking()
            .Select(
                user => user
            ).ToListAsync();
        }

        public async Task<User> GetUserAsync(User user)
        {
            User found = await _context.Users.AsNoTracking().FirstOrDefaultAsync(use => use.UserID == user.UserID);
            if (found == null)
            {
                Log.Error("User does not exist!");
                return null; }
            Log.Debug("Getting {0} {1} in the database.", user.UserID);
            return found;
        }


        //Done with Dog functions & starting with Likes



        public async Task<Like> AddLikesAsync(Like like)
        {
            await _context.Likes.AddAsync(
                like
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding likes to the database: {0}", like.UserName);
            return like;

        }
        public async Task<Like> DeleteLikeAsync(Like like)
        {
            Like toBeDeleted = _context.Likes.AsNoTracking().First(lik => lik.DogID == like.DogID && lik.UserName == like.UserName);
            _context.Likes.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing likes from the database: {0}", like.UserName);
            return like;
        }
        public async Task<Like> UpdateLikeAsync(Like like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
            Log.Debug("Updating likes from the database: {0}", like.UserName);
            return like;
        }
        public async Task<Like> GetLikeByIdAsync(int id)
        {
            Log.Debug("Getting likes from the database by ID: {0}", id);
            return await _context.Likes.FindAsync(id);
        }
        public async Task<List<Like>> GetAllLikesAsync()
        {
            Log.Debug("Getting all likes from the database.");
            return await _context.Likes.AsNoTracking()
            .Select(
                likes => likes
            ).ToListAsync();
        }

        public async Task<Like> GetLikeAsync(Like like)
        {
            Log.Debug("Getting likes from the database: {0}", like.UserName);
            Like found = await _context.Likes.AsNoTracking().FirstOrDefaultAsync(lk => lk.DogID == like.DogID);
            if (found == null) return null;
            return new Like(found.UserName,found.DogID);
        }

        //Done with Like functions & starting with Tags

        public async Task<Tags> AddTagsAsync(Tags tags)
        {
            
            await _context.Tags.AddAsync(
                tags
                );
            await _context.SaveChangesAsync();

            Log.Debug("Adding Tags into the database: {0}", tags.TagID);
            return tags;

        }
        public async Task<Tags> DeleteTagsAsync(Tags tags)
        {
            Tags toBeDeleted = _context.Tags.AsNoTracking().First(tag => tag.TagID== tags.TagID && tag.Description == tags.Description);
            _context.Tags.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing Tags from the database: {0}", tags.TagID);
            return tags;
        }
        public async Task<Tags> UpdateTagsAsync(Tags tags)
        {
            _context.Tags.Update(tags);
            await _context.SaveChangesAsync();
            Log.Debug("Updating Tags into the database: {0}", tags.TagID);
            return tags;
        }
        public async Task<Tags> GetTagsByIdAsync(int id)
        {
            Log.Debug("Getting Tags from the database by ID: {0}", id);
            return await _context.Tags.FindAsync(id);
        }
        public async Task<List<Tags>> GetAllTagsAsync()
        {
            Log.Debug("Getting all Tags from the database");
            return await _context.Tags.AsNoTracking()
            .Select(
                tags => tags
            ).ToListAsync();
        }
        public async Task<Tags> GetTagsAsync(Tags tags)
        {
            Tags found = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(tag => tag.TagID == tags.TagID);
            if (found == null) 
            {
                Log.Error("Tags already exists!");
                return null; }
            Log.Debug("Getting Tags from the database: {0}", tags.TagID);
            return new Tags(found.TagID, found.Description);
        }
        //Done with Tags & starting with Forums

        public async Task<Forum> AddForumAsync(Forum forum)
        {
            await _context.Forums.AddAsync(
                forum
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding Forums into the database: {0}", forum.ForumID);
            return forum;
        }
        public async Task<Forum> DeleteForumAsync(Forum forum)
        {
            Forum toBeDeleted = _context.Forums.AsNoTracking().First(foru => foru.ForumID == forum.ForumID);
            _context.Forums.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing Forums from the database: {0}", forum.ForumID);
            return forum;
        }
        public async Task<Forum> UpdateForumAsync(Forum forum)
        {
            _context.Forums.Update(forum);
            await _context.SaveChangesAsync();
            Log.Debug("Updating Forums from the database: {0}", forum.ForumID);
            return forum;
        }
        public async Task<Forum> GetForumByIdAsync(int id)
        {
            Log.Debug("Getting Forums from the database by ID: {0}", id);
            return await _context.Forums.FindAsync(id);
        }
        public async Task<List<Forum>> GetAllForumsAsync()
        {
            Log.Debug("Getting all Forums from the database");
            return await _context.Forums.AsNoTracking()
            .Select(
                forum => forum
            ).ToListAsync();
        }

        public async Task<Forum> GetForumAsync(Forum forum)
        {
            Forum found = await _context.Forums.AsNoTracking().FirstOrDefaultAsync(foru => foru.Topic == forum.Topic);
            if (found == null)
            {
                Log.Error("Forum does not exist!");
                return null;
            }
            Log.Debug("Getting Forums from the database: {0}", forum.ForumID);
            return new Forum(found.ForumID,found.Topic,found.Description);
        }

        //Done with Forums & starting with Posts
        public async Task<Posts> AddPostsAsync(Posts posts)
        {
            try
            {
                await _context.Posts.AddAsync(
                    posts
                    );
                await _context.SaveChangesAsync();
                Log.Debug("Adding Posts into the database: {0}", posts.PostID);
                return posts;
            } catch (Exception e)
            {
                Log.Error("Failed to Add Post: " + posts + "\n" + e.Message);
                return null;
            }
        }
        public async Task<Posts> DeletePostsAsync(Posts posts)
        {
            Posts toBeDeleted = _context.Posts.AsNoTracking().First(post => post.PostID == posts.PostID);
            _context.Posts.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing Posts from the database: {0}", posts.PostID);
            return posts;
        }
        public async Task<Posts> UpdatePostsAsync(Posts posts)
        {
            _context.Posts.Update(posts);
            await _context.SaveChangesAsync();
            Log.Debug("Updating Posts from the database: {0}", posts.PostID);
            return posts;
        }
        public async Task<Posts> GetPostsByIdAsync(int id)
        {
            Log.Debug("Getting Posts from the database by ID: {0}", id);
            return await _context.Posts.FindAsync(id);
        }
        public async Task<List<Posts>> GetPostForForumWithID(int id)
        {
            Log.Debug("Getting Posts from the database by forumID: {0}", id);
            return await _context.Posts.Select( post => post)
                .Where(post => post.ForumID == id)
                .ToListAsync();
        }
        public async Task<List<Posts>> GetAllPostsAsync()
        {
            try
            {
                Log.Debug("Getting all Posts from the database.");
                return await _context.Posts.AsNoTracking()
                .Select(
                    posts => posts
                ).ToListAsync();
            } catch(Exception e)
            {
                Log.Error("Failed to retrieve all Posts \n" + e.Message);
                return null;
            }
        }
        public async Task<Posts> GetPostsAsync(Posts posts)
        {

            Posts found = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(post => post.PostID == posts.PostID);
            if (found == null) 
            {
                Log.Error("Post does not exist!");    
                return null; }
            Log.Debug("Getting Posts from the database: {0}", posts.PostID);
            return new Posts(found.PostID,found.Topic,found.UserCreator,found.ForumID);
        }

        //Done with Posts & starting with Comments

        public async Task<Comments> AddCommentsAsync(Comments comments)
        {
            await _context.Comments.AddAsync(
                comments
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding Comment into the database: {0}", comments.PostID);
            return comments;
        }
        public async Task<Comments> DeleteCommentsAsync(Comments comments)
        {
            Comments toBeDeleted = _context.Comments.AsNoTracking().First(comm => comm.CommentID == comments.CommentID);
            _context.Comments.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing Comment from the database: {0}", comments.CommentID);
            return comments;
        }
        public async Task<Comments> UpdateCommentsAsync(Comments comments)
        {
            _context.Comments.Update(comments);
            await _context.SaveChangesAsync();
            Log.Debug("Updating Comment from the database: {0}", comments.CommentID);
            return comments;
        }
        public async Task<Comments> GetCommentsByIdAsync(int id)
        {
            Log.Debug("Getting Comment from the database by ID: {0}", id);
            return await _context.Comments.FirstOrDefaultAsync(comm => comm.CommentID == id);
        }
        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            Log.Debug("Getting all Comments from the database");
            return await _context.Comments.AsNoTracking()
            .Select(
                comments => comments
            ).ToListAsync();
        }

        public async Task<Comments> GetCommentsAsync(Comments comments)
        {
            Comments found = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(comm => comm.PostID == comments.PostID);
            if (found == null) return null;
            Log.Debug("Getting Comment from the database: {0}", comments.PostID);
            return new Comments(found.CommentID, found.PostID, found.UserName, found.Created, found.Message);
        }
        //Done with Comments & starting with Preference

        public async Task<Preference> AddPreferenceAsync(Preference preference)
        {
            await _context.Preferences.AddAsync(
                preference
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding preference into the database: {0}", preference.TagID);
            return preference;
        }
        public async Task<Preference> DeletePreferenceAsync(Preference preference)
        {
            Preference toBeDeleted = _context.Preferences.AsNoTracking().First(pref => pref.TagID == preference.TagID && pref.UserName == preference.UserName);
            _context.Preferences.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing preference from the database: {0}", preference.TagID);
            return preference;
        }
        public async Task<Preference> UpdatePreferenceAsync(Preference preference)
        {
            _context.Preferences.Update(preference);
            await _context.SaveChangesAsync();
            Log.Debug("Updating preference from the database: {0}", preference.TagID);
            return preference;
        }
        public async Task<List<Preference>> GetPreferenceByIdAsync(int id)
        {
            Log.Debug("Getting preference from the database: {0}", id);
            return await _context.Preferences.Select(pref => pref )
                .Where(pref => pref.TagID == id)
                .ToListAsync();
        }
        public async Task<List<Preference>> GetAllPreferencesAsync()
        {
            Log.Debug("Getting all preferences from the database.");
            return await _context.Preferences.AsNoTracking()
            .Select(
                preferences => preferences
            ).ToListAsync();
        }
        public async Task<Preference> GetPreferenceAsync(Preference preference)
        {
            Preference found = await _context.Preferences.AsNoTracking().FirstOrDefaultAsync(pref => pref.TagID == preference.TagID);
            if (found == null) return null;
            Log.Debug("Getting preference from the database: {0}", preference.TagID);
            return new Preference(found.UserName,found.TagID);
        }

        public async Task<List<Preference>> GetPreferenceForAsync(string userName)
        {
            return await _context.Preferences.Select(pref => pref)
                .Where(pref => pref.UserName == userName)
                .ToListAsync();
        }
        //Done with Preferences and continue with ListedDog

        public async Task<DogList> AddDogListasync(DogList dogList)
        {
            await _context.DogLists.AddAsync(
                dogList
                );
            await _context.SaveChangesAsync();
            Log.Debug("Adding DogList into the database: {0}", dogList.ListID);
            return dogList;
        }
        public async Task<DogList> DeleteDogListAsync(DogList dogList)
        {
            DogList toBeDeleted = _context.DogLists.AsNoTracking().First(dgl => dgl.ListID == dogList.ListID);
            _context.DogLists.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing DogList from the database: {0}", dogList.ListID);
            return dogList;
        }
        public async Task<DogList> UpdateDogListAsync(DogList dogList)
        {
            _context.DogLists.Update(dogList);
            await _context.SaveChangesAsync();
            Log.Debug("Updating DogList from the database: {0}", dogList.ListID);
            return dogList;
        }
        public async Task<DogList> GetDogListByIdAsync(int id)
        {
            Log.Debug("Getting DogList from the database by ID: {0}", id);
            return await _context.DogLists.FindAsync(id);
        }
        public async Task<List<DogList>> GetAllDogListsAsync()
        {
            Log.Debug("Getting DogList from the database.");
            return await _context.DogLists.AsNoTracking()
            .Select(
                dogList => dogList
            ).ToListAsync();
        }

        public async Task<DogList> GetDogListAsync(DogList dogList)
        {
            DogList found = await _context.DogLists.AsNoTracking().FirstOrDefaultAsync(dgl => dgl.ListID == dogList.ListID);
            if (found == null)
            {
                Log.Error("DogList does not exist!");
                return null;
            }
            Log.Debug("Getting DogList into the database: {0}", dogList.ListID);
            return new DogList(found.ListID, found.Title, found.Created, found.UserName);
        }

        public async Task<List<DogList>> GetDogListForAsync(string Username) //Check my logic here please
        {
            Log.Debug("Getting all DogLists from the database by username: {0}", Username);
            return await _context.DogLists.AsNoTracking()
            .Select(
                Username => Username
            ).ToListAsync();
        }

        //Finished with DogList and Continuing with ListedDog
        public async Task<ListedDog> AddListedDogasync(ListedDog listDog)
        {
            await _context.ListedDogs.AddAsync(
                listDog
                );
            await _context.SaveChangesAsync();
            return listDog;
        }
        public async Task<ListedDog> DeleteListedDogAsync(ListedDog listedDog)
        {
            ListedDog toBeDeleted = _context.ListedDogs.AsNoTracking().First(ldg => ldg.ListID == listedDog.ListID);
            _context.ListedDogs.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            Log.Debug("Removing ListedDog from the database: {0}", listedDog.ListID);
            return listedDog;
        }
        public async Task<ListedDog> UpdateListedDogAsync(ListedDog listedDog)
        {
            _context.ListedDogs.Update(listedDog);
            await _context.SaveChangesAsync();
            Log.Debug("Updating ListedDog from the database: {0}", listedDog.ListID);
            return listedDog;
        }
        public async Task<List<ListedDog>> GetListedDogByDogIdAsync(string id)
        {
            Log.Debug("Removing ListedDog from the database by ID: {0}", id);
            return await _context.ListedDogs.Select(dog => dog)
                .Where(dog => dog.APIID == id)
                .ToListAsync();
        }
        public async Task<List<ListedDog>> GetListedDogByListIdAsync(int id)
        {
            Log.Debug("Removing ListedDog from the database by ID: {0}", id);
            return await _context.ListedDogs.Select(dog => dog)
                .Where(dog => dog.ListID == id)
                .ToListAsync();
        }
        public async Task<List<ListedDog>> GetAllListedDogsAsync()
        {
            Log.Debug("Getting all ListedDogs from the database.");
            return await _context.ListedDogs.AsNoTracking()
            .Select(
                listedDog => listedDog
            ).ToListAsync();
        }

        public async Task<ListedDog> GetListedDogAsync(ListedDog listedDog)
        {
            ListedDog found = await _context.ListedDogs.AsNoTracking().FirstOrDefaultAsync(ldg => ldg.ListID == listedDog.ListID);
            if (found == null) 
            {
                Log.Error("Listed Dog does not exist!");
                return null;
            }
            Log.Debug("Getting ListedDog from the database: {0}", listedDog.ListID);
            return new ListedDog(found.APIID, found.ListID);
        }
        public async Task<List<Alert>> GetAllAlertsAsync()
        {
            try
            {
                return await _context.Alert.Select(alert => alert).ToListAsync();
            }
            catch(Exception e)
            {
                Log.Error("Failed to Gather all Alerts!",e.Message);
                return null;
            }
        }

        public async Task<List<Alert>> GetAlertsForUserAsync(string userId)
        {
            try
            {
                return await _context.Alert.Select(alert => alert)
                    .Where(alert => alert.UserID == userId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Log.Error("Failed to Gather all Alerts for user with ID " + userId, e.Message);
                return null;
            }
        }

        public async Task<Alert> AddAlertAsync(Alert alert)
        {
            try
            {
                await _context.Alert.AddAsync(alert);
                await _context.SaveChangesAsync();
                return alert;
            }
            catch (Exception e)
            {
                Log.Error("Failed to Add Alert with ID " + alert.AlertID, e.Message);
                return null;
            }
        }

        public async Task<Alert> UpdateAlertAsync(Alert alert)
        {
            try
            {
                _context.Alert.Update(alert);
                await _context.SaveChangesAsync();
                return alert;
            }
            catch (Exception e)
            {
                Log.Error("Failed to Update Alert with ID " + alert.AlertID, e.Message);
                return null;
            }
        }

        public async Task<Alert> RemoveAlertAsync(Alert alert)
        {
            try
            {
                _context.Alert.Remove(alert);
                await _context.SaveChangesAsync();
                return alert;
            }
            catch (Exception e)
            {
                Log.Error("Failed to Remove Alert with ID " + alert.AlertID, e.Message);
                return null;
            }
        }

    }
}
