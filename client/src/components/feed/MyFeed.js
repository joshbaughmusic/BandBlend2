import { useEffect, useState } from 'react';
import {
  Divider,
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Typography,
  Container,
  Paper,
  useMediaQuery,
  IconButton,
  Tooltip,
} from '@mui/material';
import { fetchUserFeed } from '../../managers/feedManager.js';
import { FeedPostCard } from './FeedPostCard.js';
import { useNavigate } from 'react-router-dom';
import { FeedPostSkeleton } from './FeedPostSkeleton.js';
import './Feed.css';
import { useTheme } from '@emotion/react';
import SettingsIcon from '@mui/icons-material/Settings';

export const MyFeed = ({ loggedInUser }) => {
  const [feedPosts, setFeedPosts] = useState();
  const [feedPostCount, setFeedPostCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(10);
  const navigate = useNavigate();

  const getUserFeed = () => {
    fetchUserFeed(page, amountPerPage).then((res) => {
      setFeedPosts(res.posts);
      setFeedPostCount(res.totalCount);
    });
  };

  useEffect(() => {
    getUserFeed();
  }, [page, amountPerPage]);

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  if (!feedPosts) {
    return (
      <>
        <Container>
          {mediaQuerySmall ? (
            <Paper
              elevation={4}
              className="profile-right-section-item feed-container"
              sx={{ mt: '75px' }}
            >
              <div style={{ position: 'relative' }}>
                <Typography
                  sx={{ m: 1, textAlign: 'center' }}
                  variant="h6"
                >
                  Feed:
                </Typography>
                <div className="feed-settings-icon">
                  <Tooltip
                    title="Settings"
                    placement="left"
                  >
                    <IconButton onClick={() => navigate('/settings')}>
                      <SettingsIcon />
                    </IconButton>
                  </Tooltip>
                </div>
                <Divider sx={{ mb: 3 }} />
              </div>
              <div>
                {Array(5)
                  .fill(0)
                  .map((obj, index) => (
                    <FeedPostSkeleton key={index} />
                  ))}
              </div>
            </Paper>
          ) : (
            <Paper
              elevation={4}
              className="profile-right-section-item feed-container"
              sx={{ my: '20px', mx: '0px', p: 2 }}
            >
              <div style={{ position: 'relative' }}>
                <Typography
                  sx={{ m: 1, textAlign: 'center' }}
                  variant="h6"
                >
                  Feed:
                </Typography>
                <div className="feed-settings-icon">
                  <Tooltip
                    title="Settings"
                    placement="left"
                  >
                    <IconButton onClick={() => navigate('/settings')}>
                      <SettingsIcon />
                    </IconButton>
                  </Tooltip>
                </div>
                <Divider sx={{ mb: 3 }} />
              </div>
              <div>
                {Array(5)
                  .fill(0)
                  .map((obj, index) => (
                    <FeedPostSkeleton key={index} />
                  ))}
              </div>
            </Paper>
          )}
        </Container>
      </>
    );
  }

  if (feedPostCount === 0) {
    return (
      <>
        <Container>
          {mediaQuerySmall ? (
            <Paper
              elevation={4}
              className="profile-right-section-item feed-container"
              sx={{ mt: '75px', p: 2 }}
            >
              <div style={{ position: 'relative' }}>
                <Typography
                  sx={{ m: 1, textAlign: 'center' }}
                  variant="h6"
                >
                  Feed:
                </Typography>
                <div className="feed-settings-icon">
                  <Tooltip
                    title="Settings"
                    placement="left"
                  >
                    <IconButton onClick={() => navigate('/settings')}>
                      <SettingsIcon />
                    </IconButton>
                  </Tooltip>
                </div>
                <Divider sx={{ mb: 3 }} />
              </div>
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
          ) : (
            <Paper
              elevation={4}
              className="profile-right-section-item feed-container"
              sx={{ my: '20px', mx: '0px', p: 2 }}
            >
              <div style={{ position: 'relative' }}>
                <Typography
                  sx={{ m: 1, textAlign: 'center' }}
                  variant="h6"
                >
                  Feed:
                </Typography>
                <div className="feed-settings-icon">
                  <Tooltip
                    title="Settings"
                    placement="left"
                  >
                    <IconButton onClick={() => navigate('/settings')}>
                      <SettingsIcon />
                    </IconButton>
                  </Tooltip>
                </div>
                <Divider sx={{ mb: 3 }} />
              </div>
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
          )}
        </Container>
      </>
    );
  }

  return (
    <>
      <Container>
        {mediaQuerySmall ? (
          <Paper
            elevation={4}
            className="profile-right-section-item feed-container"
            sx={{ mt: '75px', p: 2 }}
          >
            <div style={{ position: 'relative' }}>
              <Typography
                sx={{ m: 1, textAlign: 'center' }}
                variant="h6"
              >
                Feed:
              </Typography>
              <div className="feed-settings-icon">
                <Tooltip
                  title="Settings"
                  placement="left"
                >
                  <IconButton onClick={() => navigate('/settings')}>
                    <SettingsIcon />
                  </IconButton>
                </Tooltip>
              </div>
              <Divider sx={{ mb: 3 }} />
            </div>
            <div>
              {feedPosts.map((p, index) => (
                <FeedPostCard
                  profile={p.userProfile}
                  post={p}
                  key={`${p.id}-${index}`}
                  page={page}
                  loggedInUser={loggedInUser}
                  getUserFeed={getUserFeed}
                />
              ))}
            </div>
            <div className="pagination-allprofiles-container">
              <Pagination
                count={Math.ceil(feedPostCount / amountPerPage)}
                page={page}
                onChange={handlePageChange}
              />
              <FormControl
                sx={{ m: 1, minWidth: 75 }}
                size="small"
              >
                <InputLabel id="amountPerPage-select-label">
                  Per Page
                </InputLabel>
                <Select
                  labelId="amountPerPage-select-label"
                  id="amountPerPage-select"
                  value={amountPerPage}
                  label="Age"
                  onChange={handleAmountPerPageChange}
                >
                  <MenuItem value={10}>10</MenuItem>
                  <MenuItem value={20}>20</MenuItem>
                  <MenuItem value={30}>30</MenuItem>
                </Select>
              </FormControl>
            </div>
          </Paper>
        ) : (
          <Paper
            elevation={4}
            className="profile-right-section-item feed-container"
            sx={{ my: '20px', mx: '0px', p: 2 }}
          >
            <div style={{ position: 'relative' }}>
              <Typography
                sx={{ m: 1, textAlign: 'center' }}
                variant="h6"
              >
                Feed:
              </Typography>
              <div className="feed-settings-icon">
                <Tooltip
                  title="Settings"
                  placement="left"
                >
                  <IconButton
                    onClick={() => navigate('/settings')}
                  >
                    <SettingsIcon />
                  </IconButton>
                </Tooltip>
              </div>
              <Divider sx={{ mb: 3 }} />
            </div>
            <div>
              {feedPosts.map((p, index) => (
                <FeedPostCard
                  profile={p.userProfile}
                  post={p}
                  key={`${p.id}-${index}`}
                  page={page}
                  loggedInUser={loggedInUser}
                  getUserFeed={getUserFeed}
                />
              ))}
            </div>
            <div className="pagination-allprofiles-container">
              <Pagination
                count={Math.ceil(feedPostCount / amountPerPage)}
                page={page}
                onChange={handlePageChange}
              />
              <FormControl
                sx={{ m: 1, minWidth: 75 }}
                size="small"
              >
                <InputLabel id="amountPerPage-select-label">
                  Per Page
                </InputLabel>
                <Select
                  labelId="amountPerPage-select-label"
                  id="amountPerPage-select"
                  value={amountPerPage}
                  label="Age"
                  onChange={handleAmountPerPageChange}
                >
                  <MenuItem value={10}>10</MenuItem>
                  <MenuItem value={20}>20</MenuItem>
                  <MenuItem value={30}>30</MenuItem>
                </Select>
              </FormControl>
            </div>
          </Paper>
        )}
      </Container>
    </>
  );
};
