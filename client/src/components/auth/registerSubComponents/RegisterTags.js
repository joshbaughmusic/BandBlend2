import { useEffect, useState } from 'react';
import {
  Checkbox,
  Collapse,
  Divider,
  FormControlLabel,
  FormGroup,
  Grid,
  IconButton,
  Typography,
  useMediaQuery,
} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { styled } from '@mui/material/styles';
import { fetchTags } from '../../../managers/tagsManager.js';
import { useSnackBar } from '../../context/SnackBarContext.js';
import { useTheme } from '@emotion/react';

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

export const RegisterTags = ({
  selectedTags,
  setSelectedTags,
  selectedTagsCount,
  setSelectedTagsCount,
}) => {
  const [expanded, setExpanded] = useState(false);
  const [tags, setTags] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getTags = () => {
    fetchTags().then(setTags);
  };

  useEffect(() => {
    getTags();
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
    if (selectedTagsCount < 3) {
      if (e.target.checked) {
        setSelectedTags([...selectedTags, parseInt(e.target.value)]);
        setSelectedTagsCount(selectedTagsCount + 1);
      } else {
        // User is unchecking an item
        setSelectedTags(
          selectedTags.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedTagsCount(selectedTagsCount - 1);
      }
    } else {
      if (!e.target.checked) {
        // User is unchecking an item
        setSelectedTags(
          selectedTags.filter((pt) => pt !== parseInt(e.target.value))
        );
        setSelectedTagsCount(selectedTagsCount - 1);
      } else {
        // User is trying to check more items beyond the limit
        setSnackBarMessage('No more than 3 tags may be selected.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      }
    }
  };

  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('md'));

  if (!tags) {
    return (
      <>
        <div className="register-section-header">
          <Typography variant="h6">{`Tags (required)`}</Typography>
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
        <Typography variant="h6">{`Tags (required)`}</Typography>
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
          Pick three tags that best describe you:
        </Typography>
        {
          mediaQuerySmall ?

        <Grid
          container
          direction="row"
          justifyContent="center"
          alignItems="center"
        >
          <Grid item>
            <FormGroup>
              {tags.map((sg, index) => (
                <FormControlLabel
                  key={index}
                  control={
                    <Checkbox
                      name={sg.name}
                      checked={
                        selectedTags.length > 0
                          ? selectedTags.some((pt) => pt === sg.id)
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
        :
        <Grid
          container
          direction="row"
          justifyContent="center"
          alignItems="center"
        >
          <Grid item>
            <FormGroup>
              {tags.slice(0, 5).map((sg, index) => (
                <FormControlLabel
                  key={index}
                  control={
                    <Checkbox
                      name={sg.name}
                      checked={
                        selectedTags.length > 0
                          ? selectedTags.some((pt) => pt === sg.id)
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
              {tags.slice(5, 10).map((sg, index) => (
                <FormControlLabel
                  key={index}
                  control={
                    <Checkbox
                      name={sg.name}
                      checked={
                        selectedTags.length > 0
                          ? selectedTags.some((pt) => pt === sg.id)
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
              {tags.slice(10, 15).map((sg, index) => (
                <FormControlLabel
                  key={index}
                  control={
                    <Checkbox
                      name={sg.name}
                      checked={
                        selectedTags.length > 0
                          ? selectedTags.some((pt) => pt === sg.id)
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
        }

      </Collapse>
    </>
  );
};
