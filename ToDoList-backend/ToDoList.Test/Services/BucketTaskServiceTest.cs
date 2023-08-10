using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.BucketTasks.MappingProfiles;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Api.BucketTasks.Services;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class BucketTaskServiceTest
{
    private Mock<IBucketTaskRepository> _bucketTaskRepositoryMock;
    private IBucketTaskService _bucketTaskService;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new BucketTaskMappingProfile());
        });
        var mapper = mapperConfig.CreateMapper();
        _mapper = mapper;

        _bucketTaskRepositoryMock = new Mock<IBucketTaskRepository>();
        _bucketTaskService = new BucketTaskService(_bucketTaskRepositoryMock.Object, _mapper);
    }

    [Test]
    public void GetBucketTasks_ReturnBucketTasks()
    {
        // Arrange
        var expectedBucketTasks = new List<BucketTaskDto>()
        {
            new BucketTaskDto(1, "1:1 leader", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1),
            new BucketTaskDto(4, "Clean bedroom", "Sample description4", (int)Domain.Enums.BucketTaskState.InProgress, (int)Domain.Enums.BucketTaskPriority.High, 1, 4),
        };

        _bucketTaskRepositoryMock.Setup(repo => repo.GetAllBucketTasks())
            .Returns(() => expectedBucketTasks.Select(b => new BucketTask
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                BucketTaskStateId = b.BucketTaskStateId,
                BucketTaskPriorityId = b.BucketTaskPriorityId,
                BucketId = b.BucketId,
                AssigneeId = b.AssigneeId
            }).ToList());

        // Act 
        var result = _bucketTaskService.GetBucketTasks();

        // Assert
        expectedBucketTasks.Should().BeEquivalentTo(result);
    }

    [Test]
    public void GetBucketTask_ReturnBucketTask()
    {
        // Arrange
        var expectedBucketTaskDto = new BucketTaskDto(1, "1:1 leader", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1);

        var expectedBucketTask = _mapper.Map<BucketTask>(expectedBucketTaskDto);
        _bucketTaskRepositoryMock.Setup(repo => repo.GetBucketTask(1)).Returns(expectedBucketTask);

        // Act
        var result = _bucketTaskService.GetBucketTask(1);

        // Assert
        expectedBucketTask.Should().BeEquivalentTo(result);
    }

    [Test]
    public void DeleteBucket_ReturnVoid()
    {
        Action action = () => _bucketTaskService.DeleteBucketTask(1);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
    }

    [Test]
    public void InsertBucket_ReturnBucketId()
    {
        // Arrange
        var expectedBucketTaskId = 1234;

        _bucketTaskRepositoryMock.Setup(repo => repo.InsertBucketTask(It.IsAny<BucketTask>()))
                               .Callback<BucketTask>(bucketTask =>
                               {
                                   bucketTask.Id = expectedBucketTaskId;
                               });

        // Act
        var result = _bucketTaskService.InsertBucketTask(new BucketUpsertTaskDto("Bucket task name to insert", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1));

        // Assert
        expectedBucketTaskId.Should().Be(result);
    }

    [Test]
    public void UpdateBucket_ReturnVoid()
    {
        // Arrange
        var expectedBucket = new BucketUpsertTaskDto("Bucket task name to update", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1);
        var expectedBucketId = 1;

        // Act
        Action action = () => _bucketTaskService.UpdateBucketTask(expectedBucketId, expectedBucket);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
    }
}
