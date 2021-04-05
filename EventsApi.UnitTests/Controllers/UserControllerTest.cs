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

        public UserControllerTest()
        {
           _users = new List<User>{
                new User {
                    Id=1,
                    FirstName="Jim",
                    Surname="Bob",
                    Username="jimbob",
                    Hours=27,
                    PartOfGroupId=1,
                    AdminOfGroupId=1,
                    EventsIds= new int[]{1,2},
                },
                new User {
                    Id=2,
                    FirstName="Jom",
                    Surname="Bab",
                    Username="jombab",
                    Hours=25,
                    PartOfGroupId=2,
                    AdminOfGroupId=2,
                    EventsIds= new int[]{2},
                },
                new User {
                    Id=3,
                    FirstName="Jimmertson",
                    Surname="Bobert",
                    Username="jimmertsonbobert",
                    Hours=17,
                    PartOfGroupId=3,
                    AdminOfGroupId=3,
                    EventsIds= new int[]{3},
                },
            };

            var userRepository = Substitute.For<IRepository<User>>();
            userRepository.GetAll().Returns(x => _users);
            userRepository.Get(3).Returns(x => _users[2]);

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
        public async Task GetById_PassedInTwo_ReturnStatusCodeTwoHundred()
        {
            //act
            var result = await _controller.GetById(2);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

    }
}
