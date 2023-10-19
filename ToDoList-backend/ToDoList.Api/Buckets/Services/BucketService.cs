using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Buckets.Services;

public interface IBucketService
{
    IReadOnlyCollection<BucketDto> GetAllBuckets();
    PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int currentPage, int itemsPerPage);
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
    private readonly IMapper _mapper;

    public BucketService(IBucketRepository bucketRepository, IBucketTaskRepository bucketTaskRepository, IMapper mapper)
    {
        _bucketRepository = bucketRepository;
        _bucketTaskRepository = bucketTaskRepository;
        _mapper = mapper;
    }

    public IReadOnlyCollection<BucketDto> GetAllBuckets()
    {
        return _mapper.Map<List<BucketDto>>(_bucketRepository.GetAllBuckets());
    }

    // TODO add unit test for this method
    public PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int currentPage, int itemsPerPage)
    {
        PaginatedBucketsResult result = new PaginatedBucketsResult();

        var query = _bucketRepository.GetAllBuckets().AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            var normalizedSearchPhrase = searchPhrase.ToLower();
            query = query.Where(b => b.Name.ToLower().Contains(normalizedSearchPhrase));
            // If search phrase provided by client, return found results without pagination
            result.BucketsBatch = query.ToList();
            return result;
        }

        // Calculate total buckets (before applying pagination)
        result.TotalBuckets = query.Count();

        // Apply pagination
        result.BucketsBatch = query
            .OrderBy(b => b.Id) // You might want to order by a specific property
            .Skip((currentPage - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        // Calculate total pages
        result.TotalPages = (int)Math.Ceiling((double)result.TotalBuckets / itemsPerPage);

        result.CurrentPage = currentPage;

        return result;
    }

    public BucketDto GetBucket(int bucketId)
    {
        return _mapper.Map<BucketDto>(_bucketRepository.GetBucket(bucketId));
    }

    public void DeleteBucket(int bucketId)
    {
        var bucketToDelete = _bucketRepository.GetBucket(bucketId);

        _bucketRepository.DeleteBucket(bucketToDelete);
    }

    public int InsertBucket(BucketUpsertDto bucketDTO)
    {
        var mappedBucket = _mapper.Map<Domain.Models.Bucket>(bucketDTO);
        _bucketRepository.InsertBucket(mappedBucket);
        return mappedBucket.Id;
    }

    public void UpdateBucket(int bucketId, BucketUpsertDto bucketDTO)
    {
        var bucket = _bucketRepository.GetBucket(bucketId);
        _mapper.Map(bucketDTO, bucket);
        _bucketRepository.UpdateBucket(bucket);
    }

    public IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId)
    {
        var bucketTasks = _bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketId == bucketId).ToList();
        return _mapper.Map<List<BucketTaskDto>>(bucketTasks);
    }
}