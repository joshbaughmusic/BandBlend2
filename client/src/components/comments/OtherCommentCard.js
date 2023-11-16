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

export const OtherCommentCard = ({ comment, profile }) => {
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
                <IconButton>
                  <ThumbUpAltIcon />
                </IconButton>
              </div>
            </div>
          </div>
        </CardActions>
      </Card>
    </>
  );
};
