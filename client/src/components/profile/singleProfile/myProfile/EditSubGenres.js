import { useEffect, useState } from 'react';
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Divider,
  FormControl,
  IconButton,
  Modal,
  Typography,
  Button,
  Tooltip,
  Box,
  FormGroup,
  FormControlLabel,
  Checkbox,
  FormLabel,
} from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import EditIcon from '@mui/icons-material/Edit';
import {
  fetchEditMyProfileSubGenres,
  fetchMyProfileSubGenres,
  fetchSubGenres,
} from '../../../../managers/subGenresManager.js';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
  height: '50%',
  overflowY: 'scroll'
};

export const EditSubGenres = ({ profile, getCurrentUserWithProfile }) => {
  const [subGenres, setSubGenres] = useState(false);
  //the below state is only storing the subGenre ids
  const [originalMyProfileSubGenres, setOriginalMyProfileSubGenres] = useState();
  const [myProfileSubGenres, setMyProfileSubGenres] = useState(false);
  const [selectedCount, setSelectedCount] = useState(3);
  const [openModal, setOpenModal] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getSubGenres = () => {
    fetchSubGenres().then(setSubGenres);
  };

  const getMyProfileSubGenres = () => {
    fetchMyProfileSubGenres().then((res) => {
      const currentSubGenreIdArray = [];
      res.map((pt) => {
        currentSubGenreIdArray.push(pt.subGenreId);
      });
      setMyProfileSubGenres(currentSubGenreIdArray);
      setOriginalMyProfileSubGenres(currentSubGenreIdArray);
    });
  };

  useEffect(() => {
    getSubGenres();
    getMyProfileSubGenres();
  }, [profile]);

  const handleModalOpen = () => setOpenModal(true);

  const handleModalClose = () => {
    if (
      !arraysContainSameElements(myProfileSubGenres, originalMyProfileSubGenres) ||
      myProfileSubGenres.length < 3
    ) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };

  const arraysContainSameElements = (array1, array2) => {
    const set1 = new Set(array1);
    const set2 = new Set(array2);
    if (set1.size !== set2.size) {
      return false;
    }
    for (const element of set1) {
      if (!set2.has(element)) {
        return false;
      }
    }
    return true;
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setMyProfileSubGenres(originalMyProfileSubGenres);
  };

  const handleCheck = (e) => {
    if (selectedCount < 3) {
      if (e.target.checked) {
        setMyProfileSubGenres([...myProfileSubGenres, parseInt(e.target.value)]);
        setSelectedCount(selectedCount + 1);
      } else {
        // User is unchecking an item
        setMyProfileSubGenres(
          myProfileSubGenres.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedCount(selectedCount - 1);
      }
    } else {
      if (!e.target.checked) {
        // User is unchecking an item
        setMyProfileSubGenres(
          myProfileSubGenres.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedCount(selectedCount - 1);
      } else {
        // User is trying to check more items beyond the limit
        setSnackBarMessage('No more than 3 SubGenres may be selected.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      }
    }
  };

  const handleSubmit = () => {
    if (myProfileSubGenres.length === 3) {
      fetchEditMyProfileSubGenres(myProfileSubGenres).then((res) => {
        if (res.status === 204) {
          getCurrentUserWithProfile();
          setSuccessAlert(true);
          setSnackBarMessage('SubGenres successfully updated!');
          handleConfirmClose();
          handleSnackBarOpen(true);
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to update SubGenres.');
          handleSnackBarOpen(true);
        }
      });
    } else {
      setSuccessAlert(false);
      setSnackBarMessage('You must select 3 SubGenres.');
      handleSnackBarOpen(true);
    }
  };

  if (!subGenres || !myProfileSubGenres || !originalMyProfileSubGenres) {
    return (
      <Tooltip
        title="Edit"
        placement="right-start"
      >
        <IconButton onClick={handleModalOpen}>
          <EditIcon />
        </IconButton>
      </Tooltip>
    );
  }
  return (
    <>
      <Tooltip
        title="Edit"
        placement="right-start"
      >
        <IconButton onClick={handleModalOpen}>
          <EditIcon />
        </IconButton>
      </Tooltip>
      <div>
        <Modal
          open={openModal}
          onClose={handleModalClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box sx={style}>
            <div className="divider-header-container">
              <div className="modal-header">
                <Typography
                  id="modal-modal-title"
                  variant="h6"
                  component="h2"
                >
                  Edit SubGenres
                </Typography>
                <IconButton onClick={handleModalClose}>
                  <CloseIcon />
                </IconButton>
              </div>
              <Divider />
            </div>
            <Box>
              <FormControl
                component="fieldset"
                variant="standard"
              >
                <FormLabel component="legend">Select 3:</FormLabel>

                <FormGroup>
                  {subGenres.map((t, index) => (
                    <FormControlLabel
                      key={index}
                      control={
                        <Checkbox
                          name={t.name}
                          checked={myProfileSubGenres.some((pt) => pt === t.id)}
                          onChange={handleCheck}
                          value={t.id}
                        />
                      }
                      label={t.name}
                    />
                  ))}
                </FormGroup>
              </FormControl>
            </Box>

            <div className="post-submit-button-container">
              <Button
                variant="contained"
                onClick={handleSubmit}
              >
                Submit
              </Button>
            </div>
          </Box>
        </Modal>
      </div>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{'Discard Changes?'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to discard your changes?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => handleConfirmClose()}>Discard Changes</Button>
          <Button onClick={() => setConfirmOpen(false)}>Cancel</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
