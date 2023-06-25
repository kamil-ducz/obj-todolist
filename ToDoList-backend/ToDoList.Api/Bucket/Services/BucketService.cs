using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Bucket.Models;
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

    public List<Domain.Models.Bucket> GetAllBuckets()
    {
        return _bucketRepository.GetAllBuckets();
    }

    public Domain.Models.Bucket GetBucket(int bucketId)
    {
        return _bucketRepository.GetBucket(bucketId);
    }

    public void DeleteBucket(int bucketId)
    {
        _bucketRepository.DeleteBucket(bucketId);
    }

    public int InsertBucket(BucketDTO bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);

        return _bucketRepository.InsertBucket(mappedBucket);
    }

    public void UpdateBucket(int id, BucketDTO bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);

        _bucketRepository.UpdateBucket(id, mappedBucket);
    }

    public IEnumerable<Domain.Models.BucketTask> GetAllBucketsTasks(int bucketId)
    {
        var bucketTasks = _bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketId == bucketId);
        return bucketTasks;
    }
}
