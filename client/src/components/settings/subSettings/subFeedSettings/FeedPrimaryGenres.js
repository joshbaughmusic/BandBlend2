import { useEffect, useState } from 'react';
import { fetchUserFeedPrimaryGenres } from '../../../../managers/feedManager.js';

export const FeedPrimaryGenres = () => {
  const [feedPrimaryGenres, setFeedPrimaryGenres] = useState();

  useEffect(() => {
    fetchUserFeedPrimaryGenres().then(setFeedPrimaryGenres);
  }, []);

  if (!feedPrimaryGenres) {
    return null;
  }

  return (
    <>
      <div>Feed primary genre settings</div>
    </>
  );
};
