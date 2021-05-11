import React from 'react';

import { Markdown } from 'react-markdown-tree';

import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Container from '@material-ui/core/Container';

import AnswerCards from './AnswerCards';
import AnswerCard from './AnswerCard';
import { Link } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
  heroContent: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(2, 0, 2),
    minHeight: '80vh',
  },
  heroButtons: {
    marginTop: theme.spacing(4),
  },
}));

const ShowQuestion = ({
  question,
  answer = {},
  onAnswerSelected,
  onNext,
  onSubmitted,
}) => {
  const classes = useStyles();
  const { selectedAnswers = [], isSubmitted = false } = answer;

  function handleAnswerSelected(answer) {
    if (answer.isSubmitted) return;

    let newSelectedAnswers;
    if (question.type === 'multiChoice') {
      if (selectedAnswers.includes(answer)) {
        newSelectedAnswers = selectedAnswers.filter((a) => a.id !== answer.id);
      } else {
        newSelectedAnswers = [...selectedAnswers, answer];
      }
    } else {
      newSelectedAnswers = [answer];
    }
    onAnswerSelected(question.id, {
      isSubmitted: false,
      selectedAnswers: newSelectedAnswers,
    });
  }

  function handleSubmit() {
    onAnswerSelected(question.id, { isSubmitted: true, selectedAnswers });
  }

  return (
    <div className={classes.heroContent}>
      <Container maxWidth="md">
        {/* <Typography variant="h5" align="center" color="textSecondary" paragraph>
          {question.prompt}
        </Typography> */}
        <Markdown>{question.prompt}</Markdown>
        <AnswerCards>
          {question.answers.map((a, i) => (
            <AnswerCard
              answer={a}
              key={i}
              selected={selectedAnswers.includes(a)}
              submitted={isSubmitted}
              onSelected={handleAnswerSelected}
            />
          ))}
        </AnswerCards>
        <div className={classes.heroButtons}>
          <Grid container spacing={2} justify="center">
            <Grid item>
              {isSubmitted ? (
                <Button variant="contained" color="default" onClick={onNext}>
                  Next Question
                </Button>
              ) : (
                <Button
                  variant="contained"
                  color="primary"
                  onClick={handleSubmit}
                  disabled={selectedAnswers.length === 0}
                >
                  Submit Answer
                </Button>
              )}
            </Grid>
          </Grid>
          <Grid container spacing={2} justify="center">
            <Grid item>
              <Link to={`/`}>Cancel Quiz</Link>
            </Grid>
          </Grid>
        </div>
      </Container>
    </div>
  );
};

export default ShowQuestion;