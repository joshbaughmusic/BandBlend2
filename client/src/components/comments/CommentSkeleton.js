import { Card, CardContent, Skeleton } from '@mui/material';

export const CommentSkeleton = () => {
  return (
    <>
      <Card className="comment-card-skeleton comment-card">
        <CardContent>
          <div className="comment-card-header">
            <div className="comment-card-header-left-skeleton">
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
              height={100}
            />
          </div>
        </CardContent>
      </Card>
    </>
  );
};
