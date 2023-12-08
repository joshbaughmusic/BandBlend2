import { Card, CardContent, Typography } from '@mui/material';
import { dateFormatter } from '../../utilities/dateFormatter.js';

export const Message = ({ message }) => {
    
  return (
    <>
      <Card sx={{ my: 2, mr: 2, backgroundColor: "lightgrey" }}>
        <CardContent>
          <Typography sx={{mb: 1}}>{message.body}</Typography>
          <Typography variant="caption">
            {dateFormatter(message.date)}
          </Typography>
        </CardContent>
      </Card>
    </>
  );
};
