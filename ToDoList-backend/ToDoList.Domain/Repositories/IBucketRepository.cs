﻿using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketRepository
{
    IReadOnlyList<Bucket> GetAllBuckets();
    Bucket GetBucket(int bucketId);
    void InsertBucket(Bucket bucket);
    void DeleteBucket(Bucket bucket);
    void UpdateBucket(Bucket bucket);
}
