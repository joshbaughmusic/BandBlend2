export const OtherAdditionalPhotosItem = ({ photo }) => {

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
