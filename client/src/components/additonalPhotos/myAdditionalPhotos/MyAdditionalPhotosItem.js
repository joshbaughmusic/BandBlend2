import '../AdditionalPhotos.css';

export const MyAdditionalPhotosItem = ({ photo }) => {
  return (
    <>
      
        <img
          className="additional-photo"
          src={photo.url}
          alt="picture"
        />
    
    </>
  );
};
