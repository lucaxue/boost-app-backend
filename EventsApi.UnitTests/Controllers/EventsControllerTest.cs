using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace EventsApi.UnitTests
{
    public class EventsControllerTest
    {

        //fields
        readonly EventController _controller;
        readonly List<Event> _events;

        public EventsControllerTest()
        {
            _events = new List<Event>{
                new Event {
                    Id=1,
                    Name="running",
                    Description="running in park",
                    ExerciseType="running",
                    Longitude=52.4862F,
                    Latitude=1.8904F,
                    Time=new DateTime(2021, 8, 18, 16, 32, 0),
                    Intensity="Hard",
                    GroupId=1,
                },
                new Event {
                    Id=2,
                    Name="swimming",
                    Description="swimming in the pool",
                    ExerciseType="swimming",
                    Longitude=52.4862F,
                    Latitude=1.8904F,
                    Time=new DateTime(2021, 8, 18, 16, 32, 0),
                    Intensity="intermediate",
                    GroupId=2,
                },
                new Event {
                    Id=3,
                    Name="cycling",
                    Description="cycling in park",
                    ExerciseType="cycling",
                    Longitude=52.4862F,
                    Latitude=1.8904F,
                    Time=new DateTime(2021, 8, 18, 16, 32, 0),
                    Intensity="easy",
                    GroupId=3,
                },
            };

            var eventRepository = Substitute.For<IRepository<Event>>();
            eventRepository.GetAll().Returns(x => _events);

            _controller = new EventController(eventRepository);
        }


        [Fact]
        public async Task Get_NullPassedIn_ReturnStatusCode200()
        {
            //act
            var result = await _controller.Get(null);
            var statusCode = ((OkObjectResult)result).StatusCode;
            //assert
            statusCode.Should().Be(200);
        }

    }
}