import { useEffect, useState } from 'react';
import {
  fetchCreateNewPost,
  fetchUserPosts,
} from '../../../managers/postsManager.js';
import { MyPostsCard } from './MyPostsCard.js';
import '../Posts.css';
import {
  Button,
  Collapse,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Divider,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Skeleton,
  TextField,
  Tooltip,
  Typography,
} from '@mui/material';
import PostAddIcon from '@mui/icons-material/PostAdd';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../context/SnackBarContext.js';
import { PostSkeleton } from '../PostSkeleton.js';

export const MyPosts = ({ profile }) => {
  const [posts, setPosts] = useState();
  const [postCount, setPostCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);
  const [expanded, setExpanded] = useState(false);
  const [newPost, setNewPost] = useState('');
  const [openAlert, setOpenAlert] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [blankPostError, setBlankPostError] = useState(false);

  const getUserPosts = () => {
    fetchUserPosts(profile.id, page, amountPerPage).then((res) => {
      setPosts(res.posts);
      setPostCount(res.totalCount);
    });
  };

  useEffect(() => {
    getUserPosts();
  }, [page, amountPerPage]);

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  const handleOpenNewPost = () => {
    setExpanded(true);
  };

  const handleCloseNewPost = () => {
    if (newPost) {
      setOpenAlert(true);
    } else {
      setExpanded(false);
      setBlankPostError(false);
    }
  };

  const handleAlert = () => {
    setOpenAlert(!openAlert);
  };

  const handleConfirmCloseNewPost = () => {
    setExpanded(false);
    setBlankPostError(false);
    handleAlert();
    setNewPost('');
  };

  const handleCreatePost = () => {
    setBlankPostError(false);
    if (newPost.length > 0) {
      fetchCreateNewPost(newPost).then((res) => {
        console.log(res);
        if (res.id != undefined) {
          setSuccessAlert(true);
          setSnackBarMessage('Post created successfully!');
          getUserPosts();
          setExpanded(false);
          setNewPost('');
          handleSnackBarOpen();
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to create post.');
          handleSnackBarOpen();
        }
      });
    } else {
      setBlankPostError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Post cannot be empty.');
      handleSnackBarOpen();
    }
  };

  if (!posts) {
    return (
      <>
        <div className="divider-header-container">
          <div className="profile-section-header">
            <Typography variant="h6">Posts</Typography>
            {expanded ? (
              <IconButton onClick={handleCloseNewPost}>
                <CloseIcon />
              </IconButton>
            ) : (
              <Tooltip
                title="New Post"
                placement="left-start"
              >
                <IconButton onClick={handleOpenNewPost}>
                  <PostAddIcon />
                </IconButton>
              </Tooltip>
            )}
          </div>
          <Divider />
        </div>
        <div>
          {profile.profile.postCount === null ||
          profile.profile.postCount === 0 ? (
            <div>No posts yet!</div>
          ) : (
            <div>
              {Array(profile.profile.postCount)
                .fill(0)
                .map((obj, index) => (
                  <PostSkeleton key={index} />
                ))}
            </div>
          )}
        </div>
      </>
    );
  }

  if (posts.length === 0) {
    return (
      <>
        <Dialog
          open={openAlert}
          onClose={handleAlert}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">
            {'Confirm Post Discard'}
          </DialogTitle>
          <DialogContent>
            <DialogContentText id="alert-dialog-description">
              Are you sure you want to discard this post?
            </DialogContentText>
          </DialogContent>
          <DialogActions>
            <Button onClick={handleAlert}>Cancel</Button>
            <Button
              onClick={handleConfirmCloseNewPost}
              autoFocus
            >
              Confirm
            </Button>
          </DialogActions>
        </Dialog>
        <div className="profile-section-header">
          <Typography variant="h6">No Posts Yet</Typography>
          {expanded ? (
            <IconButton onClick={handleCloseNewPost}>
              <CloseIcon />
            </IconButton>
          ) : (
            <Tooltip
              title="New Post"
              placement="left-start"
            >
              <IconButton onClick={handleOpenNewPost}>
                <PostAddIcon />
              </IconButton>
            </Tooltip>
          )}
        </div>
        <div>
          <Collapse
            in={expanded}
            timeout="auto"
            unmountOnExit
          >
            <TextField
              className="post-text-field"
              label="What's on your mind?"
              multiline
              minRows={5}
              fullWidth
              value={newPost}
              onChange={(e) => setNewPost(e.target.value)}
              error={blankPostError}
            />
            <div className="post-submit-button-container">
              <Button
                variant="contained"
                onClick={handleCreatePost}
              >
                Submit
              </Button>
            </div>
          </Collapse>
        </div>
      </>
    );
  }

  return (
    <>
      <Dialog
        open={openAlert}
        onClose={handleAlert}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {'Confirm Post Discard'}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to discard this post?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            onClick={handleConfirmCloseNewPost}
            autoFocus
          >
            Discard Post
          </Button>
          <Button onClick={handleAlert}>Cancel</Button>
        </DialogActions>
      </Dialog>
      <div className="divider-header-container">
        <div className="profile-section-header">
          <Typography variant="h6">Posts</Typography>
          {expanded ? (
            <IconButton onClick={handleCloseNewPost}>
              <CloseIcon />
            </IconButton>
          ) : (
            <Tooltip
              title="New Post"
              placement="left-start"
            >
              <IconButton onClick={handleOpenNewPost}>
                <PostAddIcon />
              </IconButton>
            </Tooltip>
          )}
        </div>
        <Divider />
      </div>

      <div>
        <Collapse
          in={expanded}
          timeout="auto"
          unmountOnExit
        >
          <TextField
            className="post-text-field"
            label="What's on your mind?"
            multiline
            minRows={5}
            fullWidth
            value={newPost}
            onChange={(e) => setNewPost(e.target.value)}
            error={blankPostError}
          />
          <div className="post-submit-button-container">
            <Button
              variant="contained"
              onClick={handleCreatePost}
            >
              Submit
            </Button>
          </div>
        </Collapse>
      </div>

      <div>
        {posts.map((p, index) => (
          <MyPostsCard
            getUserPosts={getUserPosts}
            profile={profile}
            post={p}
            key={index}
            page={page}
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
