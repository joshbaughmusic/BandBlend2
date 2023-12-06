import {
  Avatar,
  Button,
  Card,
  CardActions,
  CardContent,
  Chip,
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
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import CommentIcon from '@mui/icons-material/Comment';
import { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import { DeletePost } from '../DeletePost.js';
import { EditPost } from '../EditPost.js';
import { dateFormatter } from '../../../utilities/dateFormatter.js';
import { CommentsSection } from '../../comments/CommentsSection.js';
import { PostLikes } from '../../likes/postLikes/PostLikes.js';

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

export const MyPostsCard = ({
  post,
  profile,
  getUserPosts,
  page,
  loggedInUser,
}) => {
  const [expanded, setExpanded] = useState(false);
  //defining newComment state here so when expanded is clicked, warning can be given if there is a comment in progress
  const [newComment, setNewComment] = useState('');
  const [confirmOpen, setConfirmOpen] = useState(false);

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

  useEffect(() => {
    setExpanded(false);
  }, [page]);

  return (
    <>
      <Card className="post-card">
        <CardContent>
          <div className="post-card-header">
            <div className="post-card-header-left">
              <Avatar
                className="single-profile-pic"
                src={profile.profile.profilePicture}
                alt={profile.name}
              />
              <Typography>{profile.name}</Typography>
            </div>
            <Typography>{dateFormatter(post.date)}</Typography>
          </div>
          <div>
            <Typography>{post.body}</Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="post-card-footer">
            <div className="post-card-footer-left">
              <PostLikes
                post={post}
                loggedInUser={loggedInUser}
                postPage={page}
              />
              <DeletePost
                postId={post.id}
                getUserPosts={getUserPosts}
              />
              <EditPost
                post={post}
                getUserPosts={getUserPosts}
              />
            </div>
            {post.commentCount === 0 || post.commentCount === null ? (
              <div className="post-card-footer-right">
                <Typography>Be the first to comment</Typography>
                <IconButton>
                  {expanded ? (
                    <ExpandLessIcon onClick={handleExpandClick} />
                  ) : (
                    <Tooltip
                      title="Comment"
                      placement="top"
                    >
                      <CommentIcon onClick={handleExpandClick} />
                    </Tooltip>
                  )}
                </IconButton>
              </div>
            ) : (
              <div className="post-card-footer-right">
                {expanded ? (
                  <Typography>Hide Comments</Typography>
                ) : (
                  <>
                    {/* <Chip className='commentCount-chip' label={post.commentCount} /> */}
                    <Typography>View Comments</Typography>
                  </>
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
        <Collapse
          in={expanded}
          timeout="auto"
          unmountOnExit
        >
          <CardContent>
            <CommentsSection
              profile={profile}
              post={post}
              newComment={newComment}
              setNewComment={setNewComment}
              loggedInUser={loggedInUser}
              getUserPosts={getUserPosts}
            />
          </CardContent>
        </Collapse>
      </Card>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{'Discard Changes?'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to discard your changes?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => handleConfirmClose()}>Discard Changes</Button>
          <Button onClick={() => setConfirmOpen(false)}>Cancel</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
