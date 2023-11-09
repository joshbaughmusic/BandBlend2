import { useEffect, useState } from 'react';
import { fetchUserPosts } from '../../../managers/postsManager.js';
import { MyPostsCard } from './MyPostsCard.js';
import "../Posts.css"

export const MyPosts = ({ profile }) => {
  const [posts, setPosts] = useState();

  const getUserPosts = () => {
    fetchUserPosts(profile.id).then(setPosts);
  };

  useEffect(() => {
    getUserPosts();
  }, []);

  if (!posts) {
    return null;
  }

  if (posts.length === 0) {
    return (
      <>
        <div>No Posts yet!</div>
      </>
    );
  }

  return (
    <>
      <div>
        {posts.map((p, index) => (
          <MyPostsCard
            profile={profile}
            post={p}
            key={index}
          />
        ))}
      </div>
    </>
  );
};
