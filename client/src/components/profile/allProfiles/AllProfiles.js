import { useState, useEffect } from 'react';
import {
  Container,
  FormControl,
  InputLabel,
  MenuItem,
  Pagination,
  Select,
} from '@mui/material';
import { fetchAllUsersWithProfiles } from '../../../managers/profileManager.js';
import './AllProfiles.css';
import { AllProfilesCard } from './AllProfilesCard.js';

export const AllProfiles = () => {
  const [profiles, setProfiles] = useState();
  const [profileCount, setProfileCount] = useState(0);
  const [page, setPage] = useState(1);
  const [amountPerPage, setAmountPerPage] = useState(5);

  const getAllUsersWithProfiles = () => {
    fetchAllUsersWithProfiles(page, amountPerPage).then((res) => {
      setProfiles(res.profiles);
      setProfileCount(res.totalCount);
    });
  };

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const handleAmountPerPageChange = (e) => {
    setAmountPerPage(e.target.value);
    setPage(1)
  };

  useEffect(() => {
    getAllUsersWithProfiles();
  }, [page, amountPerPage]);

  if (!profiles) {
    return null;
  }

  return (
    <>
      <Container className="allprofiles-container-all">
        <div className="allprofiles-container-nopage">
          <div className="allprofiles-searchsortfilter-container">
            Search/Filter/Sort placeholder
          </div>
          <div className="allprofiles-profile-list-container">
            {profiles.map((p, index) => (
              <AllProfilesCard
                profile={p}
                key={index}
              />
            ))}
          </div>
        </div>
        <div className="pagination-allprofiles-container">
          <Pagination
            count={Math.ceil(profileCount / amountPerPage)}
            page={page}
            onChange={handlePageChange}
          />
          <FormControl
            sx={{ m: 1, minWidth: 90 }}
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
