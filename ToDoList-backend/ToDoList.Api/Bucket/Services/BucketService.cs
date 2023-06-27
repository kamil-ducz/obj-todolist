using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Bucket.Services;

public class BucketService : IBucketService
{
    private readonly IBucketRepository _bucketRepository;
    private readonly IBucketTaskRepository _bucketTaskRepository;
    private readonly IMapper _mapper;

    public BucketService(IBucketRepository bucketRepository, IBucketTaskRepository bucketTaskRepository, IMapper mapper)
    {
        _bucketRepository = bucketRepository;
        _bucketTaskRepository = bucketTaskRepository;
        _mapper = mapper;
    }

    public IReadOnlyCollection<BucketDto> GetAllBuckets()
    {
        return _mapper.Map<IReadOnlyCollection<BucketDto>>(_bucketRepository.GetAllBuckets());
    }

    public BucketDto GetBucket(int bucketId)
    {
        return _mapper.Map<BucketDto>(_bucketRepository.GetBucket(bucketId));
    }

    public void DeleteBucket(int bucketId)
    {
        var bucketToDelete = _bucketRepository.GetAllBuckets().First(b => b.Id == bucketId);

        _bucketRepository.DeleteBucket(bucketToDelete);
    }

    public int InsertBucket(BucketInsertDto bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);
        _bucketRepository.InsertBucket(mappedBucket);

        return mappedBucket.Id;
    }

    public void UpdateBucket(int id, BucketInsertDto bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);
        mappedBucket.Id = id;

        _bucketRepository.UpdateBucket(mappedBucket);
    }

    public IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId)
    {
        var bucketTasks = _bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketId == bucketId);

        return _mapper.Map<IReadOnlyCollection<BucketTaskDto>>(bucketTasks);
    }
}