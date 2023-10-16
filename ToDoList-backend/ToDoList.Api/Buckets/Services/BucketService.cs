using AutoMapper;
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
    PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int? currentPage, int? itemsPerPage);
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

    public PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int? currentPage, int? itemsPerPage)
    {
        PaginatedBucketsResult result = new PaginatedBucketsResult();

        if (searchPhrase is null && itemsPerPage is null && itemsPerPage is null)
        {
            // get all buckets and set default pagination params
            result.BucketsBatch = _mapper.Map<IReadOnlyCollection<Bucket>>(_bucketRepository.GetAllBuckets());
            result.TotalBuckets = result.BucketsBatch.Count;
            result.TotalPages = 1; // Since there's only one page for all buckets
            result.StartPage = 1;
            result.EndPage = 1;
            result.CurrentPage = 1;

            return result;
        }
        //var normalizedSearchPhrase = searchPhrase?.ToLower();
        //var buckets = _toDoListDbContext.Buckets.Where(b => b.Name.Contains(normalizedSearchPhrase!));
        //return buckets.ToList();

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