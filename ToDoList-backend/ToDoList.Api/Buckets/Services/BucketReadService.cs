using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Buckets.Models;
using ToDoList.Infrastructure;

namespace ToDoList.Api.Buckets.Services;

// Repositories shouldn't be used for reading data. We should do CQRS:
// use repositories for saving data,
// db context directly for retrieving data
public interface IBucketReadService
{
    IReadOnlyCollection<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
}

public class BucketReadService : IBucketReadService
{
    private readonly IMapper _mapper;
    private readonly ToDoListDbContext _context;

    public BucketReadService(IMapper mapper, ToDoListDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public IReadOnlyCollection<BucketDto> GetAllBuckets()
    {
        // We're using magic mappings from AutoMapper. If mapping is a little bit complicates,
        // we may want to do mappings by ourselves, e.g. by doing Buckets.Select(x => new BucketDto {... })
        return _context.Buckets
            .Include(x => x.BucketColor)
            .Include(x => x.BucketCategory)
            .Include(x => x.BucketTasks)
            .ProjectTo<BucketDto>(_mapper.ConfigurationProvider).ToList();
    }

    public BucketDto GetBucket(int bucketId)
    {
        return _context.Buckets.ProjectTo<BucketDto>(_mapper.ConfigurationProvider).Single(x => x.Id == bucketId);
    }
}