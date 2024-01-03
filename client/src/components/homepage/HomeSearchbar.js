import React from 'react';
import {
  Avatar,
  FormGroup,
  IconButton,
  InputAdornment,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  TextField,
  Typography,
  useMediaQuery,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { fetchSearchProfiles } from '../../managers/profileManager.js';
import { useNavigate } from 'react-router-dom';
import ClearIcon from '@mui/icons-material/Clear';
import './HomeSearchbar.css';
import { useTheme } from '@emotion/react';

export const HomeSearchbar = () => {
  const [searchTerms, setSearchTerms] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [currentSearch, setCurrentSearch] = useState(null);
  const navigate = useNavigate();

  const handleSearch = (currentSearch) => {
    fetchSearchProfiles(currentSearch).then((res) => {
      if (currentSearch === searchTerms) {
        setSearchResults(searchTerms !== '' ? res : []);
      }
    });
  };

  const handleClear = () => {
    setSearchTerms('');
    setSearchResults([]);
  };

  useEffect(() => {
    if (searchTerms) {
      setCurrentSearch(searchTerms);
      const timeoutId = setTimeout(() => {
        handleSearch(searchTerms);
      }, 100);
      return () => clearTimeout(timeoutId);
    }
  }, [searchTerms]);

  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  return (
    <>
      <FormGroup className="homeSearchBar-parent">
        <TextField
          label="Search"
          value={searchTerms}
          onChange={(e) => setSearchTerms(e.target.value)}
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                {searchTerms && (
                  <IconButton
                    className="clear-icon"
                    onClick={handleClear}
                    role="button"
                    tabIndex={0}
                  >
                    <ClearIcon />
                  </IconButton>
                )}
              </InputAdornment>
            ),
          }}
        />
        {searchTerms && searchResults.length > 0 ? (
          <div className="homeSearchBar-list">
            <List disablePadding>
              {searchResults.map((sr, index) => (
                <ListItem
                  key={index}
                  onClick={() => navigate(`/profile/${sr.profile.id}`)}
                >
                  <ListItemAvatar>
                    <Avatar src={sr.profile.profilePicture} />
                  </ListItemAvatar>
                  <ListItemText primary={sr.name} />
                </ListItem>
              ))}
            </List>
          </div>
        ) : (
          ''
        )}
      </FormGroup>
      {mediaQuerySmall ? (
        <Typography
          style={{
            marginBottom: '40px',
            fontSize: '14px',
            textAlign: 'center',
            fontStyle: 'italic',
          }}
        >
          Search by name, city, state code, genre, or instrument
        </Typography>
      ) : (
        <Typography
          style={{
            marginBottom: '80px',
            fontSize: '14px',
            textAlign: 'center',
            fontStyle: 'italic',
          }}
        >
          Search by name, city, state code, genre, or instrument
        </Typography>
      )}
    </>
  );
};
