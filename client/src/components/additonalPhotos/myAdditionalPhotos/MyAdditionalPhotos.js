import { useEffect, useState } from 'react';
import { fetchMyAdditionalPhotos } from '../../../managers/additonalPhotosManager.js';
import { MyAdditionalPhotosItem } from './MyAdditionalPhotosItem.js';
import { Skeleton } from '@mui/material';

export const MyAdditionalPhotos = ({ profile }) => {
  const [photos, setPhotos] = useState();

  const getMyAdditonalPhotos = () => {
    fetchMyAdditionalPhotos().then(setPhotos);
  };

  useEffect(() => {
    getMyAdditonalPhotos();
  }, []);

  if (!photos) {
    return (
      <>
        {profile.profile.photoCount === null ||
        profile.profile.photoCount === 0 ? (
          <div>No Photos yet!</div>
        ) : (
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
        )}
      </>
    );
  }

  if (photos.length === 0) {
    return (
      <>
        <div>No Photos yet!</div>
      </>
    );
  }

  return (
    <div className="additional-pictures-container">
      {photos.map((p, index) => (
        <MyAdditionalPhotosItem
          key={index}
          photo={p}
        />
      ))}
    </div>
  );
};
