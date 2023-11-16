import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  IconButton,
  Typography,
} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { DeleteComment } from './DeleteComment.js';
import { EditComment } from './EditComment.js';

export const MyCommentCard = ({ comment, profile, getCommentsForPost }) => {
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
              <DeleteComment
                commentId={comment.id}
                getCommentsForPost={getCommentsForPost}
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
