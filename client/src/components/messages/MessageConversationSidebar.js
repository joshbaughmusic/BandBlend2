import {
  Avatar,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Tooltip,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import CloseIcon from '@mui/icons-material/Close';
import { useMessages } from '../context/MessagesContext.js';

export const MessageConversationSidebar = () => {
  const {
    activeConversationId,
    setActiveConversationId,
    newMessageView,
    setNewMessageView,
    setSelectedRecipient,
    conversations,
  } = useMessages();

  if (!conversations) {
    return (
      <>
        <div
          style={{
            position: 'absolute',
            left: 0,
            width: 60,
            height: '435px',
            overflow: 'auto',
            borderRight: '1px solid black',
            zIndex: '2000',
            background: 'white',
          }}
        >
          <div
            style={{
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
              gap: '2px',
            }}
          ></div>
        </div>
      </>
    );
  }
  return (
    <>
      <div
        style={{
          position: 'absolute',
          left: 0,
          width: 60,
          height: '435px',
          overflow: 'auto',
          borderRight: '1px solid black',
          zIndex: '1500',
          background: 'white',
        }}
      >
        <div
          style={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          {newMessageView ? (
            <IconButton
              disabled
              onClick={() => {
                setNewMessageView(true);
                setActiveConversationId(null);
              }}
              sx={{ mt: '5px' }}
            >
              <AddIcon />
            </IconButton>
          ) : (
            <Tooltip
              title="New Message"
              placement="right"
            >
              <IconButton
                onClick={() => {
                  setNewMessageView(true);
                  setActiveConversationId(null);
                  setSelectedRecipient(null)
                }}
                sx={{ mt: '5px' }}
              >
                <AddIcon />
              </IconButton>
            </Tooltip>
          )}
          {conversations.map((c) => (
            <div
              style={{
                marginTop: '5px',
                padding: '3px',
                borderRadius: '50%',
                backgroundColor:
                  activeConversationId === c.id ? 'lightgrey' : '',
              }}
            >
              <Tooltip
                title={c.userProfile.name}
                placement="right"
                sx={{
                  zIndex: '2000',
                }}
              >
                <div
                  onClick={() => {
                    setNewMessageView(false);
                    setActiveConversationId(c.id);
                  }}
                >
                  <Avatar
                  sx={{width: "30px", height: "30px"}}
                    alt={c.userProfile.name}
                    src={c.userProfile.profile.profilePicture}
                  />
                </div>
              </Tooltip>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};
