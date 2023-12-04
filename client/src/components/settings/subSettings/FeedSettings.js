import { FeedPrimaryGenres } from "./subFeedSettings/FeedPrimaryGenres.js";
import { FeedPrimaryInstruments } from "./subFeedSettings/FeedPrimaryInstruments.js";
import { FeedStates } from "./subFeedSettings/FeedStates.js";

export const FeedSettings = () => {

  return (
    <>
      <div><FeedStates /></div>
      <br />
      <div><FeedPrimaryGenres /></div>
      <br />
      <div><FeedPrimaryInstruments /></div>
    </>
  );
};
