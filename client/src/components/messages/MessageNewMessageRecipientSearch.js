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
} from '@mui/material';
import { useEffect, useState } from 'react';
import { fetchSearchProfiles } from '../../managers/profileManager.js';
import { useNavigate } from 'react-router-dom';
import ClearIcon from '@mui/icons-material/Clear';
import { useMessages } from '../context/MessagesContext.js';

export const MessageNewMessageRecipient = () => {
  const [searchTerms, setSearchTerms] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [currentSearch, setCurrentSearch] = useState(null);
  const navigate = useNavigate();
  const {
    setActiveConversationId,
    setNewMessageView,
    setSelectedRecipient,
    conversations,
  } = useMessages();

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

  const handleSelect = (selectedUserProfile) => {
    if (conversations.some((c) => c.userProfileId == selectedUserProfile.id)) {
      const foundConversation = conversations.find(
        (c) => c.userProfileId == selectedUserProfile.id
      );
      setNewMessageView(false);
      setActiveConversationId(foundConversation.id);
      handleClear();
    } else {
      setSelectedRecipient(selectedUserProfile);
      handleClear();
    }
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

  return (
    <>
      <FormGroup
        sx={{ mt: 2 }}
        className="messageSearchBar-parent"
      >
        <TextField
          label="Search for user..."
          value={searchTerms}
          autoFocus={true}
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
          <div className="messageSearchBar-list">
            <List disablePadding>
              {searchResults.map((sr, index) => (
                <ListItem
                  key={index}
                  onClick={() => {
                    handleSelect(sr);
                  }}
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
    </>
  );
};
