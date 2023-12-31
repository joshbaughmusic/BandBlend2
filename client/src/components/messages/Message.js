import {
  Card,
  CardActions,
  CardContent,
  Typography,
} from '@mui/material';
import { dateFormatter } from '../../utilities/dateFormatter.js';
import { useNavigate } from 'react-router-dom';
import { DeleteMessage } from './DeleteMessage.js';
import { EditMessage } from './EditMessage.js';
import { useState } from 'react';

export const Message = ({ message, loggedInUser }) => {
  const navigate = useNavigate();
    const [anchorEl, setAnchorEl] = useState(null);

    const open = Boolean(anchorEl);
    const popperId = open ? 'simple-popper' : undefined;

    const handlePopperClick = (event) => {
      setAnchorEl(anchorEl ? null : event.currentTarget);
    };

  return (
    <>
      {loggedInUser.identityUserId === message.senderIdentityUserId ? (
        <Card
          sx={{ my: 2, mr: 6 }}
          className="myMessageCard"
        >
          <CardContent>
            <div
              style={{
            
                marginBottom: '10px',
              }}
            >
              
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
            <EditMessage message={message} />
            <DeleteMessage messageId={message.id} />
          </CardActions>
        </Card>
      ) : (
        <Card
          sx={{ my: 2, mr: 2, ml: 4 }}
          className="otherMessageCard"
        >
          <CardContent>
            <div
              style={{
                
                marginBottom: '10px',
              }}
            >
            
              <Typography sx={{ fontWeight: 'bold' }}>
                {message.sender.name}
              </Typography>
              <Typography variant="caption">
                {dateFormatter(message.date)}
              </Typography>
            </div>
            <Typography >{message.body}</Typography>
          </CardContent>
        </Card>
      )}
    </>
  );
};
