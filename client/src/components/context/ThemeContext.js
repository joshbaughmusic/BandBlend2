import { Alert, Theme, createTheme } from '@mui/material';
import { createContext, useContext } from 'react';

export const ThemeContext = createContext({});

export const useTheme = () => {
  return useContext(ThemeContext);
};

export const theme = createTheme({
  palette: {
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

export const ThemeProvider = ({ children }) => {
  return (
    <ThemeContext.Provider
      value={{
        theme,
      }}
    >
      {children}
    </ThemeContext.Provider>
  );
};
