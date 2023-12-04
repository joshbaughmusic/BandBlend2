import {
  Container,
  Divider,
  Paper,
  Typography,
  Tabs,
  Tab,
  Box,
} from '@mui/material';
import PropTypes from 'prop-types';
import { useState } from 'react';
import { FeedSettings } from './subSettings/FeedSettings.js';
import { BlockedAccountsSettings } from './subSettings/BlockedAccountsSettings.js';
import { DeleteAccountSettings } from './subSettings/DeleteAccountSettings.js';
import './Settings.css';


function CustomTabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

CustomTabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.number.isRequired,
  value: PropTypes.number.isRequired,
};

function a11yProps(index) {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`,
  };
}

export const Settings = () => {
   const [value, setValue] = useState(0);

   const handleChange = (event, newValue) => {
     setValue(newValue);
   };
  return (
    <>
      <Container>
        <Paper
          elevation={4}
          className="settings-section"
        >
          <Typography
            sx={{ mb: 2, textAlign: 'center' }}
            variant="h6"
          >
            Settings
          </Typography>
          <Box
            sx={{
              borderBottom: 1,
              borderColor: 'divider',
              display: 'flex',
              justifyContent: 'center',
            }}
          >
            <Tabs
              value={value}
              onChange={handleChange}
              aria-label="basic tabs example"
            >
              <Tab
                label="Feed"
                {...a11yProps(0)}
              />
              <Tab
                label="Blocked"
                {...a11yProps(1)}
              />
              <Tab
                label="Delete"
                {...a11yProps(2)}
              />
            </Tabs>
          </Box>
          <CustomTabPanel
            value={value}
            index={0}
          >
            <FeedSettings />
          </CustomTabPanel>
          <CustomTabPanel
            value={value}
            index={1}
          >
            <BlockedAccountsSettings />
          </CustomTabPanel>
          <CustomTabPanel
            value={value}
            index={2}
          >
            <DeleteAccountSettings />
          </CustomTabPanel>
        </Paper>
      </Container>
    </>
  );
};


