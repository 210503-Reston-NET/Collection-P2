using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNHModels;

namespace DNHBL
{
    public interface IBussiness
    {

        Task<List<DogList>> GetAllDogLists();
        /// <summary>
        /// Returns all DogList Objects from Database for given User
        /// </summary>
        /// <param name="UserName">Unique Username</param>
        /// <returns></returns>
        Task<List<DogList>> GetDogListsFor(string UserName);
        /// <summary>
        /// Returns a single DogList Object for the given ListID
        /// </summary>
        /// <param name="ListID">Primary Key for the expected DogList</param>
        /// <returns></returns>
        Task<DogList> GetDogListByID(int ListID);
        /// <summary>
        /// Adds a new List to the Database for a related User
        /// </summary>
        /// <param name="list">List Object to be added</param>
        /// <returns></returns>
        Task<DogList> AddNewDogList(DogList list);
        /// <summary>
        /// Adds an array of listedDogs for a given listID
        /// </summary>
        /// <param name="id">The id of the list to be added to</param>
        /// <param name="dogs">The dogs to be added to given list</param>
        /// <returns></returns>
        Task<bool> AddsListOfDogs(int id, string[] dogs);
        /// <summary>
        /// Removes given DogList Object from the Database
        /// </summary>
        /// <param name="dogID">Primary Key for the expected Dog</param>
        /// <returns></returns>
        Task<DogList> RemoveDogList(int dogID);
        /// <summary>
        /// Updates the given DogList Object in the Database
        /// </summary>
        /// <param name="list">new DogList Object to be updated</param>
        /// <returns></returns>
        Task<DogList> UpdateDogList(DogList list);
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
        /// <summary>
        /// Creates a user in the Database, based off of the user object passed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> AddUser(string uid);
        /// <summary>
        /// Returns all Comments in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Comments>> GetAllComments();
        /// <summary>
        /// Returns a Comment Object with the given commentID
        /// </summary>
        /// <returns></returns>
        Task<List<Comments>> GetComment(int commentID);
        /// <summary>
        /// Creates a Comment in the Database, based off of the Comment object passed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Comments> AddComment(Comments comment);
        /// <summary>
        /// Removes a Comment from the Database for the given Comment 
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<Comments> RemoveComments(Comments comments);
        /// <summary>
        /// Updates the given Comment Object in the Database
        /// </summary>
        /// <param name="user">Comment Object to be updated</param>
        /// <returns></returns>
        Task<Comments> UpdateComment(Comments comments);
        /// <summary>
        /// Returns all Posts in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Posts>> GetAllPosts();
        /// <summary>
        /// Creates a Post in the Database, based off of the Post object passed
        /// </summary>
        /// <returns></returns>
        Task<Posts> AddPost(Posts post);
        /// <summary>
        /// Returns a Post Object with the given forumID
        /// </summary>
        /// <param name="id">forumID</param>
        /// <returns></returns>
        Task<List<Posts>> GetPostForForumWithID(int id);
        /// <summary>
        /// Removes a Post from the Database for the given Post 
        /// </summary>
        /// <returns></returns>
        Task<Posts> RemovePost(Posts post);
        /// <summary>
        /// Updates the given Post Object in the Database
        /// </summary>
        /// <returns></returns>
        Task<Posts> UpdatePost(Posts post);
        /// <summary>
        /// Returns all Forums in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Forum>> GetAllForums();
        /// <summary>
        /// Returns a Forum Object with the given ForumID
        /// </summary>
        /// <returns></returns>
        Task<Forum> GetForum(int forumID);
        /// <summary>
        /// Creates a Forum in the Database, based off of the Forum object passed
        /// </summary>
        /// <returns></returns>
        Task<Forum> AddForum(Forum forum);
        /// <summary>
        /// Removes a Forum from the Database for the given Post 
        /// </summary>
        /// <returns></returns>
        Task<Forum> RemoveForum(Forum forum);
        /// <summary>
        /// Updates the given Forum Object in the Database
        /// </summary>
        /// <returns></returns>
        Task<Forum> UpdateForum(Forum forum);
        /// <summary>
        /// Returns all Likes in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Like>> GetAllLikes();
        /// <summary>
        /// Returns a Like Object with the given LikeID
        /// </summary>
        /// <returns></returns>
        Task<Like> GetLike(int likeID);
        /// <summary>
        /// Creates a Like in the Database, based off of the Like object passed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Like> AddLike(Like like);
        /// <summary>
        /// Removes a Like from the Database for the given Like 
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<Like> RemoveLike(Like like);
        /// <summary>
        /// Updates the given Like Object in the Database
        /// </summary>
        /// <returns></returns>
        Task<Like> UpdateLike(Like like);
        /// <summary>
        /// Returns all preferences in Database
        /// </summary>
        /// <returns></returns>
        /*
        /// Removed because unused/
        Task<List<Preference>> GetAllPreferences();
        /// <summary>
        /// Returns all preferences in Database for the given userName
        /// </summary>
        /// <returns></returns>
        Task<List<Preference>> GetPreferencesFor(string userName);
        /// <summary>
        /// Returns all Preferences in Database for the related tagID
        /// </summary>
        /// <returns></returns>
        Task<List<Preference>> GetRelatedPreferences(int tagID);
        /// <summary>
        /// Returns a Preference Object with the given tagID and userName
        /// </summary>
        /// <returns></returns>
        Task<Preference> GetPreference(string userName, int tagID);
        /// <summary>
        /// Creates a Preference in the Database, based off of the Preference object passed
        /// </summary>
        /// <returns></returns>
        Task<Preference> AddPreference(Preference preference);
        /// <summary>
        /// Removes a Preference from the Database for the given Prefrence 
        /// </summary>
        /// <returns></returns>
        Task<Preference> RemovePreference(Preference preference);
        /// <summary>
        /// Updates the given Preference Object in the Database
        /// </summary>
        /// <returns></returns>
        Task<Preference> UpdatePreference(Preference preference);
        /// <summary>
        /// Returns all dogs that are referenced in a list and also in the Database
        /// </summary>
        /// <returns></returns>
        /// */
        Task<List<ListedDog>> GetAllListedDogs();
        /// <summary>
        /// Returns all dogs with a given dogID that is also referenced in both a list and the Database
        /// </summary>
        /// <returns></returns>
        Task<List<ListedDog>> GetListedDogsForDog(string dogID);
        /// <summary>
        /// Returns all dogs for a given list based off of given listID in Database
        /// </summary>
        /// <returns></returns>
        Task<List<ListedDog>> GetListedDogsForList(int listID);
        /// <summary>
        /// Returns a Dog that is referenced in a list with the given dogID and listID
        /// </summary>
        /// <returns></returns>
        Task<ListedDog> GetListedDog(ListedDog dog);
        /// <summary>
        /// adds a Fog referenced in a list to the Database, based off of the ListedDog object passed
        /// </summary>
        /// <returns></returns>
        Task<ListedDog> AddListedDog(ListedDog dog);
        /// <summary>
        /// Removes a dog referenced in a list to the Database for the given ListedDog 
        /// </summary>
        /// <returns></returns>
        Task<ListedDog> RemoveListedDog(ListedDog dog);
        /// <summary>
        /// Updates the given dog referenced in a list that is also in the Database
        /// </summary>
        /// <returns></returns>
        Task<ListedDog> UpdateListedDog(ListedDog dog);
        /*
         * Not using this
         * 
        /// <summary>
        /// Returns all Tags in Database
        /// </summary>
        /// <returns></returns>
        Task<List<Tags>> GetAllTags();
        /// <summary>
        /// Returns a Tag Object with the given tagID
        /// </summary>
        /// <returns></returns>
        Task<Tags> GetTag(int tagID);
        /// <summary>
        /// Creates a Tag in the Database, based off of the Tag object passed
        /// </summary>
        /// <returns></returns>
        Task<Tags> AddTag(Tags tag);
        /// <summary>
        /// Removes a Tag from the Database for the given Tag 
        /// </summary>
        /// <returns></returns>
        Task<Tags> RemoveTag(Tags tag);
        /// <summary>
        /// Updates the given Tag Object in the Database
        /// </summary>
        /// <returns></returns>
        Task<Tags> UpdateTag(Tags tag);
        /// <summary>
        /// Returns all alerts stored in database
        /// </summary>
        /// */
        Task<List<Alert>> GetAllAlerts();
        /// <summary>
        /// Returns the Alert for a given user with id
        /// </summary>
        /// <param name="id">UserID used to reference which alerts to retrieve</param>
        /// <returns></returns>
        Task<List<Alert>> GetAlertsForUser(string userId);
        /// <summary>
        /// Adds the given Alert object to the Database
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        Task<Alert> AddAlert(Alert alert);
        /// <summary>
        /// Updates a given alert with the new given alert
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        Task<Alert> UpdateAlert(Alert alert);
        /// <summary>
        /// Removes the referenced Alert object from the data base
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        Task<Alert> RemoveAlert(Alert alert);

    }
}
