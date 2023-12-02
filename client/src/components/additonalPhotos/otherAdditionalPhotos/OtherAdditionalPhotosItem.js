export const OtherAdditionalPhotosItem = ({ photo, picPopUp, setPicPopUp }) => {

  return (
    <>
      <div className="photoItem" onClick={() => setPicPopUp(photo)}>
        <img
          className="additional-photo"
          src={photo.url}
          alt="picture"
        />
      </div>
      {picPopUp ? (
        <div className="popup-media">
          <span onClick={() => setPicPopUp(null)}>&times;</span>
          <img
            className="popup-photoItem"
            src={picPopUp?.url}
            alt="An enlarged photo"
          />
        </div>
      ) : (
        ''
      )}
    </>
  );
};
