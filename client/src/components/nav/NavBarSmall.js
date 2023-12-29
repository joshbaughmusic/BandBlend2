import * as React from 'react';
import {  useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import AppBar from '@mui/material/AppBar';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import PersonIcon from '@mui/icons-material/Person';
import RssFeedIcon from '@mui/icons-material/RssFeed';
import PeopleIcon from '@mui/icons-material/People';
import SettingsIcon from '@mui/icons-material/Settings';
import HomeIcon from '@mui/icons-material/Home';
import LocalPoliceIcon from '@mui/icons-material/LocalPolice';
import DarkModeIcon from '@mui/icons-material/DarkMode';
import LightModeIcon from '@mui/icons-material/LightMode';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import './NavBar.css';
import { useNavigate } from 'react-router-dom';
import MainLogoBlack from '../../images/Bandblend_Logos/Logo-top-black.png';
import MainLogoWhite from '../../images/Bandblend_Logos/Logo-top-white.png';
import NavLogoBlack from '../../images/Bandblend_Logos/Logo-nav-black.png';
import NavLogoWhite from '../../images/Bandblend_Logos/Logo-nav-white.png';
import { Drawer} from '@mui/material';
import { logout } from '../../managers/authManager.js';
import { useThemeContext } from '../context/ThemeContext.js';
import MenuIcon from '@mui/icons-material/Menu';
import CloseIcon from '@mui/icons-material/Close';

export const NavBarSmall = ({ loggedInUser, setLoggedInUser }) => {
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate();
  const { darkMode, handleDarkModeClick } = useThemeContext();

  const toggleDrawer = (event) => {
    if (
      event.type === 'keydown' &&
      (event.key === 'Tab' || event.key === 'Shift')
    ) {
      return;
    }

    setOpen(true);
  };

  if (!loggedInUser) {
    return null;
  }

  if (loggedInUser.accountBanned) {
    return (
      <>
        <div>
          <Drawer
            anchor="left"
            open={open}
            onClose={() => toggleDrawer(false)}
          >
            <div>
              <ListItem
                disablePadding
                sx={{ display: 'block' }}
              >
                <ListItemButton
                  onClick={() => setOpen(false)}
                  sx={{
                    px: 2.5,
                  }}
                >
                  <ListItemIcon
                    sx={{
                      minWidth: 0,
                      mr: open ? 3 : 'auto',
                      justifyContent: 'center',
                    }}
                  >
                    <CloseIcon />
                  </ListItemIcon>
                  <ListItemText primary={'Close'} />
                </ListItemButton>
              </ListItem>
            </div>
            <Divider />
            <List
              sx={{
                display: 'flex',
                height: '100%',
                flexDirection: 'column',
                justifyContent: 'between',
              }}
            >
              {loggedInUser ? (
                <ListItem
                  disablePadding
                  sx={{ display: 'block' }}
                >
                  <ListItemButton
                    sx={{
                      minHeight: 48,
                      justifyContent: open ? 'initial' : 'center',
                      px: 2.5,
                    }}
                    onClick={(e) => {
                      e.preventDefault();
                      setOpen(false);
                      logout().then(() => {
                        setTimeout(() => {
                          setLoggedInUser(null);
                          setOpen(false);
                          navigate('/');
                        }, 1000);
                      });
                    }}
                  >
                    <ListItemIcon
                      sx={{
                        minWidth: 0,
                        mr: open ? 3 : 'auto',
                        justifyContent: 'center',
                      }}
                    >
                      <ExitToAppIcon />
                    </ListItemIcon>
                    <ListItemText
                      primary={'Logout'}
                      sx={{ opacity: open ? 1 : 0 }}
                    />
                  </ListItemButton>
                </ListItem>
              ) : (
                ''
              )}
            </List>
            {loggedInUser.roles.includes('Admin') ? (
              <ListItem
                disablePadding
                sx={{ display: 'block' }}
              >
                <ListItem
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                >
                  <ListItemIcon
                    sx={{
                      minWidth: 0,
                      mr: open ? 3 : 'auto',
                      justifyContent: 'center',
                    }}
                  >
                    <LocalPoliceIcon />
                  </ListItemIcon>
                  <ListItemText
                    primary={'Admin View'}
                    sx={{ opacity: open ? 1 : 0 }}
                  />
                </ListItem>
              </ListItem>
            ) : (
              ''
            )}
          </Drawer>
        </div>
        <Box sx={{ flexGrow: 1 }}>
          <AppBar position="static">
            <Toolbar>
              <IconButton
                size="large"
                edge="start"
                aria-label="menu"
                onClick={() => toggleDrawer(true)}
              >
                <MenuIcon />
              </IconButton>

              <Box sx={{ flexGrow: 1, textAlign: 'center', mr: '24px' }}>
                {darkMode ? (
                  <img
                    style={{ cursor: 'pointer' }}
                    onClick={() => navigate('/')}
                    className="nav-drawer-header-logo"
                    src={MainLogoWhite}
                    alt=""
                  />
                ) : (
                  <img
                    style={{ cursor: 'pointer' }}
                    onClick={() => navigate('/')}
                    className="nav-drawer-header-logo"
                    src={MainLogoBlack}
                    alt=""
                  />
                )}
              </Box>
            </Toolbar>
          </AppBar>
        </Box>
      </>
    );
  }

  return (
    <>
      <div>
        <Drawer
          anchor="left"
          open={open}
          onClose={() => toggleDrawer(false)}
        >
          <div>
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                onClick={() => setOpen(false)}
                sx={{
                  px: 2.5,
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <CloseIcon />
                </ListItemIcon>
                <ListItemText primary={'Close'} />
              </ListItemButton>
            </ListItem>
          </div>
          <Divider />
          <List
            sx={{
              display: 'flex',
              height: '100%',
              flexDirection: 'column',
              justifyContent: 'between',
            }}
          >
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => {
                  navigate('/');
                  setOpen(false);
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <HomeIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'Home'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => {
                  navigate('profile/me');
                  setOpen(false);
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <PersonIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'My Profile'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => {
                  navigate('allprofiles');
                  setOpen(false);
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <PeopleIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'All Profiles'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => {
                  navigate('feed');
                  setOpen(false);
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <RssFeedIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'My Feed'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>

            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => handleDarkModeClick()}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  {darkMode ? <LightModeIcon /> : <DarkModeIcon />}
                </ListItemIcon>
                <ListItemText
                  primary={'Theme'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => {
                  navigate('settings');
                  setOpen(false);
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <SettingsIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'Settings'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItemButton>
            </ListItem>
            {loggedInUser ? (
              <ListItem
                disablePadding
                sx={{ display: 'block' }}
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={(e) => {
                    e.preventDefault();
                    setOpen(false);
                    logout().then(() => {
                      setTimeout(() => {
                        setLoggedInUser(null);
                        setOpen(false);
                        navigate('/');
                      }, 1000);
                    });
                  }}
                >
                  <ListItemIcon
                    sx={{
                      minWidth: 0,
                      mr: open ? 3 : 'auto',
                      justifyContent: 'center',
                    }}
                  >
                    <ExitToAppIcon />
                  </ListItemIcon>
                  <ListItemText
                    primary={'Logout'}
                    sx={{ opacity: open ? 1 : 0 }}
                  />
                </ListItemButton>
              </ListItem>
            ) : (
              ''
            )}
          </List>
          {loggedInUser.roles.includes('Admin') ? (
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              <ListItem
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                  <LocalPoliceIcon />
                </ListItemIcon>
                <ListItemText
                  primary={'Admin'}
                  sx={{ opacity: open ? 1 : 0 }}
                />
              </ListItem>
            </ListItem>
          ) : (
            ''
          )}
        </Drawer>
      </div>
      <Box sx={{ flexGrow: 1 }}>
        <AppBar position="fixed">
          <Toolbar>
            <IconButton
              size="large"
              edge="start"
              aria-label="menu"
              onClick={() => toggleDrawer(true)}
              sx
            >
              <MenuIcon />
            </IconButton>

            <Box sx={{ flexGrow: 1, textAlign: 'center', mr: '24px' }}>
              {darkMode ? (
                <img
                  style={{ cursor: 'pointer' }}
                  onClick={() => navigate('/')}
                  className="nav-header-logo-small"
                  src={NavLogoWhite}
                  alt=""
                />
              ) : (
                <img
                  style={{ cursor: 'pointer' }}
                  onClick={() => navigate('/')}
                  className="nav-header-logo-small"
                  src={NavLogoBlack}
                  alt=""
                />
              )}
            </Box>
          </Toolbar>
        </AppBar>
      </Box>
    </>
  );
};
