import { useEffect, useState } from 'react';
import { fetchUserFeedStates } from '../../../../managers/feedManager.js';
import { Box } from '@mui/material';
import { fetchStates } from '../../../../managers/statesManager.js';

export const FeedStates = () => {
  const [feedStates, setFeedStates] = useState();
  const [states, setStates] = useState();

  useEffect(() => {
    fetchUserFeedStates().then(setFeedStates);
    fetchStates().then(setStates);
  }, []);

  if (!feedStates || !states) {
    return null;
  }

  return (
    <>
      <Box
        sx={{
          border: 1,
          borderColor: 'divider',
        }}
      >
        
      </Box>
    </>
  );
};
