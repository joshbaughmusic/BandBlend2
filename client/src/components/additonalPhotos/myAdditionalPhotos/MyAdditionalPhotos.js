import { useEffect, useState } from 'react';
import {
  fetchMyAdditionalPhotos,
  fetchUploadAdditionalPhoto,
} from '../../../managers/additonalPhotosManager.js';
import { MyAdditionalPhotosItem } from './MyAdditionalPhotosItem.js';
import {
  Divider,
  IconButton,
  Skeleton,
  Tooltip,
  Typography,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { styled } from '@mui/material/styles';
import axios from 'axios';
import { useSnackBar } from '../../context/SnackBarContext.js';

const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});

export const MyAdditionalPhotos = ({ profile }) => {
  const [picPopUp, setPicPopUp] = useState(null);
  const [photos, setPhotos] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getMyAdditonalPhotos = () => {
    fetchMyAdditionalPhotos().then(setPhotos);
  };

  useEffect(() => {
    getMyAdditonalPhotos();
  }, []);

  const handleUpload = async (e) => {
    const formData = new FormData();
    formData.append('file', e.target.files[0]);
    formData.append('upload_preset', 'unsigned');
    await axios
      .post('https://api.cloudinary.com/v1_1/dfanwgskl/image/upload', formData)
      .then((response) => {
        fetchUploadAdditionalPhoto(response.data['secure_url']).then((res) => {
          e.target.value = '';
          if (res.status === 201) {
            getMyAdditonalPhotos();
            setSuccessAlert(true);
            setSnackBarMessage('Photo successfully uploaded!');
            handleSnackBarOpen(true);
          } else {
            setSuccessAlert(false);
            setSnackBarMessage('Failed to upload photo.');
            handleSnackBarOpen(true);
          }
        });
      });
  };

  if (!photos) {
    return (
      <>
        {profile.profile.photoCount === null ||
        profile.profile.photoCount === 0 ? (
          <>
            <div className="divider-header-container">
              <div className="profile-section-header">
                <Typography variant="h6">Additional Photos</Typography>
                <Tooltip
                  title="Add Photo"
                  placement="left-start"
                >
                  <IconButton
                    component="label"
                    variant="contained"
                  >
                    <AddIcon />
                    <VisuallyHiddenInput
                      type="file"
                      accept="image"
                      onChange={handleUpload}
                    />
                  </IconButton>
                </Tooltip>
              </div>
              <Divider />
            </div>
            <div>No Photos yet!</div>
          </>
        ) : (
          <>
            <div className="divider-header-container">
              <div className="profile-section-header">
                <Typography variant="h6">Additional Photos</Typography>
                <Tooltip
                  title="Add Photo"
                  placement="left-start"
                >
                  <IconButton
                    component="label"
                    variant="contained"
                  >
                    <AddIcon />
                    <VisuallyHiddenInput
                      type="file"
                      accept="image"
                      onChange={handleUpload}
                    />
                  </IconButton>
                </Tooltip>
              </div>
              <Divider />
            </div>
            <div className="additional-pictures-container">
              {Array(profile.profile.photoCount)
                .fill(0)
                .map((obj, index) => (
                  <Skeleton
                    variant="rectangular"
                    key={index}
                    width={125}
                    height={125}
                  />
                ))}
            </div>
          </>
        )}
      </>
    );
  }

  if (photos.length === 0) {
    return (
      <>
        <div className="divider-header-container">
          <div className="profile-section-header">
            <Typography variant="h6">Additional Photos</Typography>
            <Tooltip
              title="Add Photo"
              placement="left-start"
            >
              <IconButton
                component="label"
                variant="contained"
              >
                <AddIcon />
                <VisuallyHiddenInput
                  type="file"
                  accept="image"
                  onChange={handleUpload}
                />
              </IconButton>
            </Tooltip>
          </div>
          <div className="profile-section-header"></div>
          <Divider />
        </div>
        <div>No Photos yet!</div>
      </>
    );
  }

  return (
    <>
      <div className="divider-header-container">
        <div className="profile-section-header">
          <Typography variant="h6">Additional Photos</Typography>
          <Tooltip
            title="Add Photo"
            placement="left-start"
          >
            <IconButton
              component="label"
              variant="contained"
            >
              <AddIcon />
              <VisuallyHiddenInput
                type="file"
                accept="image"
                onChange={handleUpload}
              />
            </IconButton>
          </Tooltip>
        </div>
        <Divider />
      </div>
      <div className="additional-pictures-container">
        {photos.map((p, index) => (
          <MyAdditionalPhotosItem
            picPopUp={picPopUp}
            setPicPopUp={setPicPopUp}
            key={index}
            photo={p}
            getMyAdditonalPhotos={getMyAdditonalPhotos}
          />
        ))}
      </div>
    </>
  );
};
