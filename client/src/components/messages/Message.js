import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  Typography,
} from '@mui/material';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { useNavigate } from 'react-router-dom';
import { DeleteMessage } from './DeleteMessage.js';
import { EditMessage } from './EditMessage.js';

export const Message = ({ message, loggedInUser }) => {
  const navigate = useNavigate();
  return (
    <>
      {loggedInUser.identityUserId === message.senderIdentityUserId ? (
        <Card sx={{ my: 2, mr: 6, backgroundColor: 'lightgrey' }} className='myMessageCard'>
          <CardContent>
            <div
              style={{
                display: 'flex',
                justifyContent: 'space-between',
                alignItems: 'center',
                marginBottom: '8px',
              }}
            >
              {/* <Avatar
                sx={{
                  width: '25px',
                  height: '25px',
                }}
                src={loggedInUser.profile.profilePicture}
              /> */}
              <Typography sx={{ fontWeight: 'bold' }}>
                {loggedInUser.name}
              </Typography>
              <Typography variant="caption">
                {dateFormatter(message.date)}
              </Typography>
            </div>
            <Typography>{message.body}</Typography>
          </CardContent>
          <CardActions disableSpacing>
            <DeleteMessage messageId={message.id} />
            <EditMessage message={message} />
          </CardActions>
        </Card>
      ) : (
        <Card sx={{ my: 2, mr: 2, ml: 4, backgroundColor: 'darkgrey' }}>
          <CardContent>
            <div
              style={{
                display: 'flex',
                justifyContent: 'space-between',
                alignItems: 'center',
                marginBottom: '8px',
              }}
            >
              {/* <Avatar
                sx={{
                  width: '25px',
                  height: '25px',
                }}
                src={message.receiver.profile.profilePicture}
              /> */}
              <Typography sx={{ fontWeight: 'bold' }}>
                {message.sender.name}
              </Typography>
              <Typography variant="caption">
                {dateFormatter(message.date)}
              </Typography>
            </div>
            <Typography sx={{ mb: 1 }}>{message.body}</Typography>
          </CardContent>
        </Card>
      )}
    </>
  );
};
