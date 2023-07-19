using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Assignees.Models;
using ToDoList.Api.Assignees.Services;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class AssigneeServiceTest
{
    private Mock<IAssigneeRepository> _assigneeRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private IAssigneeService _assigneeService;

    [SetUp]
    public void Setup()
    {
        _assigneeRepositoryMock = new Mock<IAssigneeRepository>();
        _mapperMock = new Mock<IMapper>();
        _assigneeService = new AssigneeService(_assigneeRepositoryMock.Object, _mapperMock.Object);
    }

    [Test]
    public void GetAssignees_ReturnAssignees()
    {
        // Arrange
        var expectedAssignees = new List<AssigneeDto>()
        {
            new AssigneeDto(1, "John Doe"),
            new AssigneeDto(2, "Otobong Shay")
        };

        _mapperMock.Setup(m => m.Map<List<AssigneeDto>>(It.IsAny<List<Assignee>>()))
                   .Returns(expectedAssignees.Select(a => new AssigneeDto(a.Id, a.Name)).ToList());

        // Act
        var result = _assigneeService.GetAllAssignees();

        // Assert
        Assert.That(expectedAssignees, Is.EqualTo(result));
    }

    [Test]
    public void GetAssignee_ReturnAssignee()
    {
        // Arrange
        var expectedAssignee = new AssigneeDto(3, "Pilirani Tendai");

        _mapperMock.Setup(m => m.Map<AssigneeDto>(It.IsAny<Assignee>()))
                   .Returns(expectedAssignee);

        // Act
        var result = _assigneeService.GetAssignee(3);

        // Assert
        Assert.That(expectedAssignee, Is.EqualTo(result));
    }

    [Test]
    public void DeleteAssignee_ReturnVoid()
    {
        Assert.DoesNotThrow(() => _assigneeService.DeleteAssignee(4));
    }

    [Test]
    public void InsertAssignee_ReturnAssigneeId()
    {
        // Arrange
        var expectedAssigneeId = 1234;

        _mapperMock.Setup(m => m.Map<Assignee>(It.IsAny<AssigneeUpsertDto>()))
                   .Returns(new Assignee());

        _assigneeRepositoryMock.Setup(repo => repo.InsertAssignee(It.IsAny<Assignee>()))
                               .Callback<Assignee>(assignee =>
                               {
                                   assignee.Id = expectedAssigneeId;
                               });

        // Act
        var result = _assigneeService.InsertAssignee(new AssigneeUpsertDto("Example assignee to insert"));

        // Assert
        Assert.That(expectedAssigneeId, Is.EqualTo(result));
    }


}
