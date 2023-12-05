import { useState, useEffect } from 'react';
import {
  Container,
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
  Typography,
} from '@mui/material';
import { fetchAllUsersWithProfiles } from '../../../managers/profileManager.js';
import './AllProfiles.css';
import { AllProfilesCard } from './AllProfilesCard.js';
import { AllProfilesSearchSortFilter } from './allProfilesSearchSortFilter/AllProfilesSearchSortFilter.js';

export const AllProfiles = () => {
  const [profiles, setProfiles] = useState();
  const [profileCount, setProfileCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);
  const [searchTerms, setSearchTerms] = useState('');
  const [filterTerms, setFilterTerms] = useState('');
  const [sortTerms, setSortTerms] = useState('');

  const getAllUsersWithProfiles = () => {
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

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1);
  };

  useEffect(() => {
    getAllUsersWithProfiles();
  }, [page, amountPerPage]);

  if (!profiles) {
    return null;
  }

  return (
    <>
      <Container>
        <div>
          <AllProfilesSearchSortFilter
            setProfiles={setProfiles}
            setProfileCount={setProfileCount}
            page={page}
            setPage={setPage}
            amountPerPage={amountPerPage}
            searchTerms={searchTerms}
            setSearchTerms={setSearchTerms}
            filterTerms={filterTerms}
            setFilterTerms={setFilterTerms}
            sortTerms={sortTerms}
            setSortTerms={setSortTerms}
          />
          <div>
            {profiles.length === 0 ? (
              <div className="allprofiles-noresults">
                <Typography>No matching results...</Typography>
              </div>
            ) : (
              profiles.map((p, index) => (
                <AllProfilesCard
                  profile={p}
                  key={`${p.id}-${index}`}
                  getAllUsersWithProfiles={getAllUsersWithProfiles}
                />
              ))
            )}
          </div>
        </div>
        <div className="pagination-allprofiles-container">
          <Pagination
            count={Math.ceil(profileCount / amountPerPage)}
            page={page}
            onChange={handlePageChange}
          />
          <FormControl
            sx={{ m: 1, minWidth: 75 }}
            size="small"
          >
            <InputLabel id="amountPerPage-select-label">Per Page</InputLabel>
            <Select
              labelId="amountPerPage-select-label"
              id="amountPerPage-select"
              value={amountPerPage}
              label="Age"
              onChange={handleAmountPerPageChange}
            >
              <MenuItem value={5}>5</MenuItem>
              <MenuItem value={10}>10</MenuItem>
              <MenuItem value={20}>20</MenuItem>
            </Select>
          </FormControl>
        </div>
      </Container>
    </>
  );
};
