import {
  FormControl,
  Grid,
  IconButton,
  InputAdornment,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from '@mui/material';
import './AllProfilesSearchSortFilter.css';
import SearchIcon from '@mui/icons-material/Search';
import { useState } from 'react';

export const AllProfilesSearchSortFilter = ({
  profiles,
  setProfiles,
  profileCount,
  setProfileCount,
}) => {

  const [searchTerms, setSearchTerms] = useState('');
  const [filterTerms, setFilterTerms] = useState('');
  const [sortTerms, setSortTerms] = useState('');

  return (
    <Grid container>
      <Grid
        item
        xs={8}
      >
        <FormControl sx={{ width: '100%' }}>
          <InputLabel id="search-label" />
          <TextField
            labelId="search-label"
            id="search"
            value={searchTerms}
            label="Search"
            onChange={(e) => setSearchTerms(e.target.value)}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton edge="end">
                    <SearchIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
          />
        </FormControl>
      </Grid>
      <Grid
        item
        xs={2}
      >
        <FormControl sx={{ width: '100%' }}>
          <InputLabel id="filter-label">Filter</InputLabel>
          <Select
            labelId="filter-label"
            id="filter"
            value={filterTerms}
            label="Filter"
            onChange={(e) => setFilterTerms(e.target.value)}
          >
            <MenuItem value={'saved'}>Saved Only</MenuItem>
            <MenuItem value={'musicians'}>Musicians Only</MenuItem>
            <MenuItem value={'bands'}>Bands Only</MenuItem>
          </Select>
        </FormControl>
      </Grid>
      <Grid
        item
        xs={2}
      >
        <FormControl sx={{ width: '100%' }}>
          <InputLabel id="sort-label">Sort</InputLabel>
          <Select
            labelId="sort-label"
            id="sort"
            value={sortTerms}
            label="Sort"
            onChange={(e) => setSortTerms(e.target.value)}
          >
            <MenuItem value={'naz'}>Name: A - Z</MenuItem>
            <MenuItem value={'nza'}>Name: Z - A</MenuItem>
            <MenuItem value={'caz'}>City: A - Z</MenuItem>
            <MenuItem value={'cza'}>City: Z - A</MenuItem>
            <MenuItem value={'piaz'}>Instrument: A - Z</MenuItem>
            <MenuItem value={'piza'}>Instrument: Z - A</MenuItem>
            <MenuItem value={'pgaz'}>Genre: A - Z</MenuItem>
            <MenuItem value={'pgza'}>Genre: Z - A</MenuItem>
          </Select>
        </FormControl>
      </Grid>
    </Grid>
  );
};
