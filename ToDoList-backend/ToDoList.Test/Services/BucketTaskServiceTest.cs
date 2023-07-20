using AutoMapper;
using Moq;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Api.BucketTasks.Services;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class BucketTaskServiceTest
{
    private Mock<IBucketTaskRepository> _bucketTaskRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private IBucketTaskService _bucketTaskService;

    [SetUp]
    public void Setup()
    {
        _bucketTaskRepositoryMock = new Mock<IBucketTaskRepository>();
        _mapperMock = new Mock<IMapper>();
        _bucketTaskService = new BucketTaskService(_bucketTaskRepositoryMock.Object, _mapperMock.Object);
    }


    [Test]
    public void GetBucketTask_ReturnBucketTask()
    {
        // Arrange
        var expectedBucketTask = new BucketTaskDto(1, "1:1 leader", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1);

        _mapperMock.Setup(m => m.Map<BucketTaskDto>(It.IsAny<BucketTask>()))
                   .Returns(expectedBucketTask);

        // Act
        var result = _bucketTaskService.GetBucketTask(1);

        // Assert
        Assert.That(expectedBucketTask, Is.EqualTo(result));
    }

    [Test]
    public void DeleteBucket_ReturnVoid()
    {
        Assert.DoesNotThrow(() => _bucketTaskService.DeleteBucketTask(1));
    }

    [Test]
    public void InsertBucket_ReturnBucketId()
    {
        // Arrange
        var expectedBucketTaskId = 1234;

        _mapperMock.Setup(m => m.Map<BucketTask>(It.IsAny<BucketUpsertTaskDto>()))
                   .Returns(new BucketTask());

        _bucketTaskRepositoryMock.Setup(repo => repo.InsertBucketTask(It.IsAny<BucketTask>()))
                               .Callback<BucketTask>(bucketTask =>
                               {
                                   bucketTask.Id = expectedBucketTaskId;
                               });

        // Act
        var result = _bucketTaskService.InsertBucketTask(new BucketUpsertTaskDto("Bucket task name to insert", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1));

        // Assert
        Assert.That(expectedBucketTaskId, Is.EqualTo(result));
    }

    [Test]
    public void UpdateBucket_ReturnVoid()
    {
        // Arrange
        var expectedBucket = new BucketUpsertTaskDto("Bucket task name to update", "Sample description", (int)Domain.Enums.BucketTaskState.ToDo, (int)Domain.Enums.BucketTaskPriority.Low, 1, 1);
        var expectedBucketId = 1;

        // Act
        Assert.DoesNotThrow(() => _bucketTaskService.UpdateBucketTask(expectedBucketId, expectedBucket));
    }
}
