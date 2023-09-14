using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Buckets.MappingProfiles;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.Buckets.Services;
using ToDoList.Api.BucketTasks.MappingProfiles;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class BucketServiceTest
{
    private Mock<IBucketRepository> _bucketRepositoryMock;
    private Mock<IBucketTaskRepository> _bucketTaskRepositoryMock;
    private IBucketService _bucketService;
    private IBucketService _bucketServiceForBucketTasks;
    private IMapper _mapper;
    private IMapper _mapperBucketTask;

    [SetUp]
    public void Setup()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new BucketMappingProfile());
        });
        var mapper = mapperConfig.CreateMapper();
        _mapper = mapper;

        var mapperBucketTaskConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new BucketTaskMappingProfile());
        });
        var mapperBucketTask = mapperBucketTaskConfig.CreateMapper();
        _mapperBucketTask = mapperBucketTask;

        _bucketRepositoryMock = new Mock<IBucketRepository>();
        _bucketTaskRepositoryMock = new Mock<IBucketTaskRepository>();
        _bucketService = new BucketService(_bucketRepositoryMock.Object, _bucketTaskRepositoryMock.Object, _mapper);
        _bucketServiceForBucketTasks = new BucketService(_bucketRepositoryMock.Object, _bucketTaskRepositoryMock.Object, _mapperBucketTask);
    }

    [Test]
    public void GetBuckets_ReturnBuckets()
    {
        // Arrange
        var expectedBuckets = new List<BucketDto>()
        {
            new BucketDto(1, "Objectivity", "Sample desc", (int)Domain.Enums.BucketCategory.Work, (int)Domain.Enums.BucketColor.Brown, 15, true),
            new BucketDto(2, "Kitchen", "Sample desc2", (int)Domain.Enums.BucketCategory.Home, (int)Domain.Enums.BucketColor.Red, 15, true),
            new BucketDto(3, "Gym", "Sample desc3", (int)Domain.Enums.BucketCategory.Hobby, (int)Domain.Enums.BucketColor.Red, 15, true)
        };

        _bucketRepositoryMock.Setup(repo => repo.GetAllBuckets())
            .Returns(expectedBuckets.Select(b => new Bucket()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                BucketCategoryId = b.BucketCategoryId,
                BucketColorId = b.BucketColorId,
                MaxAmountOfTasks = b.MaxAmountOfTasks,
                IsActive = b.IsActive
            }).ToList());

        // Act
        var result = _bucketService.GetAllBuckets();

        // Assert
        expectedBuckets.Should().BeEquivalentTo(result);
    }


    [Test]
    public void GetBucket_ReturnBucket()
    {
        // Arrange
        var expectedBucketDto = new BucketDto(3, "Gym", "Sample desc3", (int)Domain.Enums.BucketCategory.Hobby, (int)Domain.Enums.BucketColor.Red, 15, true);

        var expectedBucket = _mapper.Map<Bucket>(expectedBucketDto);

        _bucketRepositoryMock.Setup(repo => repo.GetBucket(3)).Returns(expectedBucket);

        // Act
        var result = _bucketService.GetBucket(3);

        // Assert
        expectedBucketDto.Should().BeEquivalentTo(result);
    }

    [Test]
    public void DeleteBucket_ReturnVoid()
    {
        Action action = () => _bucketService.DeleteBucket(4);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
    }

    [Test]
    public void InsertBucket_ReturnBucketId()
    {
        // Arrange
        var expectedBucketId = 1234;

        _bucketRepositoryMock.Setup(repo => repo.InsertBucket(It.IsAny<Bucket>()))
                               .Callback<Bucket>(bucket =>
                               {
                                   bucket.Id = expectedBucketId;
                               });

        // Act
        var result = _bucketService.InsertBucket(new BucketUpsertDto("Kitchen", "Sample desc2", (int)Domain.Enums.BucketCategory.Home, (int)Domain.Enums.BucketColor.Red, 15, true));

        // Assert
        expectedBucketId.Should().Be(result);
    }

    [Test]
    public void UpdateBucket_ReturnVoid()
    {
        // Arrange
        var expectedBucket = new BucketUpsertDto("Objectivity", "Sample desc", (int)Domain.Enums.BucketCategory.Work, (int)Domain.Enums.BucketColor.Brown, 15, true);
        var expectedBucketId = 1;

        // Act
        Action action = () => _bucketService.UpdateBucket(expectedBucketId, expectedBucket);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
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
        var result = _bucketServiceForBucketTasks.GetAllBucketsTasks(1);

        // Assert
        expectedBucketTasks.Should().BeEquivalentTo(result);
    }
}
