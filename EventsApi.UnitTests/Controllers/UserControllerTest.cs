using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace EventsApi.UnitTests
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
                    Id=1,
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

    }
}
