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
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { useState } from 'react';
import { styled } from '@mui/material/styles';


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

export const MyPostsCard = ({ post, profile }) => {
   const [expanded, setExpanded] = useState(false);

   const handleExpandClick = () => {
     setExpanded(!expanded);
   };

  return (
    <>
      <Card className='post-card'>
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
            <Typography>{post.date}</Typography>
          </div>
          <div>
            <Typography>{post.body}</Typography>
          </div>
        </CardContent>
        <CardActions disableSpacing>
          <div className="post-card-footer">
            <div>
              <IconButton>
                <DeleteIcon />
              </IconButton>
              <IconButton>
                <EditIcon />
              </IconButton>
            </div>
            <div className="post-card-footer-right">
              <Typography>View Comments</Typography>
              <ExpandMore
                expand={expanded}
                onClick={handleExpandClick}
                aria-expanded={expanded}
                aria-label="show more"
              >
                <ExpandMoreIcon />
              </ExpandMore>
            </div>
          </div>
        </CardActions>
      </Card>
    </>
  );
};