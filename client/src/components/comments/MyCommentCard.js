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
import { DeleteComment } from './DeleteComment.js';
import { EditComment } from './EditComment.js';
import { CommentLikes } from '../likes/commentLikes/CommentLike.js';
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';

export const MyCommentCard = ({
  comment,
  getCommentsForPost,
  loggedInUser,
  commentPage,
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
          <div className="comment-card-header-mine">
            <div className="comment-card-header-left">
              <Avatar
                onClick={() => navigate(`/profile/me`)}
                className="single-profile-pic comment-avatar-clickable"
                src={comment.userProfile.profile.profilePicture}
                alt={comment.userProfile.name}
                sx={{ width: '30px', height: '30px' }}
              />
              <div>
                <Typography
                  onClick={() => navigate(`/profile/me`)}
                  className="comment-name-clickable"
                  style={{ fontWeight: 'bold' }}
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
                    <>
                      <EditComment
                        comment={comment}
                        getCommentsForPost={getCommentsForPost}
                      />
                      <DeleteComment
                        commentId={comment.id}
                        getCommentsForPost={getCommentsForPost}
                        getUserPosts={getUserPosts}
                      />
                    </>
                  </List>
                </Box>
              </Popper>
            </div>
          </div>
          <div>
            <Typography className="comment-name-clickable">
              {comment.body}
            </Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="comment-card-footer">
            <div className="comment-card-footer-left">
              <CommentLikes
                comment={comment}
                loggedInUser={loggedInUser}
                commentPage={commentPage}
              />
            </div>
          </div>
        </CardActions>
      </Card>
    </>
  );
};
