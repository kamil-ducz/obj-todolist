using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using AutoMapper;
using ToDoList.Api.Dictionaries.Models;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;
using TaskPriority = ToDoList.Domain.Enums.TaskPriority;
using TaskState = ToDoList.Domain.Enums.TaskState;

namespace ToDoList.Api.Dictionaries.Services;

public interface IDictionaryService
{
    IReadOnlyCollection<BucketColorDto> GetBucketColors();
    IReadOnlyCollection<BucketCategory> GetBucketCategories();
    IReadOnlyCollection<TaskState> GetTaskStates();
    IReadOnlyCollection<TaskPriority> GetTaskPriorities();
}

public class DictionaryService : IDictionaryService
{
    private readonly IDictionaryRepository _dictionaryRepository;
    private readonly IMapper _mapper;

    public DictionaryService(IDictionaryRepository dictionaryRepository, IMapper mapper)
    {
        _dictionaryRepository = dictionaryRepository;
        _mapper = mapper;
    }
    
    public IReadOnlyCollection<BucketColorDto> GetBucketColors()
    {
        var bucketColors = _dictionaryRepository.GetAll<BucketColor>();
        return bucketColors.Select(_mapper.Map<BucketColorDto>).ToList();
    }

    public IReadOnlyCollection<BucketCategory> GetBucketCategories()
    {
        // TODO: Introduce some DTO, implement
        throw new System.NotImplementedException();
    }

    public IReadOnlyCollection<TaskState> GetTaskStates()
    {
        throw new System.NotImplementedException();
    }

    public IReadOnlyCollection<TaskPriority> GetTaskPriorities()
    {
        throw new System.NotImplementedException();
    }
}
