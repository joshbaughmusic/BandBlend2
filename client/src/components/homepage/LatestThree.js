import { useEffect, useState } from 'react';
import {
  Divider,
  Typography,
  Container,
  Paper,
} from '@mui/material';
import { fetchLatestThree } from '../../managers/feedManager.js';
import { useNavigate } from 'react-router-dom';
import { FeedPostCard } from '../feed/FeedPostCard.js';
import { FeedPostSkeleton } from '../feed/FeedPostSkeleton.js';

export const LatestThree = ({ loggedInUser }) => {
  const [feedPosts, setFeedPosts] = useState();
  const navigate = useNavigate();

  const getUserFeed = () => {
    fetchLatestThree().then((res) => {
      setFeedPosts(res.posts);
    });
  };

  useEffect(() => {
    getUserFeed();
  }, []);

  if (!feedPosts) {
    return (
      <>
        <Container>
          <Paper
            elevation={4}
            className="profile-right-section-item feed-container"
          >
            <Typography
              sx={{ m: 1, textAlign: 'center' }}
              variant="h6"
            >
              What's happening:
            </Typography>
            <Divider sx={{ mb: 3 }} />
            <div>
              {Array(3)
                .fill(0)
                .map((obj, index) => (
                  <FeedPostSkeleton key={index} />
                ))}
            </div>
          </Paper>
        </Container>
      </>
    );
  }

  if (feedPosts.length === 0) {
    return (
      <>
        <Container>
          <Paper
            elevation={4}
            className="profile-right-section-item feed-container"
          >
            <Typography
              sx={{ m: 1, textAlign: 'center' }}
              variant="h6"
            >
              What's happening:
            </Typography>
            <Divider sx={{ mb: 3 }} />
            <Typography
              sx={{ mt: 3, textAlign: 'center' }}
              variant="h6"
            >
              Wow, much empty...
            </Typography>
            <Typography sx={{ mt: 3, textAlign: 'center' }}>
              Adjust your{' '}
              <span
                onClick={() => navigate('/settings')}
                className="feedSettingsLink"
              >
                feed settings
              </span>{' '}
              or follow some other users to see expand your feed.
            </Typography>
          </Paper>
        </Container>
      </>
    );
  }

  return (
    <>
      <Container>
        <Paper
          elevation={4}
          className="profile-right-section-item feed-container"
        >
          <Typography
            sx={{ m: 1, textAlign: 'center' }}
            variant="h6"
          >
            What's happening:
          </Typography>
          <Divider sx={{ mb: 3 }} />
          <div>
            {feedPosts.map((p, index) => (
              <FeedPostCard
                profile={p.userProfile}
                post={p}
                key={`${p.id}-${index}`}
                loggedInUser={loggedInUser}
                getUserFeed={getUserFeed}
              />
            ))}
          </div>
        </Paper>
      </Container>
    </>
  );
};
