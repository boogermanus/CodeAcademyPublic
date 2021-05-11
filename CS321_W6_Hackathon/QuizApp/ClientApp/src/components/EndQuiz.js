import React from 'react';
import HeroUnit from './HeroUnit';

const EndQuiz = ({ quiz, answers, onStartOver, onFindAnotherQuiz }) => {
  function getNumberCorrect() {
    if (!quiz || !quiz.questions) return 0;
    return quiz.questions.reduce((numCorrect, q) => {
      const expected = q.answers.filter((a) => a.isCorrect).length;
      const actual = answers[q.id]
        ? answers[q.id].selectedAnswers.filter((a) => a.isCorrect).length
        : 0;
      return expected === actual ? numCorrect + 1 : numCorrect;
    }, 0);
  }

  const numCorrect = getNumberCorrect();
  const numQuestions = quiz && quiz.questions ? quiz.questions.length : 0;
  const content = `You got ${numCorrect} out of ${numQuestions} correct.`;

  return (
    <React.Fragment>
      <HeroUnit
        heading="All Done!"
        content={content}
        primaryButtonText="Try Again"
        primaryButtonAction={onStartOver}
        secondaryButtonText="Find Another Quiz"
        secondaryButtonAction={onFindAnotherQuiz}
      />
    </React.Fragment>
  );
};

export default EndQuiz;