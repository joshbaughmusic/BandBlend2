import {
  Avatar,
  Box,
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
  List,
  Popper,
  Tooltip,
  Typography,
  useMediaQuery,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import CommentIcon from '@mui/icons-material/Comment';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import { DeletePost } from '../DeletePost.js';
import { EditPost } from '../EditPost.js';
import { dateFormatter } from '../../../utilities/dateFormatter.js';
import { CommentsSection } from '../../comments/CommentsSection.js';
import { PostLikes } from '../../likes/postLikes/PostLikes.js';
import { useTheme } from '@emotion/react';

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
  const [anchorEl, setAnchorEl] = useState(null);

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

  const open = Boolean(anchorEl);
  const popperId = open ? 'simple-popper' : undefined;

  const handlePopperClick = (event) => {
    setAnchorEl(anchorEl ? null : event.currentTarget);
  };
    const theme = useTheme();
    const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  return (
    <>
      <Card className="post-card">
        <CardContent>
          <div className="post-card-header-mine">
            <div className="post-card-header-left">
              <Avatar
                className="single-profile-pic"
                src={profile.profile.profilePicture}
                alt={profile.name}
              />
              <div>
                <Typography style={{ fontWeight: 'bold' }}>
                  {profile.name}
                </Typography>
                <Typography variant="caption">
                  {dateFormatter(post.date)}
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
                      <EditPost
                        post={post}
                        getUserPosts={getUserPosts}
                      />

                      <DeletePost
                        postId={post.id}
                        getUserPosts={getUserPosts}
                      />
                    </>
                  </List>
                </Box>
              </Popper>
            </div>
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
            </div>
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
                    <IconButton onClick={handleExpandClick}>
                      <ExpandLessIcon />
                    </IconButton>
                  </>
                ) : (
                  <>
                    {mediaQuerySmall ? (
                      <Typography
                        variant="subtitle2"
                        style={{ marginRight: '4px', marginTop: '4px' }}
                      >
                        Comment
                      </Typography>
                    ) : (
                      <Typography
                        variant="subtitle2"
                        style={{ marginRight: '4px', marginTop: '4px' }}
                      >
                        Be the first to comment
                      </Typography>
                    )}
                    <IconButton onClick={handleExpandClick}>
                      <Tooltip
                        title="Comment"
                        placement="top"
                      >
                        <CommentIcon />
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
            post={post}
            newComment={newComment}
            setNewComment={setNewComment}
            loggedInUser={loggedInUser}
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
