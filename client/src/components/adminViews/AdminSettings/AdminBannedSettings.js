import { useEffect, useState } from 'react';
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
import { useSnackBar } from '../../context/SnackBarContext.js';
import { fetchAdminAllBannedUsers, fetchAdminUnbanAccount } from '../../../managers/adminFunctionsManager.js';


export const AdminBannedSettings = () => {
  const [bannedAccounts, setBannedAccounts] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getBannedAccounts = () => {
    fetchAdminAllBannedUsers().then((res) => {
      setBannedAccounts(res);
    });
  };

  useEffect(() => {
    getBannedAccounts();
  }, []);

  const handleUnban = (e) => {
    fetchAdminUnbanAccount(e.target.value)
      .then((res) => {
        if (res.status !== 204) {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to unban user account.');
          handleSnackBarOpen();
        } else {
          getBannedAccounts();
          setSuccessAlert(true);
          setSnackBarMessage('User account successfully unbanned.');
          handleSnackBarOpen();
        }
      })
      .catch((error) => {
        console.error(error);
        setSuccessAlert(false);
        setSnackBarMessage('Failed to unban user account.');
        handleSnackBarOpen();
      });
  };

  if (!bannedAccounts) {
    return (
      <>
        <Typography
          variant="h6"
          sx={{ mb: 1 }}
        >
          Banned Accounts:
        </Typography>

        <Skeleton
          variant="rounded"
          width="100%"
          height={66}
        />
      </>
    );
  }
  if (!bannedAccounts) {
    return (
      <>
        <Typography
          variant="h6"
          sx={{ mb: 1 }}
        >
          Banned Accounts:
        </Typography>

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
        Banned Accounts:
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
          {bannedAccounts.length === 0 ? (
            <Typography>{`No accounts are currently banned.`}</Typography>
          ) : (
            <List disablePadding>
              {bannedAccounts.map((a, index) => {
                return (
                  <>
                    <ListItem key={index}>
                      <ListItemAvatar>
                        <Avatar>
                          <img
                            className="blockedAccount-avatar"
                            src={a.profile.profilePicture}
                            alt="Picture"
                          />
                        </Avatar>
                      </ListItemAvatar>
                      <ListItemText primary={a.name} />
                      <Button
                        variant="contained"
                        value={a.id}
                        onClick={(e) => handleUnban(e)}
                      >
                        Unban
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
