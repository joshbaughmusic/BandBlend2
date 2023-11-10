import { useEffect, useState } from 'react';
import { fetchOtherAdditionalPhotos } from '../../../managers/additonalPhotosManager.js';
import { OtherAdditionalPhotosItem } from './OtherAdditionalPhotosItem.js';

export const OtherAdditionalPhotos = ({ profileId }) => {
  const [photos, setPhotos] = useState();

  const getOtherAdditonalPhotos = () => {
    fetchOtherAdditionalPhotos(profileId).then(setPhotos);
  };

  useEffect(() => {
    getOtherAdditonalPhotos();
  }, []);

  if (!photos) {
    return null;
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
