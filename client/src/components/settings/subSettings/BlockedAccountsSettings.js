import { useEffect, useState } from 'react';
import {
  fetchMyBlockedAccounts,
  fetchUnblockAccount,
} from '../../../managers/blockedAccountsManager.js';
import {
  Avatar,
  Box,
  Button,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Skeleton,
  Typography,
} from '@mui/material';
import { dateFormatter } from '../../../utilities/dateFormatter.js';
import { useSnackBar } from '../../context/SnackBarContext.js';

export const BlockedAccountsSettings = () => {
  const [myBlockedAccounts, setMyBlockedAccounts] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getMyBlockedAccounts = () => {
    fetchMyBlockedAccounts().then(setMyBlockedAccounts);
  };

  useEffect(() => {
    getMyBlockedAccounts();
  }, []);

  const handleUnblock = (e) => {
    fetchUnblockAccount(e.target.value)
      .then((res) => {
        if (res.status === 404) {
          setSuccessAlert(false);
          setSnackBarMessage('Account cannot be found.');
          handleSnackBarOpen();
        } else {
          setSuccessAlert(true);
          setSnackBarMessage('Successfully unblocked account.');
          handleSnackBarOpen();
          getMyBlockedAccounts();
        }
      })
      .catch((error) => {
        console.error(error);
        setSuccessAlert(false);
        setSnackBarMessage('Failed to unblock account.');
        handleSnackBarOpen();
      });
  };

  if (!myBlockedAccounts) {
    return (
      <>
        <Typography variant='h6' sx={{ mb: 1 }}>Blocked Accounts:</Typography>
       
          <Skeleton
            variant="rounded"
            width="100%"
            height={66}
          />
     
      </>
    );
  }

  return (
    <>
      <Typography
        variant="h6"
        sx={{ mb: 1 }}
      >
        Blocked Accounts:
      </Typography>
      <div>
        <Box
          sx={{
            minHeight: '66px',
            border: 1,
            borderColor: 'divider',
            padding: 2,
          }}
        >
          {myBlockedAccounts.length === 0 ? (
            <Typography>{`No accounts blocked. You can block a user account from their profile page.`}</Typography>
          ) : (
            <List disablePadding>
              {myBlockedAccounts.map((ba, index) => {
                return (
                  <>
                    <ListItem
                      key={index}
                      disablePadding
                    >
                      <ListItemAvatar>
                        <Avatar>
                          <img
                            className="blockedAccount-avatar"
                            src={ba.blockedUserProfile.profile.profilePicture}
                            alt="Picture"
                          />
                        </Avatar>
                      </ListItemAvatar>
                      <ListItemText
                        primary={ba.blockedUserProfile.name}
                        secondary={`Blocked on: ${dateFormatter(ba.date)}`}
                      />
                      <Button
                        variant="contained"
                        value={ba.id}
                        onClick={(e) => handleUnblock(e)}
                      >
                        Unblock
                      </Button>
                    </ListItem>
                  </>
                );
              })}
            </List>
          )}
        </Box>
      </div>
    </>
  );
};
