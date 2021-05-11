import QuizApi from "../QuizAPI";
import sampleData from '../sampleData';
import { actionCreators as showNotificationActionCreators } from '../store/ShowNotification';

const requestQuiz = 'REQUEST_QUIZ';
const receiveQuiz = 'RECEIVE_QUIZ';
const initialState = { quiz: null, isLoading: false };

export const actionCreators = {
  requestQuiz: quizId => async (dispatch, getState) => {
    dispatch({ type: requestQuiz, quizId });

    try {
      const quiz = await QuizApi.getQuiz(quizId);
      dispatch({ type: receiveQuiz, quiz });
    } catch (error) {
      const quiz = sampleData.quizzes.find(q => Number(q.id) === Number(quizId));
      dispatch({ type: receiveQuiz, quiz, error: "Unable to fetch quiz. Using sample data." });
      dispatch(showNotificationActionCreators.showNotification(true));      
    }
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestQuiz) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveQuiz) {
    return {
      ...state,
      quiz: action.quiz,
      isLoading: false
    };
  }

  return state;
};
