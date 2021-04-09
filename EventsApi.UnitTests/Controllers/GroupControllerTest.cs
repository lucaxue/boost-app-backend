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
        readonly Group _groupToUpdate;
        readonly Group _groupToPost;
        readonly Group _groupPosted;

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

            _groupToUpdate = new Group 
            {
                Id=3,
                Name="Beat the Bulge!",
            };

            _groupToPost = new Group
            {
                Name="The Fishermen"
            };

            _groupPosted = new Group
            {
                Id=4,
                Name="The Fishermen"
            };

            var groupRepository = Substitute.For<IRepository<Group>>();
            groupRepository.GetAll().Returns(x => _groups);
            groupRepository.Get(2).Returns(x => _groups[1]);
            groupRepository.Update(_groupToUpdate).Returns(x => _groupToUpdate);
            groupRepository.Insert(_groupToPost).Returns(x => _groupPosted);

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
        public async Task GetById_PassedInTwo_ReturnGroupsAtIdTwo()
        {
            //act
            var result = await _controller.GetById(2);
            var returnedGroup = ((OkObjectResult)result).Value as Group;
            //assert
            returnedGroup.Should().BeEquivalentTo(_groups[1]);
        }

        [Fact]
        public async Task Put_PassedInIdAndUpdatedGroup_ReturnsStatusCode200()
        {
            //act
            var result = await _controller.Put(3, _groupToUpdate);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

        
        [Fact]
        public async Task Put_PassedInIdAndUpdatedGroup_ReturnsUpdatedGroup()
        {
            //act
            var result = await _controller.Put(3, _groupToUpdate);
            var updatedGroup = ((OkObjectResult)result).Value as Group;
            //assert
            updatedGroup.Should().Be(_groupToUpdate);
        }

        [Fact]
        public async Task Post_PassedInNewGroup_ReturnsStatusCode201()
        {
            //act
            var result = await _controller.Post(_groupToPost);
            var statusCode = ((ObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(201);
        }
        [Fact]
        public async Task Post_PassedInNewGroup_ReturnsPostedGroup()
        {
            //act
            var result = await _controller.Post(_groupToPost);
            var postedGroup = ((ObjectResult)result).Value as Group;
            //assert
            postedGroup.Should().Be(_groupPosted);
        }
      



    }
}