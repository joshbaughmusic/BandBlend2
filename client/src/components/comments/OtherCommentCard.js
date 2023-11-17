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

export const OtherCommentCard = ({ comment, loggedInUser, commentPage }) => {
  return (
    <>
      <Card className="comment-card">
        <CardContent>
          <div className="comment-card-header">
            <div className="comment-card-header-left">
              <Avatar
                className="single-profile-pic"
                src={comment.userProfile.profile.profilePicture}
                alt={comment.userProfile.name}
                sx={{ width: '30px', height: '30px' }}
              />
              <Typography>{comment.userProfile.name}</Typography>
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
