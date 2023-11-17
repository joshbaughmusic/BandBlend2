import {
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
} from '@mui/material';
import { useState, useEffect } from 'react';
import { fetchCommentsForPost } from '../../managers/commentsManager.js';
import { MyCommentCard } from './MyCommentCard.js';
import './Comments.css';
import { CommentSkeleton } from './CommentSkeleton.js';
import { OtherCommentCard } from './OtherCommentCard.js';
import { NewComment } from './NewComment.js';

export const CommentsSection = ({ profile, post, newComment, setNewComment, loggedInUser }) => {
  const [comments, setComments] = useState(0);
  const [commentCount, setCommentCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);

  const getCommentsForPost = () => {
    fetchCommentsForPost(post.id, page, amountPerPage).then((res) => {
      setComments(res.comments);
      setCommentCount(res.totalCount);
    });
  };

  useEffect(() => {
    getCommentsForPost();
  }, [page, amountPerPage, profile]);

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  if (!comments) {
    return (
      <>
        <NewComment
          profile={profile}
          post={post}
          getCommentsForPost={getCommentsForPost}
          newComment={newComment}
          setNewComment={setNewComment}
          loggedInUser={loggedInUser}
        />

        {Array(post.commentCount)
          .fill(0)
          .map((obj, index) => (
            <CommentSkeleton key={index} />
          ))}
        <div className="pagination-allprofiles-container">
          <Pagination
            count={Math.ceil(commentCount / amountPerPage)}
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
  }

 
  return (
    <>
      <NewComment
        profile={profile}
        post={post}
        getCommentsForPost={getCommentsForPost}
        newComment={newComment}
        setNewComment={setNewComment}
        loggedInUser={loggedInUser}
      />
      <div>
        {comments.map((c, index) => {
          return c.userProfileId === loggedInUser.id ? (
            <MyCommentCard
              key={index}
              profile={profile}
              comment={c}
              getCommentsForPost={getCommentsForPost}
              loggedInUser={loggedInUser}
              commentPage={page}
            />
          ) : (
            <OtherCommentCard
              key={index}
              profile={profile}
              comment={c}
              loggedInUser={loggedInUser}
              commentPage={page}
            />
          );
        })}
      </div>
      <div className="pagination-allprofiles-container">
        <Pagination
          count={Math.ceil(commentCount / amountPerPage)}
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
