import {
  Avatar,
  Box,
  Card,
  CardActions,
  CardContent,
  IconButton,
  List,
  Popper,
  Tooltip,
  Typography,
} from '@mui/material';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { CommentLikes } from '../likes/commentLikes/CommentLike.js';
import { useNavigate } from 'react-router-dom';
import { AdminDeleteComment } from '../adminViews/adminComments/AdminDeleteComment.js';
import { useState } from 'react';

export const OtherCommentCard = ({
  comment,
  loggedInUser,
  commentPage,
  getCommentsForPost,
  getUserPosts,
}) => {
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = useState(null);

  const open = Boolean(anchorEl);
  const popperId = open ? 'simple-popper' : undefined;

  const handlePopperClick = (event) => {
    setAnchorEl(anchorEl ? null : event.currentTarget);
  };

  return (
    <>
      <Card className="comment-card">
        <CardContent>
          {loggedInUser.roles.includes('Admin') ? (
            <div className="comment-card-header-mine">
              <div className="comment-card-header-left">
                <Avatar
                  className="single-profile-pic comment-avatar-clickable"
                  onClick={() =>
                    navigate(`/profile/${comment.userProfile.profile.id}`)
                  }
                  src={comment.userProfile.profile.profilePicture}
                  alt={comment.userProfile.name}
                  sx={{ width: '30px', height: '30px' }}
                />
                <div>
                  <Typography
                    style={{ fontWeight: 'bold' }}
                    className="comment-name-clickable"
                    onClick={() =>
                      navigate(`/profile/${comment.userProfile.profile.id}`)
                    }
                  >
                    {comment.userProfile.name}
                  </Typography>
                  <Typography variant="caption">
                    {dateFormatter(comment.date)}
                  </Typography>
                </div>
              </div>
              <div>
                <Tooltip
                  title="Options"
                  placement="left"
                >
                  <IconButton
                    aria-describedby={popperId}
                    onClick={handlePopperClick}
                  >
                    <MoreVertIcon />
                  </IconButton>
                </Tooltip>
                <Popper
                  id={popperId}
                  open={open}
                  anchorEl={anchorEl}
                >
                  <Box sx={{ border: 1, bgcolor: 'background.paper' }}>
                    <List disablePadding>
                      <AdminDeleteComment
                        commentId={comment.id}
                        getCommentsForPost={getCommentsForPost}
                        getUserPosts={getUserPosts}
                      />
                    </List>
                  </Box>
                </Popper>
              </div>
            </div>
          ) : (
            <div className="comment-card-header">
              <Avatar
                className="single-profile-pic comment-avatar-clickable"
                onClick={() =>
                  navigate(`/profile/${comment.userProfile.profile.id}`)
                }
                src={comment.userProfile.profile.profilePicture}
                alt={comment.userProfile.name}
                sx={{ width: '30px', height: '30px' }}
              />
              <div>
                <Typography
                  style={{ fontWeight: 'bold' }}
                  className="comment-name-clickable"
                  onClick={() =>
                    navigate(`/profile/${comment.userProfile.profile.id}`)
                  }
                >
                  {comment.userProfile.name}
                </Typography>
                <Typography variant="caption">
                  {dateFormatter(comment.date)}
                </Typography>
              </div>
            </div>
          )}
          <div>
            <Typography>{comment.body}</Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="comment-card-footer">
            <div className="comment-card-footer-left">
              <div>
                <CommentLikes
                  comment={comment}
                  loggedInUser={loggedInUser}
                  commentPage={commentPage}
                />
              </div>
            </div>
          </div>
        </CardActions>
      </Card>
    </>
  );
};
