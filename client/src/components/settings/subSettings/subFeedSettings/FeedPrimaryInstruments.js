import { useEffect, useState } from 'react';
import { fetchUserFeedPrimaryInstruments } from '../../../../managers/feedManager.js';

export const FeedPrimaryInstruments = () => {
  const [feedPrimaryInstruments, setFeedPrimaryInstruments] = useState();

  useEffect(() => {
    fetchUserFeedPrimaryInstruments().then(setFeedPrimaryInstruments);
  }, []);

  if (!feedPrimaryInstruments) {
    return null;
  }

  return (
    <>
      <div>Feed primary instrument settings</div>
    </>
  );
};
