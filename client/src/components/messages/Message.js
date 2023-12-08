import { Avatar, Card, CardContent, Typography } from '@mui/material';
import { dateFormatter } from '../../utilities/dateFormatter.js';

export const Message = ({ message, loggedInUser }) => {
  return (
    <>
      {loggedInUser.identityUserId === message.senderIdentityUserId ? (
        <Card sx={{ my: 2, mr: 6, backgroundColor: 'lightgrey' }}>
          <CardContent>
            <div
              style={{
                display: 'flex',
                justifyContent: 'space-between',
                alignItems: 'center',
                marginBottom: '8px',
              }}
            >
              <Avatar
                sx={{
                  width: '25px',
                  height: '25px',
                }}
                src={loggedInUser.profile.profilePicture}
              ></Avatar>
              <Typography variant="caption">
                {dateFormatter(message.date)}
              </Typography>
            </div>
            <Typography sx={{ mb: 1 }}>{message.body}</Typography>
          </CardContent>
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
              <Avatar
                sx={{
                  width: '25px',
                  height: '25px',
                }}
                src={message.receiver.profile.profilePicture}
              ></Avatar>
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
