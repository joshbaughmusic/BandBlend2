import { CssBaseline, ThemeProvider, createTheme } from '@mui/material';
import { createContext, useContext, useState } from 'react';
import './AdditionalThemeCss.css';

export const ThemeContext = createContext({});

export const useThemeContext = () => {
  return useContext(ThemeContext);
};

export const themeLight = createTheme({
  components: {
    // MuiAlert: {
    //   styleOverrides: {
    //     standardSuccess: {
    //       backgroundColor: 'white',
    //     },
    //     standardError: {
    //       backgroundColor: 'red',
    //       color: 'white',
    //     }
    //   },
    // },
    MuiCard: {
      styleOverrides: {
        root: {
          boxShadow:
            '0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 6px 10px 0px rgba(0, 0, 0, 0.14), 0px 1px 18px 0px rgba(0, 0, 0, 0.12)',
        },
      },
    },
    MuiPaper: {
      styleOverrides: {
        root: {
          boxShadow:
            '0px 3px 5px -1px rgba(0, 0, 0, 0.1), 0px 6px 10px 0px rgba(0, 0, 0, 0.08), 0px 1px 12px 0px rgba(0, 0, 0, 0.06)',
        },
      },
    },
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          backgroundImage: `linear-gradient(135deg, rgba(238,233,233,1) 23%, rgba(241,241,241,1) 47%, rgba(238,231,231,1) 79%)`,
          backgroundRepeat: 'no-repeat',
          backgroundAttachment: 'fixed',
        },
      },
    },
  },
  palette: {
    background: {
      default: '#F1F1F1',
      paper: '#E3E3E3',
    },
    text: {
      primary: '#1D2625',
    },
    primary: {
      main: '#8C4A4A',
      dark: '#602d2db4',
      light: '#9d5d5c',
    },
    // secondary: {
    //   main: '#1D2625',
    //   dark: '#001220',
    //   light: '#4F5957',
    // },
  },
});

export const themeDark = createTheme({
  components: {
    // MuiAlert: {
    //   styleOverrides: {
    //     standardSuccess: {
    //       backgroundColor: 'white',
    //     },
    //     standardError: {
    //       backgroundColor: 'red',
    //       color: 'white',
    //     },
    //   },
    // },
    // MuiSvgIcon: {
    //   styleOverrides: {
    //     root: {
    //       color: '#c5c7c5',
    //     },
    //   },
    // },
    MuiCard: {
      styleOverrides: {
        root: {
          boxShadow:
            '0px 3px 5px -1px rgba(0, 0, 0, 0.15), 0px 6px 10px 0px rgba(0, 0, 0, 0.12), 0px 1px 12px 0px rgba(0, 0, 0, 0.1)',
        },
      },
    },
    MuiPaper: {
      styleOverrides: {
        root: {
          boxShadow:
            '0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 6px 10px 0px rgba(0, 0, 0, 0.14), 0px 1px 18px 0px rgba(0, 0, 0, 0.12)',
        },
      },
    },
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          backgroundImage: `linear-gradient(135deg, rgba(18,11,11,1) 0%, rgba(29,26,26,1) 3%, rgba(23,22,22,1) 49%, rgba(23,22,22,1) 100%)`,
          backgroundRepeat: 'no-repeat',
          backgroundAttachment: 'fixed',
        },
      },
    },
  },
  palette: {
    mode: 'dark',
    background: {
      default: '#151515',
      // paper: '#8C4A4A',
    },
    // text: {
    //   primary: '#c5c7c5',
    // },
    primary: {
      main: '#8C4A4A',
      dark: '#602d2db4',
      light: '#9d5d5c',
    },
    // secondary: {
    //   main: '#1D2625',
    //   dark: '#001220',
    //   light: '#4F5957',
    // },
  },
});

export const ThemeProviderContext = ({ children }) => {
  const [darkMode, setDarkMode] = useState(
    localStorage.getItem('darkMode') ? true : false
  );
  const handleDarkModeClick = () => {
    if (darkMode) {
      localStorage.removeItem('darkMode');
    } else {
      localStorage.setItem('darkMode', true);
    }
    setDarkMode(!darkMode);
  };

  return (
    <ThemeContext.Provider
      value={{ handleDarkModeClick, darkMode, setDarkMode }}
    >
      <ThemeProvider theme={darkMode ? themeDark : themeLight}>
        <CssBaseline />
        {children}
      </ThemeProvider>
    </ThemeContext.Provider>
  );
};
