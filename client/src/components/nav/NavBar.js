import { Button } from '@mui/material';
import { useState } from 'react';
import { NavLink as RRNavLink } from 'react-router-dom';

export default function NavBar({ loggedInUser, setLoggedInUser }) {

  return (
    <div>
      <Button>
        Home
      </Button>
      <Button>
        My Profile
      </Button>
      <Button>
        All Profiles
      </Button>
      <Button>
        My Feed
      </Button>
      <Button>
        Settings
      </Button>
    </div>
  );
}
