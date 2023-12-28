import {
  Avatar,
  Button,
  Card,
  CardActions,
  CardContent,
  Collapse,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  IconButton,
  Tooltip,
  Typography,
} from '@mui/material';
import CommentIcon from '@mui/icons-material/Comment';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import { dateFormatter } from '../../../utilities/dateFormatter.js';
import { CommentsSection } from '../../comments/CommentsSection.js';
import { PostLikes } from '../../likes/postLikes/PostLikes.js';
import { AdminDeletePost } from '../../adminViews/adminPosts/AdminDeletePost.js';

const ExpandMore = styled((props) => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
  marginLeft: 'auto',
  transition: theme.transitions.create('transform', {
    duration: theme.transitions.duration.shortest,
  }),
}));

export const OtherPostsCard = ({
  post,
  profile,
  page,
  loggedInUser,
  getUserPosts,
}) => {
  const [expanded, setExpanded] = useState(false);
  //defining newComment state here so when expanded is clicked, warning can be given if there is a comment in progress
  const [newComment, setNewComment] = useState('');
  const [confirmOpen, setConfirmOpen] = useState(false);

  useEffect(() => {
    setExpanded(false);
  }, [page]);

  const handleExpandClick = () => {
    if (newComment.length > 0) {
      setConfirmOpen(true);
    } else {
      setExpanded(!expanded);
    }
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setExpanded(false);
    setNewComment('');
  };

  return (
    <>
      <Card className="post-card">
        <CardContent>
          <div className="post-card-header">
            <Avatar
              className="single-profile-pic"
              src={profile.profile.profilePicture}
              alt={profile.name}
            />
            <div>
              <Typography style={{ fontWeight: 'bold' }}>
                {profile.name}
              </Typography>
              <Typography variant="body2">
                {dateFormatter(post.date)}
              </Typography>
            </div>
          </div>
          <div>
            <Typography>{post.body}</Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="post-card-footer">
            {loggedInUser.roles.includes('Admin') ? (
              <div className="post-card-footer-left">
                <PostLikes
                  post={post}
                  loggedInUser={loggedInUser}
                  postPage={page}
                />
                <AdminDeletePost
                  postId={post.id}
                  getUserPosts={getUserPosts}
                />
              </div>
            ) : (
              <div>
                <PostLikes
                  post={post}
                  loggedInUser={loggedInUser}
                  postPage={page}
                />
              </div>
            )}

            {post.commentCount === 0 || post.commentCount === null ? (
              <div className="post-card-footer-right">
                {expanded ? (
                  <>
                    <Typography
                      variant="subtitle2"
                      style={{ marginRight: '4px', marginTop: '4px' }}
                    >
                      Hide
                    </Typography>
                    <IconButton>
                      <ExpandLessIcon onClick={handleExpandClick} />
                    </IconButton>
                  </>
                ) : (
                  <>
                    <Typography
                      variant="subtitle2"
                      style={{ marginRight: '4px', marginTop: '4px' }}
                    >
                      Comment
                    </Typography>
                    <IconButton>
                      <Tooltip
                        title="Comment"
                        placement="top"
                      >
                        <CommentIcon onClick={handleExpandClick} />
                      </Tooltip>
                    </IconButton>
                  </>
                )}
              </div>
            ) : (
              <div className="post-card-footer-right">
                {expanded ? (
                  <Typography
                    variant="subtitle2"
                    style={{ marginRight: '4px', marginTop: '4px' }}
                  >
                    Hide
                  </Typography>
                ) : (
                  <Typography
                    variant="subtitle2"
                    style={{ marginRight: '4px', marginTop: '4px' }}
                  >
                    Comments
                  </Typography>
                )}
                <ExpandMore
                  expand={expanded}
                  onClick={handleExpandClick}
                  aria-expanded={expanded}
                  aria-label="show more"
                >
                  <ExpandMoreIcon />
                </ExpandMore>
              </div>
            )}
          </div>
        </CardActions>
      </Card>
      <Collapse
        in={expanded}
        timeout="auto"
        unmountOnExit
      >
        <CardContent>
          <CommentsSection
            profile={profile}
            loggedInUser={loggedInUser}
            post={post}
            newComment={newComment}
            setNewComment={setNewComment}
            getUserPosts={getUserPosts}
          />
        </CardContent>
      </Collapse>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
        sx={{ marginBottom: '10vh' }}
      >
        <DialogTitle id="alert-dialog-title">{'Discard Changes?'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to discard your changes?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            variant="contained"
            color="error"
            onClick={() => handleConfirmClose()}
          >
            Discard
          </Button>
          <Button
            variant="contained"
            onClick={() => setConfirmOpen(false)}
          >
            Cancel
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
