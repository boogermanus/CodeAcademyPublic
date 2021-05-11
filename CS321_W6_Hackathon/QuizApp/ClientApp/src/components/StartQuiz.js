import React from 'react';
import HeroUnit from './HeroUnit';

const StartQuiz = (props) => {
  const { quiz, onStart, onCancel } = props;
  if (!quiz) return null;
  return (
    <React.Fragment>
      <HeroUnit
        heading={quiz.title}
        content={quiz.description}
        primaryButtonText="Start"
        primaryButtonAction={onStart}
        secondaryButtonText="Go Back"
        secondaryButtonAction={onCancel}
      />
    </React.Fragment>
  );
};

export default StartQuiz;
