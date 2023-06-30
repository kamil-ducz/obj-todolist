// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  localhostUrl: 'https://localhost:7247/api/',
  
  bucketEndpoint: 'https://localhost:7247/api/Bucket/',

  bucketTaskEndpoint: 'https://localhost:7247/api/BucketTask/',
  buckeTasksForBucketEndpoint: 'https://localhost:7247/api/Bucket/buckettask/',

  bucketColorEndpoint: 'https://localhost:7247/api/BucketColor/',
  bucketCategoryEndpoint: 'https://localhost:7247/api/BucketCategory/',
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
