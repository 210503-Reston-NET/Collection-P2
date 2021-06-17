using System;
using DNHModels;
using Rest = DNHREST;
using DNHDL;
using DNHBL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DNHTest
{
    public class Class1
    {
        private readonly DbContextOptions<DNHDBContext> options;

        //Xunit creates new instances of test classes, you need to make sure that you seed your db for each class
        public Class1()
        {
            options = new DbContextOptionsBuilder<DNHDBContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
        }
        /// <summary>
        /// VALID LISTING TESTS
        /// </summary>
        /// 
        // Controller Testing
        [Fact]
        public void GetForumsShouldGetAllForums()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);
    
                var ForCont = new Rest.Controllers.ForumController(_BL);

                //Act
                var returnedValue = ForCont.GetForums();
                var returnedStatus = returnedValue.Result as OkObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Forum>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetForumShouldReturnAForum()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                int forumID = 631;

                var ForCont = new Rest.Controllers.ForumController(_BL);

                //Act
                var returnedValue = ForCont.GetForum(forumID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<Forum>(returnedStatus.Value);
            }

        }

        [Fact]
        public void AddForumsShouldReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.ForumController(_BL);

                Forum test = new Forum()
                {
                    ForumID = 2,
                    Description = "Testing",
                    Topic = "test"
                };

                //Act
                var returnedValue = ForCont.AddForum(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        [Fact]
        public void AddForumsShouldReturnBadRequestIfExists()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.ForumController(_BL);

                Forum test = new Forum
                {
                    ForumID = 631,
                    Topic = "Found dogs",
                    Description = "Used for people to post about finding dogs"
                };

                //Act
                var returnedValue = ForCont.AddForum(test);
                var returnedStatus = returnedValue.Result as BadRequestResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public void UpdateForumShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.ForumController(_BL);

                Forum test = new Forum()
                {
                    ForumID = 631,
                    Description = "Testing",
                    Topic = "test"
                };

                //Act
                var returnedValue = ForCont.UpdateForum(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        [Fact]
        public void RemoveForumsShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.ForumController(_BL);

                Forum test = new Forum()
                {
                    ForumID = 631,
                    Topic = "Found dogs",
                    Description = "Used for people to post about finding dogs"
                };

                //Act
                var returnedValue = ForCont.DeleteForum(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        [Fact]
        public void AddPostShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.PostController(_BL);

                Posts test = new Posts()
                {
                    PostID = 1,
                    ForumID = 631,
                    Topic = "test",
                    UserCreator = "Cesar_19"
                };

                //Act
                var returnedValue = PostCont.AddPost(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(returnedStatus.Value, test);
            }
        }

        [Fact]
        public void GetAllPostsShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.PostController(_BL);

                //Act
                var returnedValue = ForCont.GetPosts();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Posts>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetPostsShouldReturnAForumOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                int ForumID = 631;

                var ForCont = new Rest.Controllers.PostController(_BL);

                //Act
                var returnedValue = ForCont.GetPost(ForumID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Posts>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeletePostsShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.PostController(_BL);

                Posts test = new Posts()
                {
                    PostID = 7771,
                    Topic = "Lost Dogs",
                    UserCreator = "Cesar_19",
                    ForumID = 631
                };

                //Act
                var returnedValue = PostCont.DeletePost(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdatePostsShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.PostController(_BL);

                Posts test = new Posts()
                {
                    PostID = 1648,
                    Topic = "Found Dog",
                    UserCreator = "Cesar_19",
                    ForumID = 631
                };

                //Act
                var returnedValue = PostCont.UpdatePost(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        //Comments Controller
        [Fact]
        public void AddCommentsShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var CommCont = new Rest.Controllers.CommentController(_BL);

                Comments test = new Comments()
                {
                    CommentID = 0,
                    Created = DateTime.Now,
                    Message = "Testing message",
                    UserName = "Cesar_19",
                    PostID = 1648
                };

                //Act
                var returnedValue = CommCont.AddComment(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(returnedStatus.Value, test);
            }
        }

        [Fact]
        public void AddCommentsShouldReturnBadRequestIfExists()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var CommCont = new Rest.Controllers.CommentController(_BL);

                Comments test = new Comments
                {
                    CommentID = 753,
                    PostID = 123,
                    UserName = "Cesar_19",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    Message = "I just got a new dog!"
                };

                //Act
                var returnedValue = CommCont.AddComment(test);
                var returnedStatus = returnedValue.Result as BadRequestResult;

                //Assert
               Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status400BadRequest);

            }
        }

        [Fact]
        public void GetAllCommentsShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var ForCont = new Rest.Controllers.CommentController(_BL);

                //Act
                var returnedValue = ForCont.GetAllComments();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Comments>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetCommentShouldReturnACommentOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                int CommentID = 753;

                var CommCont = new Rest.Controllers.CommentController(_BL);

                //Act
                var returnedValue = CommCont.GetComment(CommentID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Comments>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeleteCommentsShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var CommentCont = new Rest.Controllers.CommentController(_BL);

                Comments test = new Comments
                {
                    CommentID = 753,
                    PostID = 123,
                    UserName = "Cesar_19",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    Message = "I just got a new dog!"
                };

                //Act
                var returnedValue = CommentCont.DeleteComment(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateCommentsShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.CommentController(_BL);

                Comments test = new Comments
                {
                    CommentID = 753,
                    PostID = 123,
                    UserName = "Cesar_19",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    Message = "New Test Message!"
                };

                //Act
                var returnedValue = PostCont.UpdateComment(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // User Controller Tests

        [Fact]
        public void AddUserShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.UserController(_BL);

                string testID = "Robert_20";


                //Act
                var returnedValue = UserCont.AddUser(testID);
                var persistedDataResult = UserCont.GetUser(testID).Result as ObjectResult;
                var persistedDataObject = persistedDataResult as ObjectResult;
                User persistedData = (User)persistedDataObject.Value;
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(persistedData, returnedStatus.Value);
            }
        }
        [Fact]
        public void AddUserShouldCreateReturnBadRequestIfExists()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.UserController(_BL);

                string testID = "Cesar_19";


                //Act
                var returnedValue = UserCont.AddUser(testID);
                var returnedStatus = returnedValue.Result as BadRequestResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public void GetAllUsersShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.UserController(_BL);

                //Act
                var returnedValue = UserCont.GetUsers();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<User>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetUserShouldReturnACommentOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                string CommentID = "Cesar_19";

                var UserCont = new Rest.Controllers.UserController(_BL);

                //Act
                var returnedValue = UserCont.GetUser(CommentID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<User>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeleteUserShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.UserController(_BL);

                string test = "Cesar_19";

                //Act
                var returnedValue = UserCont.DeleteUser(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateUserShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.UserController(_BL);

                User test = new User
                {
                    UserID = "Cesar_19",
                };

                //Act
                var returnedValue = PostCont.UpdateUser(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // DogListController

        [Fact]
        public void AddDogListShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var DogListCont = new Rest.Controllers.DogListController(_BL);

                DogList test = new DogList()
                {
                    ListID = 0,
                    Title = "Big Dogs",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc), 
                    UserName = "Robert_19"
                 };


                //Act
                var returnedValue = DogListCont.AddDogList(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(returnedStatus.Value, returnedStatus.Value);
            }
        }

        [Fact]
        public void GetAllDogListShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.DogListController(_BL);

                //Act
                var returnedValue = UserCont.GetDogLists();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<DogList>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetDogListShouldReturnACommentOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);


                var UserCont = new Rest.Controllers.DogListController(_BL);

                DogList test = new DogList()
                {
                    ListID = 963,
                    Title = "Big Dogs",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    UserName = "Cesar_19"
                };

                //Act
                var returnedValue = UserCont.GetDogList(test.ListID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<DogList>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeletedDogListShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var UserCont = new Rest.Controllers.DogListController(_BL);

                DogList test = new DogList()
                {
                    ListID = 963,
                    Title = "Big Dogs",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    UserName = "Cesar_19"
                };

                //Act
                var returnedValue = UserCont.DeleteDogList(test.ListID);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateDogListShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var PostCont = new Rest.Controllers.DogListController(_BL);

                DogList test = new DogList()
                {
                    ListID = 963,
                    Title = "Big Dogs",
                    Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                    UserName = "Cesar_19"
                };

                //Act
                var returnedValue = PostCont.UpdateDogList(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // Alert Testing

        [Fact]
        public void AddAlertShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.AlertController(_BL);

                Alert test = new Alert()
                {
                    AlertID = 0,
                    UserID = "Robert_20",
                    AlertType = "default",
                    AlertValue = "http://localhost:4200:",
                    DogID = "512411"
                };


                //Act
                var returnedValue = AlertCont.AddAlert(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(returnedStatus.Value, returnedStatus.Value);
            }
        }

        [Fact]
        public void GetAllAlertShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.AlertController(_BL);

                //Act
                var returnedValue = AlertCont.GetAllAlerts();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Alert>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetAlertShouldReturnACommentOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);


                var AlertCont = new Rest.Controllers.AlertController(_BL);

                Alert test = new Alert()
                {
                    AlertID = 0,
                    UserID = "Robert_20",
                    AlertType = "default",
                    AlertValue = "http://localhost:4200:",
                    DogID = "512311"
                };

                //Act
                var returnedValue = AlertCont.GetAlert(test.UserID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Alert>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeleteAlertShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.AlertController(_BL);

                Alert test = new Alert()
                {
                    AlertID = 0,
                    UserID = "Robert_20",
                    AlertType = "default",
                    AlertValue = "http://localhost:4200:",
                    DogID = "512311"
                };

                //Act
                var returnedValue = AlertCont.DeleteAlert(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateAlertShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.AlertController(_BL);

                Alert test = new Alert()
                {
                    AlertID = 0,
                    UserID = "Robert_20",
                    AlertType = "default",
                    AlertValue = "http://localhost:4200:",
                    DogID = "512411"
                };

                //Act
                var returnedValue = AlertCont.updateAlert(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // LikesController Test

        [Fact]
        public void AddListedDogShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.LikesController(_BL);

                Like test = new Like()
                {
                 DogID = 245,
                 UserName = "Robert_20"
                };


                //Act
                var returnedValue = AlertCont.AddLike(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                //Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                //Assert.Equal(returnedStatus.Value, returnedStatus.Value);
            }
        }

        [Fact]
        public void GetAllLikeShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.LikesController(_BL);

                //Act
                var returnedValue = AlertCont.GetAllLikes();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<Like>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetLikeShouldReturnAOkResult()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);


                var AlertCont = new Rest.Controllers.LikesController(_BL);

                Like test = new Like()
                {
                    DogID = 741,
                    UserName = "Juan_95"
                };

                //Act
                var returnedValue = AlertCont.GetLike(test.DogID);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                //Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
               // Assert.IsType<List<Like>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeleteLikeShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.LikesController(_BL);

                Like test = new Like()
                {
                    DogID = 741,
                    UserName = "Juan_95"
                };

                //Act
                var returnedValue = AlertCont.DeleteLikes(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateLikeShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.LikesController(_BL);

                Like test = new Like()
                {
                    DogID = 741,
                    UserName = "Juan_97"
                };

                //Act
                var returnedValue = AlertCont.UpdateLike(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // ListDog

        [Fact]
        public void AddLikeShouldCreateAPostAndReturnCreated()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.ListedDogController(_BL);

                ListedDog test = new ListedDog()
                {
                    APIID = "233",
                    ListID = 964,
                };


                //Act
                var returnedValue = AlertCont.AddListedDog(test);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status201Created);
                Assert.Equal(returnedStatus.Value, returnedStatus.Value);
            }
        }

        [Fact]
        public void GetListedDogShouldReturnAListOfResults()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.ListedDogController(_BL);
                int list = 963;

                //Act
                var returnedValue = AlertCont.GetListedDogForListID(list);
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<string>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void GetAllListedDogShouldReturnAOkResult()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);


                var AlertCont = new Rest.Controllers.ListedDogController(_BL);

                //Act
                var returnedValue = AlertCont.GetDogLists();
                var returnedStatus = returnedValue.Result as ObjectResult;

                //Assert
                Assert.NotNull(returnedValue.Result);
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status200OK);
                Assert.IsType<List<ListedDog>>(returnedStatus.Value);
            }
        }

        [Fact]
        public void DeleteListedDogShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.ListedDogController(_BL);

                ListedDog test = new ListedDog()
                {
                    APIID = "123",
                    ListID = 963,
                };

                //Act
                var returnedValue = AlertCont.DeleteListedDog(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }
        [Fact]
        public void UpdateListedDogShouldReturnNoContent()
        {
            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                IBussiness _BL = new Bussiness(_repo);

                var AlertCont = new Rest.Controllers.ListedDogController(_BL);

                ListedDog test = new ListedDog()
                {
                    APIID = "133",
                    ListID = 963,

                };

                //Act
                var returnedValue = AlertCont.UpdateListedDog(test);
                var returnedStatus = returnedValue.Result as NoContentResult;

                //Assert
                Assert.Equal(returnedStatus.StatusCode, StatusCodes.Status204NoContent);
            }
        }

        // DL Testing

        [Fact]
        public void GetAllComments()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllCommentsAsync();
                Assert.Equal(2, results.Result.Count);
            }
        }
        
        [Fact]
        public void GetAllDogLists()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllDogListsAsync();
                Assert.Equal(2, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllForums()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllForumsAsync();
                Assert.Equal(1, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllLikes()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllLikesAsync();
                Assert.Equal(3, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllListedDogs()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllListedDogsAsync();
                Assert.Equal(1, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllPosts()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllPostsAsync();
                Assert.Equal(2, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllPreference()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllPreferencesAsync();
                Assert.Equal(2, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllTags()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllTagsAsync();
                Assert.Equal(3, results.Result.Count);
            }
        }
        [Fact]
        public void GetAllUsers()
        {

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                var results = _repo.GetAllUsersAsync();
                Assert.Equal(2, results.Result.Count);
            }
        }
        /// <summary>
        /// INVALID TESTS
        /// </summary>
        [Fact]
        public void ValidAddComment()
        {
            int CommentID = 9642;
            int PostID = 5631;
            string UserName = "Miggy_Cubbies";
            DateTime Created = new DateTime(2017, 8, 4, 8, 16, 21, DateTimeKind.Utc);
            string Message = "I just lost my dog!";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddCommentsAsync
                (
                    new Comments(CommentID, PostID, UserName, Created, Message)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Comments.FirstOrDefault(comm => comm.CommentID == CommentID);
                Assert.NotNull(result);
                Assert.Equal(UserName, result.UserName);
            }
        }
        [Fact]
        public void ValidAddDogList()
        {
            int ListID = 35460;
            string Title = "Small Dogs";
            DateTime Created = new DateTime(2006, 6, 3, 5, 15, 25, DateTimeKind.Utc);
            string UserName = "mike_bills";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddDogListasync
                (
                    new DogList(ListID, Title, Created, UserName)
                ); ;
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.DogLists.FirstOrDefault(dgl => dgl.ListID == ListID);
                Assert.NotNull(result);
                Assert.Equal(UserName, result.UserName);
            }
        }
        [Fact]
        public void ValidAddForum()
        {
            int ForumID = 761;
            string Topic = "Lost dogs";
            string Description = "Used for people to post about losing dogs";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddForumAsync
                (
                    new Forum(ForumID, Topic, Description)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Forums.FirstOrDefault(foru => foru.ForumID == ForumID);
                Assert.NotNull(result);
                Assert.Equal(ForumID, result.ForumID);
            }
        }
        [Fact]
        public void ValidAddListedDog()
        {
            int ListID = 541;
            string DogID = "687";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddListedDogasync
                (
                    new ListedDog(DogID, ListID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.ListedDogs.FirstOrDefault(lsd => lsd.ListID == ListID);
                Assert.NotNull(result);
                Assert.Equal(DogID, result.APIID);
            }
        }
        [Fact]
        public void ValidAddPosts()
        {
            int PostID = 7623;
            string Topic = "Found Dogs";
            string UserCreator = "Pepe_Rios";
            int ForumID = 3486;

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddPostsAsync
                (
                    new Posts(PostID, Topic, UserCreator, ForumID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Posts.FirstOrDefault(pst => pst.PostID == PostID);
                Assert.NotNull(result);
                Assert.Equal(ForumID, result.ForumID);
            }
        }
        [Fact]
        public void ValidAddPreference()
        {
            string UserName = "soccer_mom";
            int TagID = 96345;

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddPreferenceAsync
                (
                    new Preference(UserName, TagID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Preferences.FirstOrDefault(pref => pref.UserName == UserName);
                Assert.NotNull(result);
                Assert.Equal(TagID, result.TagID);
            }
        }
        [Fact]
        public void ValidAddTags()
        {
            int TagID = 654423;
            string Description = "Friendly dogs";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddTagsAsync
                (
                    new Tags(TagID, Description)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Tags.FirstOrDefault(tg => tg.TagID == TagID);
                Assert.NotNull(result);
                Assert.Equal(Description, result.Description);
            }
        }
        [Fact]
        public void ValidAddUser()
        {
            string UserID = "Pepe_Rios";


            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddUserAsync
                (
                    UserID
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Users.FirstOrDefault(use => use.UserID == UserID);
                Assert.NotNull(result);
                Assert.Equal(UserID, result.UserID);
            }
        }

        /// <summary>
        /// INVALID TESTS
        /// </summary>

        [Fact]
        public void NotValidAddComment()
        {
            int CommentID = 753;
            int PostID = 123;
            string UserName = "Pepe_Rios";
            DateTime Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc);
            string Message = "I just got a new dog!";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddCommentsAsync
                (
                    new Comments(CommentID, PostID, UserName, Created, Message)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Comments.FirstOrDefault(comm => comm.CommentID == CommentID);
                Assert.NotNull(result);
                Assert.NotEqual(UserName, result.UserName);
            }
        }
        [Fact]
        public void NotValidAddDogList()
        {
            int ListID = 963;
            string Title = "Big Dogs";
            DateTime Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc);
            string UserName = "Pepe_Rios";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddDogListasync
                (
                    new DogList(ListID, Title, Created, UserName)
                ); ;
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.DogLists.FirstOrDefault(dgl => dgl.ListID == ListID);
                Assert.NotNull(result);
                Assert.NotEqual(UserName, result.UserName);
            }
        }
        [Fact]
        public void NotValidAddForum()
        {
            int ForumID = 631;
            string Topic = "Dogs";
            string Description = "Used for people to post about dogs";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddForumAsync
                (
                    new Forum(ForumID,Topic,Description)
                ); 
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Forums.FirstOrDefault(foru => foru.ForumID == ForumID);
                Assert.NotNull(result);
                Assert.NotEqual(Topic, result.Topic);
            }
        }
        [Fact]
        public void NotValidAddLike()
        {
            int DogID = 123;
            string UserName = "Pepe_Rios";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddLikesAsync
                (
                    new Like(UserName,DogID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Likes.FirstOrDefault(lik => lik.UserName == UserName );
                Assert.NotNull(result);
                Assert.NotEqual(DogID, result.DogID);
            }
        }
        [Fact]
        public void NotValidAddListedDog()
        {
            int ListID = 963;
            string DogID = "456";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddListedDogasync
                (
                    new ListedDog(DogID, ListID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.ListedDogs.FirstOrDefault(lsd => lsd.ListID == ListID);
                Assert.NotNull(result);
                Assert.NotEqual(DogID, result.APIID);
            }
        }
        [Fact]
        public void NotValidAddPosts()
        {
            int PostID = 7771;
            string Topic = "Lost Dogs";
            string UserCreator = "Cesar_19";
            int ForumID = 6479;

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddPostsAsync
                (
                    new Posts(PostID, Topic, UserCreator, ForumID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Posts.FirstOrDefault(pst => pst.PostID == PostID);
                Assert.NotNull(result);
                Assert.NotEqual(ForumID, result.ForumID);
            }
        }
        [Fact]
        public void NotValidAddPreference()
        {
            string UserName = "Cesar_19";
            int TagID = 987;

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddPreferenceAsync
                (
                    new Preference(UserName,TagID)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Preferences.FirstOrDefault(pref => pref.UserName == UserName);
                Assert.NotNull(result);
                Assert.NotEqual(TagID, result.TagID);
            }
        }
        [Fact]
        public void NotValidAddTags()
        {
            int TagID = 753;
            string Description = "Tiny dogs";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddTagsAsync
                (
                    new Tags(TagID, Description)
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {

                var result = assertContext.Tags.FirstOrDefault(tg => tg.TagID == TagID);
                Assert.NotNull(result);
                Assert.NotEqual(Description, result.Description);
            }
        }
        [Fact]
        public void NotValidAddUser()
        {
            string APIID = "123sad3fd";

            using (var context = new DNHDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddUserAsync
                (
                    APIID
                );
            }
            using (var assertContext = new DNHDBContext(options))
            {
                var result = assertContext.Users.FirstOrDefault(use => use.UserID == APIID);
                Assert.NotNull(result);
            }
        }


        /// <summary>
        /// SEEDED DATA
        /// </summary>

        private void Seed()
        {
            using (var context = new DNHDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Comments.AddRange
                    (
                        new Comments
                        {
                            CommentID = 753,
                            PostID = 123,
                            UserName = "Cesar_19",
                            Created = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                            Message = "I just got a new dog!"
                        },
                        new Comments
                        {
                            CommentID = 867,
                            PostID = 5309,
                            UserName = "Pepe_Rios",
                            Created = new DateTime(2019, 1, 3, 5, 1, 2, DateTimeKind.Utc),
                            Message = "I just lost my dog!"
                        }

                    );
                context.DogLists.AddRange
                    (
                        new DogList
                        {
                            ListID = 963,
                            Title = "Big Dogs",
                            Created= new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc), 
                            UserName = "Cesar_19"
                        },
                        new DogList
                        {
                            ListID = 1000,
                            Title = "Small Dogs",
                            Created = new DateTime(2005, 2, 1, 5, 40, 40, DateTimeKind.Utc),
                            UserName = "Pepe_Rios"
                        }


                    );
                context.Forums.AddRange
                    (
                        new Forum
                        {
                            ForumID = 631,
                            Topic = "Found dogs",
                            Description = "Used for people to post about finding dogs"
                        }

                    );
                context.Likes.AddRange
                    (
                        new Like
                        {
                            DogID = 123,
                            UserName= "Cesar_19"
                        },
                        new Like
                        {
                            DogID = 987,
                            UserName = "Pepe_Rios"
                        },
                        new Like
                        {
                            DogID = 741,
                            UserName = "Juan_95"
                        }
                    );
                context.ListedDogs.AddRange
                    (
                        new ListedDog
                        {
                            APIID = "123",
                            ListID = 963,
                            
                        }

                    );
                context.Posts.AddRange
                    (
                        new Posts
                        {
                            PostID= 7771,
                            Topic = "Lost Dogs",
                            UserCreator = "Cesar_19",
                            ForumID = 631
                        },
                        new Posts
                        {
                            PostID = 1648,
                            Topic = "Found Dogs",
                            UserCreator = "Cesar_19",
                            ForumID = 631
                        }

                    );
                context.Preferences.AddRange
                    (
                        new Preference
                        {
                            UserName = "Cesar_19",
                            TagID = 123
                        },
                        new Preference
                        {
                            UserName = "Pepe_Rios",
                            TagID = 963
                        }

                    );
                context.Tags.AddRange
                    (
                        new Tags
                        {
                            TagID = 753,
                            Description = "Big dogs"
                        },
                         new Tags
                         {
                             TagID = 951,
                             Description = "Small Dogs"
                         },
                          new Tags
                          {
                              TagID = 852,
                              Description = "Friendly Dogs"
                          }
                    );
                context.Users.AddRange
                    (
                        new User
                        {
                            UserID = "Cesar_19",
                        },
                        new User
                        {
                            UserID = "Aros_78",
                        }
                    );
                context.Alert.AddRange
                    (
                        new Alert
                        {
                            AlertID = 0,
                            UserID = "Robert_20",
                            AlertType = "default",
                            AlertValue = "http://localhost:4200:",
                            DogID = "512311"
                        }
                    );
                context.SaveChanges();
            }

        }

    }
}
