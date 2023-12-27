import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  Typography,
} from '@mui/material';

import { dateFormatter } from '../../utilities/dateFormatter.js';
import { CommentLikes } from '../likes/commentLikes/CommentLike.js';
import { useNavigate } from 'react-router-dom';
import { AdminDeleteComment } from '../adminViews/adminComments/AdminDeleteComment.js';

export const OtherCommentCard = ({
  comment,
  loggedInUser,
  commentPage,
  getCommentsForPost,
  getUserPosts,
}) => {
  const navigate = useNavigate();
  return (
    <>
      <Card className="comment-card">
        <CardContent>
          <div className="comment-card-header">
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
              <Typography
                style={{ fontWeight: 'bold' }}
                className="comment-name-clickable"
                onClick={() =>
                  navigate(`/profile/${comment.userProfile.profile.id}`)
                }
              >
                {comment.userProfile.name}
              </Typography>
            </div>
            <Typography>{dateFormatter(comment.date)}</Typography>
          </div>
          <div>
            <Typography>{comment.body}</Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="comment-card-footer">
            {loggedInUser.roles.includes('Admin') ? (
              <div className="comment-card-footer-left">
                <div>
                  <CommentLikes
                    comment={comment}
                    loggedInUser={loggedInUser}
                    commentPage={commentPage}
                  />
                </div>
                <AdminDeleteComment
                  commentId={comment.id}
                  getCommentsForPost={getCommentsForPost}
                  getUserPosts={getUserPosts}
                />
              </div>
            ) : (
              <div>
                <div>
                  <CommentLikes
                    comment={comment}
                    loggedInUser={loggedInUser}
                    commentPage={commentPage}
                  />
                </div>
              </div>
            )}
          </div>
        </CardActions>
      </Card>
    </>
  );
};
