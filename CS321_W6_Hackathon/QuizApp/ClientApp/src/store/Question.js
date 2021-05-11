import QuizApi from "../QuizAPI";
import sampleQuiz from '../sampleQuiz';
import { actionCreators as showNotificationActionCreators } from '../store/ShowNotification';

const requestQuestion = 'REQUEST_QUESTION';
const receiveQuestion = 'RECEIVE_QUESTION';
const initialState = { question: null, isLoading: false };

export const actionCreators = {
  requestQuestion: questionId => async (dispatch, getState) => {
    dispatch({ type: requestQuestion, questionId: questionId });

    try {
      const question = await QuizApi.getQuestion(questionId);
      dispatch({ type: receiveQuestion, question });
    } catch (error) {
      const question = sampleQuiz.questions.find(q => Number(q.id) === Number(questionId));
      dispatch({ type: receiveQuestion, question, error: "Unable to fetch questions. Using sample data." });
      dispatch(showNotificationActionCreators.showNotification(true));
    }
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestQuestion) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveQuestion) {
    return {
      ...state,
      question: action.question,
      error: action.error,
      isLoading: false
    };
  }

  return state;
};
