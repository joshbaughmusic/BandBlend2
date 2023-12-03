import { useEffect, useState } from 'react';
import {
  Checkbox,
  Collapse,
  Divider,
  FormControl,
  FormControlLabel,
  FormGroup,
  Grid,
  IconButton,
  InputLabel,
  OutlinedInput,
  Stack,
  Typography,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { styled } from '@mui/material/styles';
import { fetchSubGenres } from '../../../managers/subGenresManager.js';
import { useSnackBar } from '../../context/SnackBarContext.js';

const ExpandMore = styled((props) => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
  marginLeft: 'auto',
  transition: theme.transitions.create('transform', {
    duration: theme.transitions.duration.shortest,
  }),
}));

export const RegisterSubGenres = ({
  selectedSubGenres,
  setSelectedSubGenres,
  selectedSubGenresCount,
  setSelectedSubGenresCount,
}) => {
  const [expanded, setExpanded] = useState(false);
  const [subGenres, setSubGenres] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getSubGenres = () => {
    fetchSubGenres().then(setSubGenres);
  };

  useEffect(() => {
    getSubGenres();
  }, []);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  const arraysContainSameElements = (array1, array2) => {
    const set1 = new Set(array1);
    const set2 = new Set(array2);
    if (set1.size !== set2.size) {
      return false;
    }
    for (const element of set1) {
      if (!set2.has(element)) {
        return false;
      }
    }
    return true;
  };

  const handleCheck = (e) => {
    if (selectedSubGenresCount < 3) {
      if (e.target.checked) {
        setSelectedSubGenres([...selectedSubGenres, parseInt(e.target.value)]);
        setSelectedSubGenresCount(selectedSubGenresCount + 1);
      } else {
        // User is unchecking an item
        setSelectedSubGenres(
          selectedSubGenres.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedSubGenresCount(selectedSubGenresCount - 1);
      }
    } else {
      if (!e.target.checked) {
        // User is unchecking an item
        setSelectedSubGenres(
          selectedSubGenres.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedSubGenresCount(selectedSubGenresCount - 1);
      } else {
        // User is trying to check more items beyond the limit
        setSnackBarMessage('No more than 3 subgenres may be selected.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      }
    }
  };

  if (!subGenres) {
    return (
      <>
        <div className="register-section-header">
          <Typography variant="h6">{`SubGenres (required)`}</Typography>
          <ExpandMore
            expand={expanded}
            onClick={handleExpandClick}
            aria-expanded={expanded}
            aria-label="show more"
          >
            <ExpandMoreIcon />
          </ExpandMore>
        </div>
        <Divider />
      </>
    );
  }

  return (
    <>
      <div className="register-section-header">
        <Typography variant="h6">{`SubGenres (required)`}</Typography>
        <ExpandMore
          expand={expanded}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <ExpandMoreIcon />
        </ExpandMore>
      </div>
      <Divider />
      <Collapse
        in={expanded}
        timeout="auto"
        unmountOnExit
      >
        <Typography
          textAlign="center"
          sx={{ m: 2, fontWeight: 'bold' }}
        >
          Pick three other genres that best describe you:
        </Typography>
        
          <Grid
            container
            direction="row"
            justifyContent="center"
            alignItems="center"
          >
            <Grid item>
              <FormGroup>
                {subGenres.slice(0, 12).map((sg, index) => (
                  <FormControlLabel
                    key={index}
                    control={
                      <Checkbox
                        name={sg.name}
                        checked={
                          selectedSubGenres.length > 0
                            ? selectedSubGenres.some((pt) => pt === sg.id)
                            : ''
                        }
                        onChange={handleCheck}
                        value={sg.id}
                      />
                    }
                    label={sg.name}
                  />
                ))}
              </FormGroup>
            </Grid>
            <Grid item>
              <FormGroup>
                {subGenres.slice(12, 24).map((sg, index) => (
                  <FormControlLabel
                    key={index}
                    control={
                      <Checkbox
                        name={sg.name}
                        checked={
                          selectedSubGenres.length > 0
                            ? selectedSubGenres.some((pt) => pt === sg.id)
                            : ''
                        }
                        onChange={handleCheck}
                        value={sg.id}
                      />
                    }
                    label={sg.name}
                  />
                ))}
              </FormGroup>
            </Grid>
            <Grid item>
              <FormGroup>
                {subGenres.slice(24, 36).map((sg, index) => (
                  <FormControlLabel
                    key={index}
                    control={
                      <Checkbox
                        name={sg.name}
                        checked={
                          selectedSubGenres.length > 0
                            ? selectedSubGenres.some((pt) => pt === sg.id)
                            : ''
                        }
                        onChange={handleCheck}
                        value={sg.id}
                      />
                    }
                    label={sg.name}
                  />
                ))}
              </FormGroup>
            </Grid>
          </Grid>
      </Collapse>
    </>
  );
};
