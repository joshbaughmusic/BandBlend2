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

export const MessageConversationSidebar = ({ conversations }) => {
  const {
    openMessages,
    setOpenMessages,
    handleCloseMessages,
    handleToggleMessages,
    activeConversationId,
    setActiveConversationId,
    newMessageView,
    setNewMessageView,
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
                ''
            ) : (
                <Tooltip
                  title="New Message"
                  placement="right"
                >
              <IconButton
                onClick={() => setNewMessageView(true)}
                sx={{ mt: '5px' }}
              >
                <AddIcon />
              </IconButton>
          </Tooltip>
            )}
          {conversations.map((conversation) => (
            <div
              style={{
                marginTop: '5px',
                padding: '3px',
                borderRadius: '50%',
                backgroundColor:
                  activeConversationId === conversation.id ? 'lightgrey' : '',
              }}
            >
              <Tooltip
                title={conversation.userProfile.name}
                placement="right"
                sx={{
                  zIndex: '2000',
                }}
              >
                <div
                  onClick={() => {
                    setNewMessageView(false);
                    setActiveConversationId(conversation.id);
                  }}
                >
                  <Avatar
                    alt={conversation.userProfile.name}
                    src={conversation.userProfile.profile.profilePicture}
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
