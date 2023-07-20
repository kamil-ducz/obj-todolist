using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.Buckets.Services;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class BucketServiceTest
{
    private Mock<IBucketRepository> _bucketRepositoryMock;
    private Mock<IBucketTaskRepository> _bucketTaskRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private IBucketService _bucketService;

    [SetUp]
    public void Setup()
    {
        _bucketRepositoryMock = new Mock<IBucketRepository>();
        _bucketTaskRepositoryMock = new Mock<IBucketTaskRepository>();
        _mapperMock = new Mock<IMapper>();
        _bucketService = new BucketService(_bucketRepositoryMock.Object, _bucketTaskRepositoryMock.Object, _mapperMock.Object);
    }

    [Test]
    public void GetBuckets_ReturnBuckets()
    {
        // Arrange<
        var expectedBuckets = new List<BucketDto>()
    {
        new BucketDto(1, "Objectivity", "Sample desc", (int)Domain.Enums.BucketCategory.Work, (int)Domain.Enums.BucketColor.Brown, 15, true),
        new BucketDto(2, "Kitchen", "Sample desc2", (int)Domain.Enums.BucketCategory.Home, (int)Domain.Enums.BucketColor.Red, 15, true),
        new BucketDto(3, "Gym", "Sample desc3", (int)Domain.Enums.BucketCategory.Hobby, (int)Domain.Enums.BucketColor.Red, 15, true)
    };

        _mapperMock.Setup(m => m.Map<List<BucketDto>>(It.IsAny<List<Bucket>>()))
                   .Returns(expectedBuckets.Select(a => new BucketDto(a.Id, a.Name, a.Description, a.BucketCategoryId, a.BucketColorId, a.MaxAmountOfTasks, a.IsActive)).ToList());

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
        CollectionAssert.AreEquivalent(expectedBuckets, result);
    }


    [Test]
    public void GetBucket_ReturnBucket()
    {
        // Arrange
        var expectedBucket = new BucketDto(3, "Gym", "Sample desc3", (int)Domain.Enums.BucketCategory.Hobby, (int)Domain.Enums.BucketColor.Red, 15, true);

        _mapperMock.Setup(m => m.Map<BucketDto>(It.IsAny<Bucket>()))
                   .Returns(expectedBucket);

        // Act
        var result = _bucketService.GetBucket(3);

        // Assert
        Assert.That(expectedBucket, Is.EqualTo(result));
    }

    [Test]
    public void DeleteBucket_ReturnVoid()
    {
        Assert.DoesNotThrow(() => _bucketService.DeleteBucket(4));
    }

    [Test]
    public void InsertBucket_ReturnBucketId()
    {
        // Arrange
        var expectedBucketId = 1234;

        _mapperMock.Setup(m => m.Map<Bucket>(It.IsAny<BucketUpsertDto>()))
                   .Returns(new Bucket());

        _bucketRepositoryMock.Setup(repo => repo.InsertBucket(It.IsAny<Bucket>()))
                               .Callback<Bucket>(bucket =>
                               {
                                   bucket.Id = expectedBucketId;
                               });

        // Act
        var result = _bucketService.InsertBucket(new BucketUpsertDto("Kitchen", "Sample desc2", (int)Domain.Enums.BucketCategory.Home, (int)Domain.Enums.BucketColor.Red, 15, true));

        // Assert
        Assert.That(expectedBucketId, Is.EqualTo(result));
    }

    [Test]
    public void UpdateBucket_ReturnVoid()
    {
        // Arrange
        var expectedBucket = new BucketUpsertDto("Objectivity", "Sample desc", (int)Domain.Enums.BucketCategory.Work, (int)Domain.Enums.BucketColor.Brown, 15, true);
        var expectedBucketId = 1;

        // Act
        Assert.DoesNotThrow(() => _bucketService.UpdateBucket(expectedBucketId, expectedBucket));
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

        _mapperMock.Setup(m => m.Map<List<BucketTaskDto>>(It.IsAny<List<BucketTask>>()))
            .Returns(expectedBucketTasks.Select(b => new BucketTaskDto
                (
                b.Id,
                b.Name,
                b.Description,
                b.BucketTaskStateId,
                b.BucketTaskPriorityId,
                b.BucketId,
                b.AssigneeId
                )).ToList());

        // Act 
        var result = _bucketService.GetAllBucketsTasks(1);

        // Assert
        Assert.That(expectedBucketTasks, Is.EqualTo(result));
    }
}
