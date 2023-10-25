import { Bucket } from "./bucket.model";

export type PaginatedBucketResult = {
    id: number;
    totalBuckets: number;
    totalPages: number;
    currentPage: number;    
    bucketsBatch: Bucket[];
}