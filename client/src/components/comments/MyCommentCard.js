import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  Typography,
} from '@mui/material';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { DeleteComment } from './DeleteComment.js';
import { EditComment } from './EditComment.js';
import { CommentLikes } from '../likes/commentLikes/CommentLike.js';
import { useNavigate } from 'react-router-dom';

export const MyCommentCard = ({
  comment,
  getCommentsForPost,
  loggedInUser,
  commentPage,
  getUserPosts
}) => {
      const navigate = useNavigate();

  return (
    <>
      <Card className="comment-card">
        <CardContent>
          <div className="comment-card-header">
            <div className="comment-card-header-left">
              <Avatar
                onClick={() => navigate(`/profile/me`)}
                className="single-profile-pic comment-avatar-clickable"
                src={comment.userProfile.profile.profilePicture}
                alt={comment.userProfile.name}
                sx={{ width: '30px', height: '30px' }}
              />
              <Typography
                onClick={() => navigate(`/profile/me`)}
                className="comment-name-clickable"
                style={{ fontWeight: 'bold' }}
              >
                {comment.userProfile.name}
              </Typography>
            </div>
            <Typography>{dateFormatter(comment.date)}</Typography>
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
              <DeleteComment
                commentId={comment.id}
                getCommentsForPost={getCommentsForPost}
                getUserPosts={getUserPosts}
              />
              <EditComment
                comment={comment}
                getCommentsForPost={getCommentsForPost}
              />
            </div>
          </div>
        </CardActions>
      </Card>
    </>
  );
};
