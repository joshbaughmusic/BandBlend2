import { useEffect, useState } from 'react';
import { fetchMyAdditionalPhotos } from '../../../managers/additonalPhotosManager.js';
import { MyAdditionalPhotosItem } from './MyAdditionalPhotosItem.js';
import { Skeleton } from '@mui/material';

export const MyAdditionalPhotos = () => {
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
        <div className="additional-pictures-container">
          <Skeleton
            variant="rectangular"
            width={125}
            height={125}
          />
          <Skeleton
            variant="rectangular"
            width={125}
            height={125}
          />
          <Skeleton
            variant="rectangular"
            width={125}
            height={125}
          />
        </div>
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
