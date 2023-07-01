using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Buckets.Services;

public interface IBucketService
{
    IReadOnlyCollection<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
    IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId);
    int InsertBucket(BucketUpsertDto bucket);
    void UpdateBucket(int id, BucketUpsertDto bucket);
    void DeleteBucket(int bucketId);
}

public class BucketService : IBucketService
{
    private readonly IBucketRepository _bucketRepository;
    private readonly IBucketTaskRepository _bucketTaskRepository;
    private readonly IMapper _mapper;

    public BucketService(
        IBucketRepository bucketRepository,
        IBucketTaskRepository bucketTaskRepository,
        IMapper mapper)
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

    public int InsertBucket(BucketUpsertDto bucketDto)
    {
        var bucket = _mapper.Map<Bucket>(bucketDto);
        _bucketRepository.InsertBucket(bucket);
        return bucket.Id;
    }

    public void UpdateBucket(int id, BucketUpsertDto bucketDto)
    {
        var bucket = _bucketRepository.GetBucket(id);
        _mapper.Map(bucketDto, bucket);
        bucket.Id = id;
        _bucketRepository.UpdateBucket(bucket);
    }
    
    public void DeleteBucket(int bucketId)
    {
        var bucket = _bucketRepository.GetBucket(bucketId);
        _bucketRepository.DeleteBucket(bucket);
    }

    public IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId)
    {
        var bucketTasks = _bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketsId == bucketId);
        return _mapper.Map<IReadOnlyCollection<BucketTaskDto>>(bucketTasks);
    }
}