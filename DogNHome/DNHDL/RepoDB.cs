﻿using System.Collections.Generic;
using System.Linq;
using DNHModels;
using System.Threading.Tasks;
using Model = DNHModels;
using Microsoft.EntityFrameworkCore;


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
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(
                user
                );
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> DeleteUserAsync(User user)
        {
            User toBeDeleted = _context.Users.AsNoTracking().First(use => use.UserName == user.UserName);
            _context.Users.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserAsync(User user)
        {
            //find me a restaurant from the db that is equal to the input restaurant
            User found = await _context.Users.AsNoTracking().FirstOrDefaultAsync(use => use.UserName == user.UserName);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new User();
        }

        //Done with User functions & starting with Dog 
        public async Task<Dog> AddDogAsync(Dog dog)
        {
            await _context.Dogs.AddAsync(
                dog
                );
            await _context.SaveChangesAsync();
            return dog;

        }
        public async Task<Dog> DeleteDogAsync(Dog dog)
        {
            Dog toBeDeleted = _context.Dogs.AsNoTracking().First(dg => dg.DogID == dog.DogID);
            _context.Dogs.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return dog;
        }
        public async Task<Dog> UpdateDogAsync(Dog dog)
        {
            _context.Dogs.Update(dog);
            await _context.SaveChangesAsync();
            return dog;
        }
        public async Task<Dog> GetDogByIdAsync(int id)
        {
            return await _context.Dogs.FindAsync(id);
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            return await _context.Dogs.AsNoTracking()
            .Select(
                restaurant => restaurant
            ).ToListAsync();
        }
        public async Task<Dog> GetDogAsync(Dog dog)
        {
            Dog found = await _context.Dogs.AsNoTracking().FirstOrDefaultAsync(dg => dg.DogID == dog.DogID);
            if (found == null) return null;
            return new Dog();
        }

        //Done with Dog functions & starting with Likes



        public async Task<Like> AddLikesAsync(Like likes)
        {
            await _context.Likes.AddAsync(
                likes
                );
            await _context.SaveChangesAsync();
            return likes;

        }
        public async Task<Like> UpdateLikeAsync(Like like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
            return like;
        }
        public async Task<Like> GetLikeByIdAsync(int id)
        {
            return await _context.Likes.FindAsync(id);
        }

        public async Task<Like> GetLikeAsync(Like like)
        {
            Like found = await _context.Likes.AsNoTracking().FirstOrDefaultAsync(lk => lk.DogID == like.DogID);
            if (found == null) return null;
            return new Like();
        }

        //Done with Like functions & starting with Tags

        public async Task<Tags> GetTagsAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tags> GetTagsAsync(Tags tags)
        {
            Tags found = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(tag => tag.TagID == tags.TagID);
            if (found == null) return null;
            return new Tags();
        }
        //Done with Tags & starting with Forums

        public async Task<Forum> AddForumAsync(Forum forum)
        {
            await _context.Forums.AddAsync(
                forum
                );
            await _context.SaveChangesAsync();
            return forum;
        }
        public async Task<Forum> DeleteForumAsync(Forum forum)
        {
            Forum toBeDeleted = _context.Forums.AsNoTracking().First(foru => foru.ForumID == forum.ForumID);
            _context.Forums.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return forum;
        }
        public async Task<Forum> UpdateForumAsync(Forum forum)
        {
            _context.Forums.Update(forum);
            await _context.SaveChangesAsync();
            return forum;
        }
        public async Task<Forum> GetForumByIdAsync(int id)
        {
            return await _context.Forums.FindAsync(id);
        }
        public async Task<List<Forum>> GetAllForumsAsync()
        {
            return await _context.Forums.AsNoTracking()
            .Select(
                forum => forum
            ).ToListAsync();
        }

        public async Task<Forum> GetForumAsync(Forum forum)
        {
            Forum found = await _context.Forums.AsNoTracking().FirstOrDefaultAsync(foru => foru.ForumID == forum.ForumID);  
            if (found == null) return null;
            return new Forum();
        }

        //Done with Forums & starting with Posts
        public async Task<Posts> AddPostsAsync(Posts posts)
        {
            await _context.Posts.AddAsync(
                posts
                );
            await _context.SaveChangesAsync();
            return posts;
        }
        public async Task<Posts> DeletePostsAsync(Posts posts)
        {
            Posts toBeDeleted = _context.Posts.AsNoTracking().First(post => post.PostID == posts.PostID);
            _context.Posts.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return posts;
        }
        public async Task<Posts> UpdatePostsAsync(Posts posts)
        {
            _context.Posts.Update(posts);
            await _context.SaveChangesAsync();
            return posts;
        }
        public async Task<Posts> GetPostsByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }
        public async Task<List<Posts>> GetAllPostsAsync()
        {
            return await _context.Posts.AsNoTracking()
            .Select(
                posts => posts
            ).ToListAsync();
        }
        public async Task<Posts> GetPostsAsync(Posts posts)
        {
            Posts found = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(post => post.PostID == posts.PostID);
            if (found == null) return null;
            return new Posts();
        }

        //Done with Posts & starting with Comments

        public async Task<Comments> AddCommentsAsync(Comments comments)
        {
            await _context.Comments.AddAsync(
                comments
                );
            await _context.SaveChangesAsync();
            return comments;
        }
        public async Task<Comments> DeleteCommentsAsync(Comments comments)
        {
            Comments toBeDeleted = _context.Comments.AsNoTracking().First(comm => comm.PostID == comments.PostID);
            _context.Comments.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return comments;
        }
        public async Task<Comments> UpdateCommentsAsync(Comments comments)
        {
            _context.Comments.Update(comments);
            await _context.SaveChangesAsync();
            return comments;
        }
        public async Task<Comments> GetCommentsByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.AsNoTracking()
            .Select(
                comments => comments
            ).ToListAsync();
        }

        public async Task<Comments> GetCommentsAsync(Comments comments)
        {
            Comments found = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(comm => comm.PostID == comments.PostID);
            if (found == null) return null;
            return new Comments();
        }
        //Done with Comments & starting with Preference

        public async Task<Preference> GetPreferenceByIdAsync(int id)
        {
            return await _context.Preferences.FindAsync(id);
        }
        public async Task<List<Preference>> GetAllPreferencesAsync()
        {
            return await _context.Preferences.AsNoTracking()
            .Select(
                preferences => preferences
            ).ToListAsync();
        }
        public async Task<Preference> GetPreferenceAsync(Preference preference)
        {
            Preference found = await _context.Preferences.AsNoTracking().FirstOrDefaultAsync(pref => pref.TagID == preference.TagID);
            if (found == null) return null;
            return new Preference();
        }

        //Done with Preferences
    }
}
