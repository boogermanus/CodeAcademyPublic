import React from 'react';

import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles((theme) => ({
  cardGrid: {
    paddingTop: theme.spacing(2),
    paddingBottom: theme.spacing(2),
  },
}));

export default ({ children = [] }) => {
  const classes = useStyles();
  return (
    <Container className={classes.cardGrid} maxWidth="lg">
      <Grid container spacing={4}>
        {children.map((child, index) => (
          <Grid key={index} item xs={12} sm={6} md={4}>
            {child}
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};
