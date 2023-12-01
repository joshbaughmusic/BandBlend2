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
import { useEffect, useState } from 'react';
import { fetchAllUsersWithProfiles } from '../../../../managers/profileManager.js';

export const AllProfilesSearchSortFilter = ({
  setProfiles,
  setProfileCount,
  page,
  setPage,
  amountPerPage,
  searchTerms,
  setSearchTerms,
  filterTerms,
  setFilterTerms,
  sortTerms,
  setSortTerms,
}) => {
  const [isClear, setIsClear] = useState(true);

  const getProfilesByTerms = () => {
    fetchAllUsersWithProfiles(
      page,
      amountPerPage,
      searchTerms,
      filterTerms,
      sortTerms
    ).then((res) => {
      setProfiles(res.profiles);
      setProfileCount(res.totalCount);
    });
  };

  const handleSearchClick = () => {
    getProfilesByTerms();
  };

  useEffect(() => {
    getProfilesByTerms();
  }, [filterTerms, sortTerms]);

  useEffect(() => {
    if (isClear) {
      getProfilesByTerms();
    }
  }, [isClear]);

  useEffect(() => {
    if (searchTerms === '') {
      setIsClear(true);
    } else {
      setIsClear(false);
    }
  }, [searchTerms]);

  return (
    <Grid container className='allprofiles-sortsearchfilter-container'>
      <Grid
        item
        xs={6}
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
                  <IconButton
                    edge="end"
                    onClick={handleSearchClick}
                  >
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
        xs={3}
      >
        <FormControl sx={{ width: '100%' }}>
          <InputLabel id="filter-label">Filter</InputLabel>
          <Select
            labelId="filter-label"
            id="filter"
            value={filterTerms}
            label="Filter"
            onChange={(e) => {
              setFilterTerms(e.target.value)
              setPage(1)
            }

            } 
          >
            <MenuItem value={null}>--</MenuItem>
            <MenuItem value={'saved'}>Saved Only</MenuItem>
            <MenuItem value={'musicians'}>Musicians Only</MenuItem>
            <MenuItem value={'bands'}>Bands Only</MenuItem>
          </Select>
        </FormControl>
      </Grid>
      <Grid
        item
        xs={3}
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
            <MenuItem value={null}>--</MenuItem>
            <MenuItem value={'naz'}>Name: A - Z</MenuItem>
            <MenuItem value={'nza'}>Name: Z - A</MenuItem>
            <MenuItem value={'caz'}>City: A - Z</MenuItem>
            <MenuItem value={'cza'}>City: Z - A</MenuItem>
            <MenuItem value={'saz'}>State: A - Z</MenuItem>
            <MenuItem value={'sza'}>State: Z - A</MenuItem>
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
