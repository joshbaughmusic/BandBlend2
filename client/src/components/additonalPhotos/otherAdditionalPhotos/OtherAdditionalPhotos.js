import { useEffect, useState } from 'react';
import { fetchOtherAdditionalPhotos } from '../../../managers/additonalPhotosManager.js';
import { OtherAdditionalPhotosItem } from './OtherAdditionalPhotosItem.js';
import { Skeleton } from '@mui/material';

export const OtherAdditionalPhotos = ({ profile }) => {
  const [photos, setPhotos] = useState();

  const getOtherAdditonalPhotos = () => {
    fetchOtherAdditionalPhotos(profile.id).then(setPhotos);
  };

  useEffect(() => {
    getOtherAdditonalPhotos();
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
    <>
      <div className="additional-pictures-container">
        {photos.map((p, index) => (
          <OtherAdditionalPhotosItem
            key={index}
            photo={p}
          />
        ))}
      </div>
    </>
  );
};
