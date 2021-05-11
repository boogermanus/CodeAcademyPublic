import React from 'react';

import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import { Markdown } from 'react-markdown-tree';

import classNames from 'classnames';

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
  selected: {
    borderColor: theme.palette.primary.main,
    borderWidth: 5,
    borderStyle: 'solid',
  },
  correct: {
    borderColor: 'green',
    borderWidth: 5,
    borderStyle: 'solid',
  },
  incorrect: {
    borderColor: 'red',
    borderWidth: 5,
    borderStyle: 'solid',
  },
  unselectedCorrect: {
    borderColor: 'lightgreen',
    borderWidth: 5,
    borderStyle: 'solid',
  },
}));

export default ({ answer, selected, submitted = false, onSelected }) => {
  const classes = useStyles();

  const cardClasses = classNames(classes.card, {
    [classes.selected]: selected && !submitted,
    [classes.correct]: selected && submitted && answer.isCorrect,
    [classes.incorrect]: selected && submitted && !answer.isCorrect,
    [classes.unselectedCorrect]: !selected && submitted && answer.isCorrect,
  });
  //const content = "* test\n* test\n* test\n\n```csharp\nvar i = 10;\n```";

  return (
    // <Grid item xs={12} sm={6} md={4}>
      <Card
        className={cardClasses}
        onClick={() => onSelected && onSelected(answer)}
      >
        <CardContent className={classes.cardContent}>
          <Markdown>{answer.content}</Markdown>
        </CardContent>
      </Card>
    // </Grid>
  );
};
