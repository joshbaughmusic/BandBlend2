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
import { fetchAdminAllAdmins, fetchDemoteToUser } from '../../../managers/adminFunctionsManager.js';
import { useNavigate } from 'react-router-dom';

export const AdminRoleAdjustSettings = () => {
  const [admins, setAdmins] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
    const navigate = useNavigate()

  const getAdmins = () => {
    fetchAdminAllAdmins().then((res) => {
        setAdmins(res)
    });
  };

  useEffect(() => {
    getAdmins();
  }, []);

  const handleDemote = (e) => {
    fetchDemoteToUser(e.target.value)
      .then((res) => {
       if (res.status !== 204) {
         setSuccessAlert(false);
         setSnackBarMessage('Failed to demote user.');
         handleSnackBarOpen();
       } else {
         getAdmins();
         setSuccessAlert(true);
         setSnackBarMessage('User successfully demoted.');
         handleSnackBarOpen();
       }
      })
      .catch((error) => {
        console.error(error);
        setSuccessAlert(false);
        setSnackBarMessage('Failed to demote user.');
        handleSnackBarOpen();
      });
  };

  if (!admins) {
    return (
      <>
        <Typography
          variant="h6"
          sx={{ mb: 1 }}
        >
          Other admins:
        </Typography>

        <Skeleton
          variant="rounded"
          width="100%"
          height={66}
        />
      </>
    );
  }
  if (!admins) {
    return (
      <>
        <Typography
          variant="h6"
          sx={{ mb: 1 }}
        >
          Other admins:
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
        Other admins:
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
          {admins.length === 0 ? (
            <Typography>{`No other admins to display currently.`}</Typography>
          ) : (
            <List disablePadding>
              {admins.map((a, index) => {
                return (
                  <>
                    <ListItem
                      key={index}
                      sx={{ display: 'flex', justifyContent: 'space-between' }}
                    >
                      <div
                        style={{
                          display: 'flex',
                          alignItems: "center"
                        }}
                      >
                        <ListItemAvatar>
                          <Avatar
                            onClick={() => navigate(`/profile/${a.id}`)}
                            sx={{ cursor: 'pointer' }}
                          >
                            <img
                              className="blockedAccount-avatar"
                              src={a.profile.profilePicture}
                              alt="Picture"
                            />
                          </Avatar>
                        </ListItemAvatar>
                        <Typography
                          onClick={() => navigate(`/profile/${a.id}`)}
                          sx={{ cursor: 'pointer' }}
                        >
                          {a.name}
                        </Typography>
                      </div>
                      <Button
                        variant="contained"
                        value={a.identityUserId}
                        onClick={(e) => handleDemote(e)}
                      >
                        Demote
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
