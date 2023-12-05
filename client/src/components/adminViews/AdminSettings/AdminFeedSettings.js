import { AdminFeedPrimaryGenres } from "./subFeedSettings/AdminFeedPrimaryGenres.js";
import { AdminFeedPrimaryInstruments } from "./subFeedSettings/AdminFeedPrimaryInstruments.js";
import { AdminFeedStates } from "./subFeedSettings/AdminFeedStates.js";

export const AdminFeedSettings = () => {

  return (
    <>
      <div><AdminFeedStates/></div>
      <br />
      <div><AdminFeedPrimaryGenres /></div>
      <br />
      <div><AdminFeedPrimaryInstruments /></div>
    </>
  );
};
