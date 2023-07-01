﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Buckets.Services;

public interface IBucketService
{
    IReadOnlyCollection<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
    IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId);
    int InsertBucket(BucketUpsertDto bucket);
    void DeleteBucket(int bucketId);
    void UpdateBucket(int id, BucketUpsertDto bucket);
}

public class BucketService : IBucketService
{
    private readonly IBucketRepository _bucketRepository;
    private readonly IBucketTaskRepository _bucketTaskRepository;
    private readonly IBucketColorRepository _bucketColorRepository;
    private readonly IBucketCategoryRepository _bucketCategoryRepository;
    private readonly IMapper _mapper;

    public BucketService(IBucketRepository bucketRepository, IBucketTaskRepository bucketTaskRepository,
                         IBucketColorRepository bucketColorRepository, IBucketCategoryRepository bucketCategoryRepository, IMapper mapper)
    {
        _bucketRepository = bucketRepository;
        _bucketTaskRepository = bucketTaskRepository;
        _bucketColorRepository = bucketColorRepository;
        _bucketCategoryRepository = bucketCategoryRepository;
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

    public int InsertBucket(BucketUpsertDto bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);
        _bucketRepository.InsertBucket(mappedBucket);

        return mappedBucket.Id;
    }

    public void UpdateBucket(int id, BucketUpsertDto bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);
        mappedBucket.Id = id;

        _bucketRepository.UpdateBucket(mappedBucket);
    }

    public IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId)
    {
        var bucketTasks = _bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketsId == bucketId);

        return _mapper.Map<IReadOnlyCollection<BucketTaskDto>>(bucketTasks);
    }
}