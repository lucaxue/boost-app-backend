using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace UsersApi.UnitTests
{
    public class UserControllerTest
    {

        //fields
        readonly UserController _controller;
        readonly List<User> _users;
        readonly User _userToUpdate;
        readonly User _userToPost;
        readonly User _userPosted;

        public UserControllerTest()
        {
            _users = new List<User>{
                new User {
                    Id=1,
                    FirstName="Jim",
                    Surname="Bob",
                    Username="jimbob",
                    PartOfGroupId=1,
                    AdminOfGroupId=1,
                    Hours=27,
                    EventsIds= new int[]{1,2},
                },
                new User {
                    Id=2,
                    FirstName="Jom",
                    Surname="Bab",
                    Username="jombab",
                    PartOfGroupId=3,
                    AdminOfGroupId=null,
                    Hours=25,
                    EventsIds= new int[]{2},
                },
                new User {
                    Id=3,
                    FirstName="Jimmertson",
                    Surname="Bobert",
                    Username="jimmertsonbobert",
                    PartOfGroupId=1,
                    AdminOfGroupId=null,
                    Hours=17,
                    EventsIds= new int[]{3},
                },
            };

            _userToUpdate = new User
            {
                Id = 3,
                FirstName = "Jimmerterson",
                Surname = "Bobbarfert",
                Username = "jimmertersonsonbobbartfert",
                PartOfGroupId = 1,
                AdminOfGroupId = null,
                Hours = 17,
                EventsIds = new int[] { 3 },
            };

            _userToPost = new User
            {
                FirstName = "Prince",
                Surname = "Philip",
                Username = "princephilip57",
                PartOfGroupId = 2,
                AdminOfGroupId = null,
                Hours = 900,
                EventsIds = new int[] { 1 },
            };

            _userPosted = new User
            {
                Id = 4,
                FirstName = "Prince",
                Surname = "Philip",
                Username = "princephilip57",
                PartOfGroupId = 2,
                AdminOfGroupId = null,
                Hours = 900,
                EventsIds = new int[] { 1 },
            };

            var userRepository = Substitute.For<IRepository<User>>();
            userRepository.GetAll().Returns(x => _users);
            userRepository.Search("jimmertsonbobert").Returns(x => new List<User>() { _users[2] });
            userRepository.Search("3").Returns(x => new List<User>() { _users[1] });
            userRepository.Get(3).Returns(x => _users[2]);
            userRepository.Update(_userToUpdate).Returns(x => _userToUpdate);
            userRepository.Insert(_userToPost).Returns(x => _userPosted);

            _controller = new UserController(userRepository);
        }


        [Fact]
        public async Task GetAll_NullAndNullPassedIn_ReturnStatusCode200()
        {
            //act
            var result = await _controller.GetAll(null, null);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_NullAndNullPassedIn_ReturnsAllUsers()
        {
            //act
            var result = await _controller.GetAll(null, null);
            var users = ((OkObjectResult)result).Value as List<User>;
            //assert
            users.Should().BeEquivalentTo(_users);
        }
        [Fact]
        public async Task GetAll_NullAndUsernamePassedIn_ReturnsStatusCode200()
        {
            //act
            var result = await _controller.GetAll(null, "jimmertsonbobert");
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAll_NullAndUsernamePassedIn_ReturnsCorrectUsers()
        {
            //act
            var result = await _controller.GetAll(null, "jimmertsonbobert");
            var users = ((OkObjectResult)result).Value as List<User>;
            //assert
            users.Should().BeEquivalentTo(new List<User>() { _users[2] });
        }

        [Fact]
        public async Task GetAll_GroupIdAndNullPassedIn_ReturnsStatusCode200()
        {
            //act
            var result = await _controller.GetAll("3", null);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_GroupIdAndNullPassedIn_ReturnsCorrectUsers()
        {
            //act
            var result = await _controller.GetAll("3", null);
            var users = ((OkObjectResult)result).Value as List<User>;
            //assert
            users.Should().BeEquivalentTo(new List<User>() { _users[1] });
        }

        [Fact]
        public void Delete_CalledWithId_ReturnStatusCode200()
        {
            //act
            var statusCode = ((OkObjectResult)_controller.Delete(2)).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetById_PassedInTwo_ReturnUserAtIdTwo()
        {
            //act
            var result = await _controller.GetById(3);
            var returnedUser = ((OkObjectResult)result).Value as User;
            //assert
            returnedUser.Should().BeEquivalentTo(_users[2]);
        }

        [Fact]
        public async Task GetById_PassedInTwo_ReturnStatusCode200()
        {
            //act
            var result = await _controller.GetById(2);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task Put_PassedInIdAndUpdatedUser_ReturnsStatusCode200()
        {
            //act
            var result = await _controller.Put(3, _userToUpdate);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task Put_PassedInIdAndUpdatedUser_ReturnsUpdatedUser()
        {
            //act
            var result = await _controller.Put(3, _userToUpdate);
            var updatedUser = ((OkObjectResult)result).Value as User;
            //assert
            updatedUser.Should().Be(_userToUpdate);
        }

        [Fact]
        public async Task Post_PassedInNewUser_ReturnsStatusCode201()
        {
            //act
            var result = await _controller.Post(_userToPost);
            var statusCode = ((ObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(201);
        }
        [Fact]
        public async Task Post_PassedInNewUser_ReturnsPostedUser()
        {
            //act
            var result = await _controller.Post(_userToPost);
            var postedUser = ((ObjectResult)result).Value as User;
            //assert
            postedUser.Should().Be(_userPosted);
        }
    }
}
