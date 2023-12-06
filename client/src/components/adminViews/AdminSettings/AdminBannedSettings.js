import { useEffect, useState } from 'react';
import {
  Avatar,
  Box,
  Button,
  ButtonGroup,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Skeleton,
  Typography,
} from '@mui/material';
import { useSnackBar } from '../../context/SnackBarContext.js';
import {
  fetchAdminAllBannedUsers,
  fetchAdminDeleteUserProfile,
  fetchAdminUnbanAccount,
} from '../../../managers/adminFunctionsManager.js';

export const AdminBannedSettings = () => {
  const [bannedAccounts, setBannedAccounts] = useState();
  const [confirmOpen, setConfirmOpen] = useState(false);
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

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

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

  const handleDeleteUserProfile = (e) => {
    fetchAdminDeleteUserProfile(e.target.value).then((res) => {
      if (res.status !== 204) {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete user account.');
        handleSnackBarOpen();
      } else {
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('User account successfully deleted.');
        handleSnackBarOpen();
        getBannedAccounts();
      }
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
                      <ButtonGroup>
                        <Button
                          variant="contained"
                          value={a.id}
                          onClick={(e) => handleUnban(e)}
                        >
                          Unban
                        </Button>
                        <Button
                          variant="contained"
                          value={a.identityUserId}
                          onClick={() => setConfirmOpen(true)}
                          color="error"
                        >
                          Delete
                        </Button>
                      </ButtonGroup>
                    </ListItem>
                    <Dialog
                      open={confirmOpen}
                      onClose={handleConfirmClose}
                      aria-labelledby="alert-dialog-title"
                      aria-describedby="alert-dialog-description"
                    >
                      <DialogTitle id="alert-dialog-title">
                        {'Confirm Deletion'}
                      </DialogTitle>
                      <DialogContent>
                        <DialogContentText id="alert-dialog-description">
                          {`Are you sure you want delete ${a.name}'s account? Their account and all of their content and activity will be permanently deleted. This cannot be undone.`}
                        </DialogContentText>
                      </DialogContent>
                      <DialogActions>
                        <Button value={a.identityUserId} onClick={(e) => handleDeleteUserProfile(e)}>
                          Delete
                        </Button>
                        <Button onClick={handleConfirmClose}>Cancel</Button>
                      </DialogActions>
                    </Dialog>
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
