import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  Collapse,
  IconButton,
  Typography,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import { DeletePost } from '../DeletePost.js';
import { EditPost } from '../EditPost.js';
import { dateFormatter } from '../../../utilities/dateFormatter.js';
import { CommentsSection } from '../../comments/CommentsSection.js';

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

export const MyPostsCard = ({ post, profile, getUserPosts, page }) => {
  const [expanded, setExpanded] = useState(false);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  useEffect(() => {
   setExpanded(false)
  }, [page])

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
            <div>
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
                <Typography>No Comments Yet</Typography>
              </div>
            ) : (
              <div className="post-card-footer-right">
                <ExpandMore
                  expand={expanded}
                  onClick={handleExpandClick}
                  aria-expanded={expanded}
                  aria-label="show more"
                  >
                  <ExpandMoreIcon />
                </ExpandMore>
                  <Typography>View Comments</Typography>
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
            />
          </CardContent>
        </Collapse>
      </Card>
    </>
  );
};
