using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace GroupsApi.UnitTests
{
    public class GroupsControllerTest
    {

        //fields
        readonly GroupController _controller;
        readonly List<Group> _groups;

        public GroupsControllerTest()
        {
            _groups = new List<Group>{
                new Group {
                    Id=1,
                    Name="Weekend Warriors",
                },
                new Group {
                    Id=2,
                    Name="Young Mums",
                },
                new Group {
                    Id=3,
                    Name="Beat the Bulge",
                },
            };

            var groupRepository = Substitute.For<IRepository<Group>>();
            groupRepository.GetAll().Returns(x => _groups);

            _controller = new GroupController(groupRepository);
        }


        [Fact]
        public async Task GetAll_NullPassedIn_ReturnStatusCode200()
        {
            //act
            var result = await _controller.GetAll(null);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_NullPassedIn_ReturnsAllGroups()
        {
            //act
            var result = await _controller.GetAll(null);
            var groups = ((OkObjectResult)result).Value as List<Group>;
            //assert
            groups.Should().BeEquivalentTo(_groups);
        }

        [Fact]
        public void Delete_CalledWithId_ReturnStatusCode200()
        {
            //act
            var statusCode = ((OkObjectResult)_controller.Delete(2)).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }


    }
}