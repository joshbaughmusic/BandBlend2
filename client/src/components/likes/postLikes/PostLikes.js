import { useEffect, useState } from 'react';
import {
  fetchDeletePostLike,
  fetchLikesForPost,
  fetchNewPostLike,
} from '../../../managers/postLikesManager.js';
import {
  Avatar,
  Chip,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  Popover,
  Skeleton,
  Typography,
} from '@mui/material';
import ThumbUpAltIcon from '@mui/icons-material/ThumbUpAlt';
import ThumbUpOffAltIcon from '@mui/icons-material/ThumbUpOffAlt';
import '../Likes.css';

export const PostLikes = ({ post, loggedInUser, postPage }) => {
  const [likes, setLikes] = useState();
  const [anchorEl, setAnchorEl] = useState(null);

  const getLikesForPost = () => {
    fetchLikesForPost(post.id).then(setLikes);
  };

  const handlePopoverOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handlePopoverClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);

  useEffect(() => {
    getLikesForPost();
  }, [postPage, post.id]);

  const handleNewLike = () => {
    fetchNewPostLike(post.id).then(() => {
      getLikesForPost();
    });
  };

  const handleDeleteLike = () => {
    fetchDeletePostLike(post.id).then(() => {
      getLikesForPost();
    });
  };

  if (!likes) {
    return (
      <>
        <div className="like-container">
          <Skeleton
            variant="text"
            width="75px"
            height={40}
          />
        </div>
      </>
    );
  }

  return (
    <>
      {post.userProfileId == loggedInUser.id ? (
        <div className="like-container-mine">
          <Typography>Likes</Typography>
          <Chip
            onMouseEnter={handlePopoverOpen}
            onMouseLeave={handlePopoverClose}
            label={likes.length}
          />
        </div>
      ) : (
        <div className="like-container">
          {likes.some((l) => l.userProfileId === loggedInUser.id) ? (
            <IconButton onClick={() => handleDeleteLike()}>
              <ThumbUpAltIcon />
            </IconButton>
          ) : (
            <IconButton onClick={() => handleNewLike()}>
              <ThumbUpOffAltIcon />
            </IconButton>
          )}
          <Chip
            onMouseEnter={handlePopoverOpen}
            onMouseLeave={handlePopoverClose}
            label={likes.length}
          />
        </div>
      )}
      {likes.length > 0 ? (
        <Popover
          id="mouse-over-popover"
          sx={{
            pointerEvents: 'none',
          }}
          open={open}
          anchorEl={anchorEl}
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'center',
          }}
          transformOrigin={{
            vertical: 'top',
            horizontal: 'center',
          }}
          onClose={handlePopoverClose}
          disableRestoreFocus
        >
          <>
            <List>
              {likes.map((l, index) => {
                return (
                  <ListItem key={index}>
                    <ListItemAvatar>
                      <Avatar
                        src={l.userProfile.profile.profilePicture}
                        alt=""
                        sx={{ width: '30px', height: '30px' }}
                      />
                    </ListItemAvatar>
                    <Typography>{l.userProfile.name}</Typography>
                  </ListItem>
                );
              })}
            </List>
          </>
        </Popover>
      ) : (
        <></>
      )}
    </>
  );
};
