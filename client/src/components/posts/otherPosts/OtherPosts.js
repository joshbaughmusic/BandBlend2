import { useEffect, useState } from 'react';
import { fetchUserPosts } from '../../../managers/postsManager.js';
import '../Posts.css';
import { OtherPostsCard } from './OtherPostsCard.js';
import {
  Divider,
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Typography,
} from '@mui/material';
import { PostSkeleton } from '../PostSkeleton.js';

export const OtherPosts = ({ profile, loggedInUser }) => {
  const [posts, setPosts] = useState();
  const [postCount, setPostCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);

  const getUserPosts = () => {
    fetchUserPosts(profile.id, page, amountPerPage).then((res) => {
      setPosts(res.posts);
      setPostCount(res.totalCount);
    });
  };

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  useEffect(() => {
    getUserPosts();
  }, [page, amountPerPage]);

  if (!posts) {
    return (
      <>
        <div className="divider-header-container">
          <Typography variant="h6">Posts</Typography>
          <Divider />
        </div>

        {profile.profile.postCount === null ||
        profile.profile.postCount === 0 ? (
          <div>No Posts yet!</div>
        ) : (
          <div>
            {profile.profile.postCount > 5
              ? Array(5)
                  .fill(0)
                  .map((obj, index) => <PostSkeleton key={index} />)
              : Array(profile.profile.postCount)
                  .fill(0)
                  .map((obj, index) => <PostSkeleton key={index} />)}
          </div>
        )}
      </>
    );
  }

  if (posts.length === 0) {
    return (
      <>
        <div className="divider-header-container">
          <Typography variant="h6">Posts</Typography>
          <Divider />
        </div>
        <div>No Posts yet!</div>
      </>
    );
  }

  return (
    <>
      <div className="divider-header-container">
        <Typography variant="h6">Posts</Typography>
        <Divider />
      </div>

      <div>
        {posts.map((p, index) => (
          <OtherPostsCard
            profile={profile}
            post={p}
            key={`${p.id}-${index}`}
            page={page}
            loggedInUser={loggedInUser}
            getUserPosts={getUserPosts}
          />
        ))}
      </div>
      <div className="pagination-allprofiles-container">
        <Pagination
          count={Math.ceil(postCount / amountPerPage)}
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
    </>
  );
};
