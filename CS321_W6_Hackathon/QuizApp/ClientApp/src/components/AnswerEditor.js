import React from 'react';

import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import { Checkbox, FormControlLabel } from '@material-ui/core';

const AnswerEditor = ({ index, answer, isNew, onChange }) => {


  function handlePromptChange(event) {
    const content = event.target.value;
    onChange(index, {
      ...answer,
      content
    });
  }

  function handleCorrectChange(event) {
    const isCorrect = event.target.checked;
    onChange(index, {
      ...answer,
      isCorrect
    });
  }

  return (
    <Container justify="center" maxWidth="md">
      <TextField
        id="standard-multiline-static"
        label={`Answer ${index + 1} Content`}
        helperText="You can use markdown in this field."
        multiline
        rows="8"
        fullWidth
        margin="normal"
        value={answer.content}
        onChange={handlePromptChange}
      />
      <FormControlLabel
        control={
          <Checkbox
            checked={answer.isCorrect}
            onChange={handleCorrectChange}
          />
        }
        label={`Answer ${index + 1} is correct.`}
      />
    </Container>
  );
};
export default AnswerEditor;