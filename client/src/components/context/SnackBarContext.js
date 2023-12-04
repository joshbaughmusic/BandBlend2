import { Alert, Snackbar } from '@mui/material';
import { createContext, useContext, useEffect, useState } from 'react';


const SnackBarContext = createContext({});

export const useSnackBar = () => {
  return useContext(SnackBarContext);
};

export const SnackBarProvider = ({ children }) => {
  const [snackBarMessage, setSnackBarMessage] = useState(false);
  const [successAlert, setSuccessAlert] = useState(false);
  const [snackBarOpen, setSnackBarOpen] = useState(false);

  const handleSnackBarOpen = () => {
    setSnackBarOpen(true);
  };

  const handleSnackBarClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }

    setSnackBarOpen(false);
  };

  return (
    <SnackBarContext.Provider
      value={{
        handleSnackBarOpen,
        handleSnackBarClose,
        setSnackBarMessage,
        setSuccessAlert,
      }}
    >
      {successAlert ? (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={3000}
          onClose={handleSnackBarClose}
          anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="success"
            sx={{ width: '100%' }}
          >
            {snackBarMessage}
          </Alert>
        </Snackbar>
      ) : (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={3000}
          onClose={handleSnackBarClose}
          anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="error"
            sx={{ width: '100%' }}
          >
            {snackBarMessage}
          </Alert>
        </Snackbar>
      )}
      {children}
    </SnackBarContext.Provider>
  );
};
