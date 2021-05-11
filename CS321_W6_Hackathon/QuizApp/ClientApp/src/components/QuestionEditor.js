import React, { useState, useEffect } from 'react';
import { Link, withRouter } from 'react-router-dom';

import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import { Button } from '@material-ui/core';

import AnswerEditor from './AnswerEditor';
import Notification from './Notification';
import QuizAPI from '../QuizAPI';
import sampleData from '../sampleData';

const useStyles = makeStyles((theme) => ({
  container: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  textField: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    width: 400,
  },
  dense: {
    marginTop: 19,
  },
  menu: {
    width: 200,
  },
  grid: {
    margin: 5,
  },
}));

const QuestionEditor = ({ match, isNew, history, setViewName }) => {
  const classes = useStyles();
  const initialQuestionState = {
    question: {
      prompt: '',
      answers: [
        {
          content: '',
          isCorrect: false,
        },
        {
          content: '',
          isCorrect: false,
        },
        {
          content: '',
          isCorrect: false,
        },
      ],
    },
    error: '',
  };

  const [isNotificationOpen, setIsNotificationOpen] = useState(false);
  const [questionState, setQuestionState] = useState(initialQuestionState);

  // mounted
  useEffect(() => {
    const { question } = questionState;
    const questionId = match.params.questionId;
    if (!question || question.id !== questionId) {
      loadQuestion(questionId);
    }
    if (isNew) {
      setViewName('New Question');
    } else {
      setViewName('Edit Question');
    }
  }, []);

  async function loadQuestion(id) {
    try {
      const question = await QuizAPI.getQuestion(id);
      setQuestionState({
        question,
        error: '',
      });
    } catch (error) {
      const question = sampleData.questions.find((q) => q.id === Number(id));
      setQuestionState({
        question,
        error: `Unable to GET /api/questions/${id}. Using sample data.`
      });
      setIsNotificationOpen(true);
    }
  }

  function handleQuestionChanged(event) {
    const prompt = event.target.value;
    setQuestionState({
      question: {
        ...questionState.question,
        prompt,
      },
      error: '',
    });
  }

  function handleAnswerChanged(index, answer) {
    const newAnswers = [...questionState.question.answers];
    newAnswers[index] = answer;
    setQuestionState({
      question: {
        ...questionState.question,
        answers: newAnswers,
      },
      error: '',
    });
  }

  function handleCloseNotification() {
    setIsNotificationOpen(false);
  }

  async function handleSave() {
    const { question } = questionState;
    try {
      const savedQuestion = await QuizAPI.saveQuestion(question);
      history.push('/questions');
    } catch (error) {
      // if (!question.id) {
      //   sampleData.questions.push(question);
      // } else {
      //   const i = sampleData.questions.findIndex((q) => q.id === question.id);
      //   sampleData.questions[i] = question;
      // }
      setQuestionState({
        question,
        error: `Unable to POST or PUT /api/questions. ${error} `
      });
      setIsNotificationOpen(true);
    } finally {
      // setTimeout(() => {
      //   history.push('/questions');
      // }, 1000);
    }
  }

  return (
    <Container justify="center" maxWidth="md">
      <Notification
          isOpen={isNotificationOpen}
          message={questionState.error}
          handleClose={handleCloseNotification}
        />
      <form className={classes.container} noValidate autoComplete="off">
        <Grid container spacing={4}>
          <Grid item md={12}>
            <TextField
              id="standard-multiline-static"
              label="Question Prompt"
              helperText="You can use markdown in the question prompt."
              multiline
              rows="5"
              fullWidth
              margin="normal"
              value={questionState.question.prompt}
              onChange={handleQuestionChanged}
            />
          </Grid>
        </Grid>
        <Grid container>
          <Grid item md={4}>
            <AnswerEditor
              index={0}
              answer={questionState.question.answers[0]}
              onChange={handleAnswerChanged}
            />
          </Grid>
          <Grid item md={4}>
            <AnswerEditor
              index={1}
              answer={questionState.question.answers[1]}
              onChange={handleAnswerChanged}
            />
          </Grid>
          <Grid item md={4}>
            <AnswerEditor
              index={2}
              answer={questionState.question.answers[2]}
              onChange={handleAnswerChanged}
            />
          </Grid>
        </Grid>
        <Grid container spacing={2} alignItems="center" justify="center">
          <Grid item>
            <Button variant="contained" color="primary" onClick={handleSave}>
              Save
            </Button>
          </Grid>
          <Grid item>
            <Button variant="contained" component={Link} to="/questions">
              Cancel
            </Button>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default withRouter(QuestionEditor);
