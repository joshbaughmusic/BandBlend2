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
import { AdminFeedSettings } from './AdminFeedSettings.js';
import { AdminBannedSettings } from './AdminBannedSettings.js';
import { AdminRoleAdjustSettings } from './AdminRoleAdjustSettings.js';

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

export const AdminSettings = () => {
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
            {`Settings (Admin)`}
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
                label="Banned"
                {...a11yProps(1)}
              />
              <Tab
                label="Admins"
                {...a11yProps(2)}
              />
            </Tabs>
          </Box>
          <CustomTabPanel
            value={value}
            index={0}
          >
            <AdminFeedSettings />
          </CustomTabPanel>
          <CustomTabPanel
            value={value}
            index={1}
          >
            <AdminBannedSettings />
          </CustomTabPanel>
          <CustomTabPanel
            value={value}
            index={2}
          >
            <AdminRoleAdjustSettings />
          </CustomTabPanel>
        </Paper>
      </Container>
    </>
  );
};
