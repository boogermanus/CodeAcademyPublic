import QuizApi from "../QuizAPI";
import sampleData from '../sampleData';
import { actionCreators as showNotificationActionCreators } from '../store/ShowNotification';

const requestQuizzes = 'REQUEST_QUIZZES';
const receiveQuizzes = 'RECEIVE_QUIZZES';
const initialState = { quizzes: [], isLoading: false };

export const actionCreators = {
  requestQuizzes: () => async (dispatch, getStatie) => {
    dispatch({ type: requestQuizzes });

    try {
      const quizzes = await QuizApi.getQuizzes();
      dispatch({ type: receiveQuizzes, quizzes });      
    } catch (error) {
      dispatch({ type: receiveQuizzes, quizzes: sampleData.quizzes, error: "Unable to fetch quizzes. Using sample data." });
      dispatch(showNotificationActionCreators.showNotification(true));
    }

  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestQuizzes) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveQuizzes) {
    return {
      ...state,
      quizzes: action.quizzes,
      isLoading: false
    };
  }

  return state;
};
