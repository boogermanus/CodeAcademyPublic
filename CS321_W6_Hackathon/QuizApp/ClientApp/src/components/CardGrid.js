import React from 'react';

import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Card from './Card';

const useStyles = makeStyles((theme) => ({
  cardGrid: {
    paddingTop: theme.spacing(2),
    paddingBottom: theme.spacing(2),
  },
}));

export default ({ items = [], component = null }) => {
  const classes = useStyles();
  const CardComponent = component;
  // const classes = useStyles();
  return (
    <Container className={classes.cardGrid} maxWidth="lg">
      <Grid container spacing={4}>
        {items.map((item, index) => {
          return CardComponent ? <CardComponent key={index} item={item} /> : <Card key={index} {...item} />;
        })}
      </Grid>
    </Container>
  );
};
