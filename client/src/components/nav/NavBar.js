import * as React from 'react';
import { styled, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import MuiDrawer from '@mui/material/Drawer';
import MuiAppBar from '@mui/material/AppBar';
import List from '@mui/material/List';
import CssBaseline from '@mui/material/CssBaseline';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import MailIcon from '@mui/icons-material/Mail';
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
import NavLogoBlack from '../../images/Bandblend_Logos/Logo-nav-black.png';
import NavLogoWhite from '../../images/Bandblend_Logos/Logo-nav-white.png';
import MainLogoBlack from '../../images/Bandblend_Logos/Logo-top-black.png';
import MainLogoWhite from '../../images/Bandblend_Logos/Logo-top-white.png';
import { Tooltip } from '@mui/material';
import { logout } from '../../managers/authManager.js';
import { useThemeContext } from '../context/ThemeContext.js';

const drawerWidth = 240;

const openedMixin = (theme) => ({
  width: drawerWidth,
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.enteringScreen,
  }),
  overflowX: 'hidden',
});

const closedMixin = (theme) => ({
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  overflowX: 'hidden',
  width: `calc(${theme.spacing(7)} + 1px)`,
  [theme.breakpoints.up('sm')]: {
    width: `calc(${theme.spacing(8)} + 1px)`,
  },
});

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'flex-end',
  padding: theme.spacing(0, 1),
  ...theme.mixins.toolbar,
}));

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})(({ theme, open }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, {
  shouldForwardProp: (prop) => prop !== 'open',
})(({ theme, open }) => ({
  width: drawerWidth,
  flexShrink: 0,
  whiteSpace: 'nowrap',
  boxSizing: 'border-box',
  ...(open && {
    ...openedMixin(theme),
    '& .MuiDrawer-paper': openedMixin(theme),
  }),
  ...(!open && {
    ...closedMixin(theme),
    '& .MuiDrawer-paper': closedMixin(theme),
  }),
}));

export const NavBar = ({ loggedInUser, setLoggedInUser }) => {
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate();
  const { darkMode, handleDarkModeClick } = useThemeContext();

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  if (!loggedInUser) {
    return null;
  }

  if (loggedInUser.accountBanned) {
    return (
      <Box sx={{ display: 'flex' }}>
        <CssBaseline />

        <Drawer
          variant="permanent"
          open={open}
          // PaperProps={{
          //   sx: {
          //     backgroundColor: 'grey',
          //   },
          // }}
        >
          <DrawerHeader>
            {open ? (
              <>
                {darkMode ? (
                  <img
                    className="nav-drawer-header-logo"
                    src={MainLogoWhite}
                    alt=""
                  />
                ) : (
                  <img
                    className="nav-drawer-header-logo"
                    src={MainLogoBlack}
                    alt=""
                  />
                )}
                <IconButton onClick={handleDrawerClose}>
                  {theme.direction === 'rtl' ? (
                    <ChevronRightIcon />
                  ) : (
                    <ChevronLeftIcon />
                  )}
                </IconButton>
              </>
            ) : (
              <Tooltip
                title="Expand"
                placement="right"
              >
                <IconButton
                  color="inherit"
                  aria-label="open drawer"
                  onClick={handleDrawerOpen}
                  edge="start"
                  sx={{
                    margin: '0 auto',

                    ...(open && { display: 'none' }),
                  }}
                >
                  {/* <MenuIcon /> */}
                  {darkMode ? (
                    <img
                      className="navlogo"
                      src={NavLogoWhite}
                      alt=""
                    />
                  ) : (
                    <img
                      className="navlogo"
                      src={NavLogoBlack}
                      alt=""
                    />
                  )}
                </IconButton>
              </Tooltip>
            )}
          </DrawerHeader>
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
                {open ? (
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
                ) : (
                  <Tooltip
                    title="Logout"
                    placement="right"
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
                  </Tooltip>
                )}
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
              {open ? (
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
              ) : (
                <Tooltip
                  title="Admin View"
                  placement="right"
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
                      primary={'Settings'}
                      sx={{ opacity: open ? 1 : 0 }}
                    />
                  </ListItem>
                </Tooltip>
              )}
            </ListItem>
          ) : (
            ''
          )}
        </Drawer>
        <Box
          component="main"
          sx={{ flexGrow: 1, p: 3 }}
        >
          <DrawerHeader />
        </Box>
      </Box>
    );
  }

  return (
    <Box sx={{ display: 'flex' }}>
      <CssBaseline />

      <Drawer
        variant="permanent"
        open={open}
        // PaperProps={{
        //   sx: {
        //     backgroundColor: 'grey',
        //   },
        // }}
      >
        <DrawerHeader>
          {open ? (
            <>
              {darkMode ? (
                <img
                  className="nav-drawer-header-logo"
                  src={MainLogoWhite}
                  alt=""
                />
              ) : (
                <img
                  className="nav-drawer-header-logo"
                  src={MainLogoBlack}
                  alt=""
                />
              )}
              <IconButton onClick={handleDrawerClose}>
                {theme.direction === 'rtl' ? (
                  <ChevronRightIcon />
                ) : (
                  <ChevronLeftIcon />
                )}
              </IconButton>
            </>
          ) : (
            <Tooltip
              title="Expand"
              placement="right"
            >
              <IconButton
                color="inherit"
                aria-label="open drawer"
                onClick={handleDrawerOpen}
                edge="start"
                sx={{
                  margin: '0 auto',

                  ...(open && { display: 'none' }),
                }}
              >
                {/* <MenuIcon /> */}
                {darkMode ? (
                  <img
                    className="navlogo"
                    src={NavLogoWhite}
                    alt=""
                  />
                ) : (
                  <img
                    className="navlogo"
                    src={NavLogoBlack}
                    alt=""
                  />
                )}
              </IconButton>
            </Tooltip>
          )}
        </DrawerHeader>
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
            {open ? (
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => navigate('/')}
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
            ) : (
              <Tooltip
                title="Home"
                placement="right"
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={() => navigate('/')}
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
              </Tooltip>
            )}
          </ListItem>
          <ListItem
            disablePadding
            sx={{ display: 'block' }}
          >
            {open ? (
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => navigate('profile/me')}
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
            ) : (
              <Tooltip
                title="My Profile"
                placement="right"
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={() => navigate('profile/me')}
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
              </Tooltip>
            )}
          </ListItem>
          <ListItem
            disablePadding
            sx={{ display: 'block' }}
          >
            {open ? (
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => navigate('allprofiles')}
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
            ) : (
              <Tooltip
                title="All Profiles"
                placement="right"
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={() => navigate('allprofiles')}
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
              </Tooltip>
            )}
          </ListItem>
          <ListItem
            disablePadding
            sx={{ display: 'block' }}
          >
            {open ? (
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => navigate('feed')}
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
            ) : (
              <Tooltip
                title="My Feed"
                placement="right"
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={() => navigate('feed')}
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
              </Tooltip>
            )}
          </ListItem>

          <ListItem
            disablePadding
            sx={{ display: 'block' }}
          >
            {open ? (
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
            ) : (
              <Tooltip
                title="Theme"
                placement="right"
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
              </Tooltip>
            )}
          </ListItem>
          <ListItem
            disablePadding
            sx={{ display: 'block' }}
          >
            {open ? (
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                onClick={() => navigate('settings')}
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
            ) : (
              <Tooltip
                title="Settings"
                placement="right"
              >
                <ListItemButton
                  sx={{
                    minHeight: 48,
                    justifyContent: open ? 'initial' : 'center',
                    px: 2.5,
                  }}
                  onClick={() => navigate('settings')}
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
              </Tooltip>
            )}
          </ListItem>
          {loggedInUser ? (
            <ListItem
              disablePadding
              sx={{ display: 'block' }}
            >
              {open ? (
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
              ) : (
                <Tooltip
                  title="Logout"
                  placement="right"
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
                </Tooltip>
              )}
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
            {open ? (
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
            ) : (
              <Tooltip
                title="Admin View"
                placement="right"
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
                    primary={'Settings'}
                    sx={{ opacity: open ? 1 : 0 }}
                  />
                </ListItem>
              </Tooltip>
            )}
          </ListItem>
        ) : (
          ''
        )}
      </Drawer>
      <Box
        component="main"
        sx={{ flexGrow: 1, p: 3 }}
      >
        <DrawerHeader />
      </Box>
    </Box>
  );
};
