import { Avatar, Button, Stack, TextField } from "@mui/material";
import { useEffect, useState } from "react"
import { useSnackBar } from "../context/SnackBarContext.js";
import { fetchCreateNewComment } from "../../managers/commentsManager.js";

export const NewComment = ({
  profile,
  post,
  getCommentsForPost,
  newComment,
  setNewComment,
  loggedInUser,
  getUserPosts,
}) => {
  const [blankCommentError, setBlankCommentError] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  useEffect(() => {
    if (newComment.length !== 0) {
      setBlankCommentError(false);
    }
  }, [newComment]);

  const handleCreateComment = () => {
    setBlankCommentError(false);
    if (newComment.length > 0) {
      fetchCreateNewComment(post.id, newComment).then((res) => {
        console.log(res);
        if (res.id != undefined) {
          setSuccessAlert(true);
          setSnackBarMessage('Comment created successfully!');
          getUserPosts();
          getCommentsForPost();
          setNewComment('');
          handleSnackBarOpen();
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to create comment.');
          handleSnackBarOpen();
        }
      });
    } else {
      setBlankCommentError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Comment cannot be empty.');
      handleSnackBarOpen();
    }
  };

  return (
    <>
      <div className="new-comment-container">
        <Avatar
          className="single-profile-pic"
          src={loggedInUser.profile.profilePicture}
          alt={profile.name}
          sx={{ width: '35px', height: '35px' }}
        />

        <TextField
          className="comment-text-field"
          label="Add a comment..."
          autoFocus={true}
          multiline
          minRows={1}
          fullWidth
          value={newComment}
          onChange={(e) => setNewComment(e.target.value)}
          error={blankCommentError}
        />
        <Button
          variant="contained"
          onClick={handleCreateComment}
        >
          Submit
        </Button>
      </div>
    </>
  );
};