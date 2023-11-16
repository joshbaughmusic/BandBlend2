export const OtherAdditionalPhotosItem = ({ photo }) => {

  return (
    <>
    <div className="photoItem"></div>
      <img
        className="additional-photo"
        src={photo.url}
        alt="picture"
      />
    </>
  );
};
