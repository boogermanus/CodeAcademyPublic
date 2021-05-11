import React, { useEffect, useState } from 'react';

import { Link } from 'react-router-dom';

import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import IconButton from '@material-ui/core/IconButton';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import QuestionIcon from '@material-ui/icons/Help';
import { Button } from '@material-ui/core';

import Notification from './Notification';
import QuizAPI from '../QuizAPI';
import sampleData from '../sampleData';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    maxWidth: 752,
  },
  demo: {
    backgroundColor: theme.palette.background.paper,
  },
  title: {
    margin: theme.spacing(4, 0, 2),
  },
  button: {
    '&:focus': {
      outline: 0,
    },
  },
}));

const QuestionList = ({
  setViewName,
}) => {
  const classes = useStyles();

  const [isNotificationOpen, setIsNotificationOpen] = useState(false);
  const [questionsState, setQuestionsState] = useState({
    questions: [],
    error: ''
  });

  useEffect(() => {
    loadQuestions();
    setViewName('Questions');
  }, []);

  async function loadQuestions() {
    try {
      const questions = await QuizAPI.getQuestions();
      setQuestionsState({
        questions,
        error: ''
      });
    } catch (error) {
      setQuestionsState({
        questions: sampleData.questions,
        error: 'Unable to GET /api/questions. Using sample data.'
      });
      setIsNotificationOpen(true);
    }
  }

  async function deleteQuestion(questionId) {
    try {
      const result = await QuizAPI.deleteQuestion(questionId);
      loadQuestions();
    } catch (error) {
      console.log(error);
      setQuestionsState({
        questions: sampleData.questions.filter(q => q.id !== questionId),
        error: 'Unable to DELETE /api/questions. Using sample data.'
      });
      setIsNotificationOpen(true);
    }
  }

  function handleCloseNotification() {
    setIsNotificationOpen(false);
  }

  function handleDelete(id) {
    deleteQuestion(id);
  }

  return (
    <Container justify="center" maxWidth="md">
      <Notification
        isOpen={isNotificationOpen}
        message={questionsState.error}
        handleClose={handleCloseNotification}
      />
      <Grid item xs={12} md={12}>
        <Grid container alignItems="center" justify="space-between">
          <Grid item md={10}>
            <Typography variant="h6" className={classes.title}>
              Questions
            </Typography>
          </Grid>
          <Grid item md={2}>
            <Grid
              container
              alignItems="flex-start"
              justify="flex-end"
              direction="row"
            >
              <Button variant="contained" component={Link} to="/edit-question">
                New Question
              </Button>
            </Grid>
          </Grid>
        </Grid>
        <div className={classes.demo}>
          <List dense={false}>
            {questionsState.questions.map((q, i) => (
              <ListItem key={i}>
                <ListItemIcon>
                  <QuestionIcon />
                </ListItemIcon>
                <ListItemText
                  primary={q.prompt}
                  secondary={'C#, ASP.NET Core'}
                />
                <ListItemSecondaryAction>
                  <IconButton
                    edge="end"
                    aria-label="Edit"
                    className={classes.button}
                    component={Link}
                    to={`/edit-question/${q.id}`}
                    // onClick={() => handleEdit(q.id)}
                  >
                    <EditIcon />
                  </IconButton>
                  <IconButton
                    edge="end"
                    aria-label="Delete"
                    className={classes.button}
                    onClick={() => handleDelete(q.id)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </ListItemSecondaryAction>
              </ListItem>
            ))}
          </List>
        </div>
      </Grid>
    </Container>
  );
};

export default QuestionList;