import { Card, CardContent, Skeleton } from '@mui/material';

export const FeedPostSkeleton = () => {
  return (
    <>
      <Card className="feed-post-card-skeleton post-card">
        <CardContent>
          <div className="post-card-header">
            <div className="post-card-header-left-skeleton">
              <Skeleton
                variant="circular"
                width={40}
                height={40}
              />
              <Skeleton
                variant="text"
                sx={{ fontSize: '1rem' }}
                width="15%"
              />
            </div>
            <Skeleton
              variant="text"
              sx={{ fontSize: '1rem' }}
              width="15%"
            />
          </div>
          <div>
            <Skeleton
              variant="rounded"
              width="100%"
              height={70}
            />
          </div>
        </CardContent>
      </Card>
    </>
  );
};
