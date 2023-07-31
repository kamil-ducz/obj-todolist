using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Assignees.MappingProfiles;
using ToDoList.Api.Assignees.Models;
using ToDoList.Api.Assignees.Services;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class AssigneeServiceTest
{
    private Mock<IAssigneeRepository> _assigneeRepositoryMock;
    private IAssigneeService _assigneeService;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AssigneeMappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;

        _assigneeRepositoryMock = new Mock<IAssigneeRepository>();
        _assigneeService = new AssigneeService(_assigneeRepositoryMock.Object, _mapper);
    }

    [Test]
    public void GetAssignees_ReturnAssignees()
    {
        // Arrange
        List<AssigneeDto> expectedAssignees = new List<AssigneeDto>
        {
            new AssigneeDto (1, "John"),
            new AssigneeDto (2, "Alice")
        };

        _assigneeRepositoryMock.Setup(repo => repo.GetAllAssignees())
            .Returns(expectedAssignees.Select(a => new Assignee()
            {
                Id = a.Id,
                Name = a.Name
            }).ToList());


        // Act
        var result = _assigneeService.GetAllAssignees();

        // Assert
        result.Should().BeEquivalentTo(expectedAssignees);
    }

    [Test]
    public void GetAssignee_ReturnAssignee()
    {
        // Arrange
        var expectedAssignee = new Assignee { Id = 3, Name = "Pilirani Tendai" };

        _assigneeRepositoryMock.Setup(repo => repo.GetAssignee(3)).Returns(expectedAssignee);

        var expectedAssigneeDto = _mapper.Map<AssigneeDto>(expectedAssignee);

        // Act
        var result = _assigneeService.GetAssignee(3);

        // Assert
        expectedAssignee.Should().BeEquivalentTo(expectedAssigneeDto);
    }

    [Test]
    public void DeleteAssignee_ReturnVoid()
    {
        Action action = () => _assigneeService.DeleteAssignee(4);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
    }

    [Test]
    public void InsertAssignee_ReturnAssigneeId()
    {
        //Arrange
        var expectedAssigneeId = 1234;

        _assigneeRepositoryMock.Setup(repo => repo.InsertAssignee(It.IsAny<Assignee>()))
                               .Callback<Assignee>(assignee =>
                               {
                                   assignee.Id = expectedAssigneeId;
                               });

        // Act
        var result = _assigneeService.InsertAssignee(new AssigneeUpsertDto("Example assignee to insert"));

        // Assert
        Assert.That(expectedAssigneeId, Is.EqualTo(result));
        expectedAssigneeId.Should().Be(result);
    }

    [Test]
    public void UpdateAssignee_ReturnVoid()
    {
        // Arrange
        var expectedAssignee = new AssigneeUpsertDto("Pilirani Tendai");
        var expectedAssigneeId = 3;

        // Act
        Action action = () => _assigneeService.UpdateAssignee(expectedAssignee, expectedAssigneeId);
        action.Invoking(a => a.Invoke()).Should().NotThrow();
    }
}
