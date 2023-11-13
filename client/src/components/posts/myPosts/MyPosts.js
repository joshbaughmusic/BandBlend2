import { useEffect, useState } from 'react';
import {
  featchCreateNewPost,
  fetchUserPosts,
} from '../../../managers/postsManager.js';
import { MyPostsCard } from './MyPostsCard.js';
import '../Posts.css';
import {
  Alert,
  Button,
  Collapse,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Snackbar,
  TextField,
  Typography,
} from '@mui/material';
import PostAddIcon from '@mui/icons-material/PostAdd';
import CloseIcon from '@mui/icons-material/Close';

export const MyPosts = ({ profile }) => {
  const [posts, setPosts] = useState();
  const [postCount, setPostCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);
  const [expanded, setExpanded] = useState(false);
  const [newPost, setNewPost] = useState('');
  const [openAlert, setOpenAlert] = useState(false);
  const [successAlert, setSuccessAlert] = useState(false);
  const [failAlert, setFailAlert] = useState(false);
  const [snackBarOpen, setSnackBarOpen] = useState(false);

  const getUserPosts = () => {
    fetchUserPosts(profile.id, page, amountPerPage).then((res) => {
      setPosts(res.posts);
      setPostCount(res.totalCount);
    });
  };

  useEffect(() => {
    getUserPosts();
  }, [page, amountPerPage]);

  const handleSnackBarOpen = () => {
    setSnackBarOpen(true);
  };

  const handleSnackBarClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }

    setSnackBarOpen(false);
  };

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
    }
  };

  const handleAlert = () => {
    setOpenAlert(!openAlert);
  };

  const handleConfirmCloseNewPost = () => {
    setExpanded(false);
    handleAlert();
    setNewPost('');
  };

  const handleCreatePost = () => {
    featchCreateNewPost(newPost).then((res) => {
      console.log(res);
      if (res.id != undefined) {
        setSuccessAlert(true);
        getUserPosts();
        setExpanded(false);
        setNewPost('');
        handleSnackBarOpen();
      } else {
        setSuccessAlert(false);
        handleSnackBarOpen();
      }
    });
  };

  if (!posts) {
    return null;
  }

  if (posts.length === 0) {
    return (
      <>
        <div>No Posts yet!</div>
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
          <Button onClick={handleAlert}>Cancel</Button>
          <Button
            onClick={handleConfirmCloseNewPost}
            autoFocus
          >
            Confirm
          </Button>
        </DialogActions>
      </Dialog>
      <div className="myposts-header">
        <Typography variant="h6">Posts</Typography>
        {expanded ? (
          <IconButton onClick={handleCloseNewPost}>
            <CloseIcon />
          </IconButton>
        ) : (
          <IconButton onClick={handleOpenNewPost}>
            <PostAddIcon />
          </IconButton>
        )}
      </div>
      {successAlert ? (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={6000}
          onClose={handleSnackBarClose}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="success"
            sx={{ width: '100%' }}
          >
            Post created successfully!
          </Alert>
        </Snackbar>
      ) : (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={6000}
          onClose={handleSnackBarClose}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="error"
            sx={{ width: '100%' }}
          >
            Failed to create post.
          </Alert>
        </Snackbar>
      )}
      
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
            profile={profile}
            post={p}
            key={index}
          />
        ))}
      </div>
      {/* {postCount <= 5 ? ( */}
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
      {/* ) : (
        ''
      )} */}
    </>
  );
};
