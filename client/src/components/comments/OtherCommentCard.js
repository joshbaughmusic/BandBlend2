import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  IconButton,
  Typography,
} from '@mui/material';
import ThumbUpAltIcon from '@mui/icons-material/ThumbUpAlt';
import ThumbUpOffAltIcon from '@mui/icons-material/ThumbUpOffAlt';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { CommentLikes } from '../likes/commentLikes/CommentLike.js';
import { useNavigate } from 'react-router-dom';

export const OtherCommentCard = ({ comment, loggedInUser, commentPage }) => {
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
            <div>
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
