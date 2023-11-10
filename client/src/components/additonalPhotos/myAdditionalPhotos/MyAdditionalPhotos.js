import { useEffect, useState } from 'react';
import { fetchMyAdditionalPhotos } from '../../../managers/additonalPhotosManager.js';
import { MyAdditionalPhotosItem } from './MyAdditionalPhotosItem.js';


export const MyAdditionalPhotos = () => {
  const [photos, setPhotos] = useState();

  const getMyAdditonalPhotos = () => {
    fetchMyAdditionalPhotos().then(setPhotos);
  };

  useEffect(() => {
    getMyAdditonalPhotos();
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
    <div className='additional-pictures-container'
    >
      {photos.map((p, index) => (
        <MyAdditionalPhotosItem
          key={index}
          photo={p}
        />
      ))}
    </div>
  );
};
