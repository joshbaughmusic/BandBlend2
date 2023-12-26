import {
  CssBaseline,
  ThemeProvider,
  createTheme,
} from '@mui/material';
import { createContext, useContext, useState } from 'react';
import "./AdditionalThemeCss.css"

export const ThemeContext = createContext({});

export const useThemeContext = () => {
  return useContext(ThemeContext);
};

export const themeLight = createTheme({
  palette: {
    background: {
      default: 'white',
      paper:"#E3E3E3"
    },
    text: {
      primary: '#1D2625',
    },
    primary: {
      main: '#8C4A4A',
      dark: '#602d2db4',
      light: '#9d5d5c',
    },
    secondary: {
      main: '#1D2625',
      dark: '#001220',
      light: '#4F5957',
    },
  },
});

export const themeDark = createTheme({
  palette: {
    background: {
      default: '#222222',
      paper: '#8C4A4A',
    },
    text: {
      primary: '#000000',
    },
    primary: {
      main: '#1D2625',
      dark: '#602d2db4',
      light: '#9d5d5c',
    },
    secondary: {
      main: '#1D2625',
      dark: '#001220',
      light: '#4F5957',
    },
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
