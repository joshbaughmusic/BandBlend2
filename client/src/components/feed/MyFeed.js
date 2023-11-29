import { useEffect, useState } from 'react';
import {
  Divider,
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Typography,
  Container,
  Paper,
} from '@mui/material';
import { OtherPostsCard } from '../posts/otherPosts/OtherPostsCard.js';
import { PostSkeleton } from '../posts/PostSkeleton.js';
import { fetchUserFeed } from '../../managers/feedManager.js';
import { FeedPostCard } from './FeedPostCard.js';

export const MyFeed = ({ loggedInUser }) => {
  const [feedPosts, setFeedPosts] = useState();
  const [feedPostCount, setFeedPostCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);

  const getUserFeed = () => {
    fetchUserFeed(page, amountPerPage).then((res) => {
      setFeedPosts(res.posts);
      setFeedPostCount(res.totalCount);
    });
  };

  useEffect(() => {
    getUserFeed();
  }, [page, amountPerPage]);

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  if (!feedPosts) {
    return (
      <>
        <Container>
          <Paper
            elevation={4}
            className="profile-right-section-item feed-container"
          >
            <Typography
              sx={{ m: 1, textAlign: 'center' }}
              variant="h4"
            >
              Recent Activity:
            </Typography>
            <Divider sx={{ mb: 3 }} />
            <div>
              {Array(5)
                .fill(0)
                .map((obj, index) => (
                  <PostSkeleton key={index} />
                ))}
            </div>
          </Paper>
        </Container>
      </>
    );
  }

  return (
    <>
      <Container>
        <Paper
          elevation={4}
          className="profile-right-section-item feed-container"
        >
          <Typography
            sx={{ m: 1, textAlign: 'center' }}
            variant="h4"
          >
            Recent Activity:
          </Typography>
          <Divider sx={{ mb: 3 }} />
          <div>
            {feedPosts.map((p, index) => (
              <FeedPostCard
                profile={p.userProfile}
                post={p}
                key={`${p.id}-${index}`}
                page={page}
                loggedInUser={loggedInUser}
              />
            ))}
          </div>
          <div className="pagination-allprofiles-container">
            <Pagination
              count={Math.ceil(feedPostCount / amountPerPage)}
              page={page}
              onChange={handlePageChange}
            />
            <FormControl
              sx={{ m: 1, minWidth: 75 }}
              size="small"
            >
              <InputLabel id="amountPerPage-select-label">Per Page</InputLabel>
              <Select
                labelId="amountPerPage-select-label"
                id="amountPerPage-select"
                value={amountPerPage}
                label="Age"
                onChange={handleAmountPerPageChange}
              >
                <MenuItem value={5}>5</MenuItem>
                <MenuItem value={10}>10</MenuItem>
                <MenuItem value={20}>20</MenuItem>
              </Select>
            </FormControl>
          </div>
        </Paper>
      </Container>
    </>
  );
};
