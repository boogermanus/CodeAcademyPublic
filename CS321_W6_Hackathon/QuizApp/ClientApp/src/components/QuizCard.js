import React from 'react';
import { Link } from 'react-router-dom';

import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';

import Avatar from '@material-ui/core/Avatar';
import { deepPurple } from '@material-ui/core/colors';

const useStyles = makeStyles((theme) => ({
  card: {
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
  },
  cardMedia: {
    paddingTop: '56.25%', // 16:9
  },
  cardContent: {
    flexGrow: 1,
  },
  heading: {
    marginTop: '10%',
  },

  purpleAvatar: {
    margin: 10,
    color: '#fff',
    backgroundColor: deepPurple[500],
    height: 60,
    width: 60,
  },
}));

const QuizCard = ({ item = {} }) => {
  const classes = useStyles();
  const Badge = () => <Avatar className={classes.purpleAvatar}>C#</Avatar>;

  return (
    <Grid item xs={12} sm={6} md={4}>
      <Card className={classes.card}>
        {/* <CardMedia
          component={Badge}
          className={classes.cardMedia}
          image="https://source.unsplash.com/random"
          title="Image title"
        /> */}
        <CardContent className={classes.cardContent}>
          <Grid container spacing={4}>
            <Grid item xs={3} sm={3} md={3}>
              <Badge />
            </Grid>
            <Grid item xs={9} sm={9} md={9}>
              <Typography
                className={classes.heading}
                gutterBottom
                variant="h5"
                component="h2"
              >
                {item.title}
              </Typography>
            </Grid>
          </Grid>
          <Grid container spacing={4}>
            <Grid item xs={12} sm={12} md={12}>
              <Typography>{item.description}</Typography>
            </Grid>
            <Grid item xs={12} sm={12} md={12}>
              <Typography>{item.questions ? `${item.questions.length} questions` : ''}</Typography>
            </Grid>
          </Grid>
        </CardContent>
        <CardActions>
          <Button size="small" color="primary" component={Link} to={`/take-quiz/${item.id}`} >
            Take It!
          </Button>
          {/* <Button size="small" color="primary">
            Edit
          </Button> */}
        </CardActions>
      </Card>
    </Grid>
  );
};

export default QuizCard;