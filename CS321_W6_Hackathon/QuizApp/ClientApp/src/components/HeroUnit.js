import React from 'react';

import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

const useStyles = makeStyles((theme) => ({
  heroContent: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(8, 0, 6),
  },
  heroButtons: {
    marginTop: theme.spacing(4),
  },
}));

export default ({
  heading = '',
  content = '',
  primaryButtonText = '',
  secondaryButtonText = '',
  primaryButtonAction = null,
  secondaryButtonAction = null
}) => {
  const classes = useStyles();
  return (
    <div className={classes.heroContent}>
      <Container maxWidth="sm">
        <Typography
          component="h1"
          variant="h2"
          align="center"
          color="textPrimary"
          gutterBottom
        >
          {heading}
        </Typography>
        <Typography variant="h5" align="center" color="textSecondary" paragraph>
          {content}
        </Typography>
        <div className={classes.heroButtons}>
          <Grid container spacing={2} justify="center">
            <Grid item>
              <Button variant="contained" color="primary" onClick={primaryButtonAction}>
                {primaryButtonText}
              </Button>
            </Grid>
            <Grid item>
              <Button variant="outlined" color="primary" onClick={secondaryButtonAction}>
                {secondaryButtonText}
              </Button>
            </Grid>
          </Grid>
        </div>
      </Container>
    </div>
  );
};
