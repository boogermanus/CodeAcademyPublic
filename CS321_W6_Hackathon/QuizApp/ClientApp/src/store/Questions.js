import QuizApi from '../QuizAPI';
import sampleData from '../sampleData';
import { actionCreators as showNotificationActionCreators } from '../store/ShowNotification';

const requestQuestions = 'REQUEST_QUESTIONS';
const receiveQuestions = 'RECEIVE_QUESTIONS';
// const requestQuestion = 'REQUEST_QUESTION';
// const receiveQuestion = 'RECEIVE_QUESTION';
// const saveQuestion = 'SAVE_QUESTION';
// const saveQuestionComplete = 'SAVE_QUESTION_COMPLETE';
// const deleteQuestion = 'DELETE_QUESTION';
// const deleteQuestionComplete = 'DELETE_QUESTION_COMPLETE';

const initialState = { questions: [], question: null, isLoading: false };

export const actionCreators = {
  requestQuestions: () => async (dispatch, getStatie) => {
    dispatch({ type: requestQuestions });

    try {
      const questions = await QuizApi.getQuestions();
      dispatch({ type: receiveQuestions, questions });
    } catch (error) {
     //dispatch({ type: receiveQuestions, questions: sampleQuiz.questions });
     dispatch({ type: receiveQuestions, questions: sampleData.questions, error: "Unable to fetch questions. Using sample data." });
     dispatch(showNotificationActionCreators.showNotification(true));
    }
  },

  // requestQuestion: questionId => async (dispatch, getState) => {
  //   dispatch({ type: requestQuestion, questionId });
  //   console.log('request question');
  //   try {
  //     const question = await QuizApi.getQuestion(questionId);
  //     dispatch({ type: receiveQuestion, question });
  //   } catch (error) {
  //     console.log('requestQuestion error');
  //     const question = sampleData.questions.find(q => Number(q.id) === Number(questionId));
  //     dispatch({ type: receiveQuestion, question, error: "Unable to fetch questions. Using sample data." });
  //     dispatch(showNotificationActionCreators.showNotification(true));
  //   }
  // },

  // saveQuestion: question => async (dispatch, getState) => {
  //   dispatch({ type: saveQuestion, question });
  //   try {
  //     const savedQuestion = await QuizApi.saveQuestion(question);
  //     dispatch({ type: saveQuestionComplete, question: savedQuestion});
  //   } catch (error) {
  //     if (!question.id) {
  //       sampleData.questions.push(question);
  //     } else {
  //       const i = sampleData.questions.findIndex(q => q.id === question.id);
  //       sampleData.questions[i] = question;
  //     }
  //     dispatch({ type: saveQuestionComplete, question, error: 'Unable to save question. Using sample data.' });
  //     dispatch(showNotificationActionCreators.showNotification(true));      
  //   }
  // },

  // deleteQuestion: questionId => async (dispatch, getState) => {
  //   dispatch({ type: deleteQuestion, questionId });
  //   try {
  //     const result = await QuizApi.deleteQuestion(questionId);
  //     dispatch({ type: deleteQuestionComplete, questionId });
  //   } catch (error) {
  //     dispatch({ type: deleteQuestionComplete, questionId, error: 'Unable to delete question. Using sample data.' });
  //     dispatch(showNotificationActionCreators.showNotification(true));      
  //   }
  // },
};

export const reducer = (state, action) => {
  state = state || initialState;
  if (action.type === requestQuestions) {
    return {
      ...state,
      isLoading: true,
    };
  }

  if (action.type === receiveQuestions) {
    return {
      ...state,
      questions: action.questions,
      isLoading: false,
      error: action.error
    };
  }

  // if (action.type === requestQuestion) {
  //   return {
  //     ...state,
  //     isLoading: true
  //   };
  // }

  // if (action.type === receiveQuestion) {
  //   return {
  //     ...state,
  //     question: action.question,
  //     error: action.error,
  //     isLoading: false
  //   };
  // }

  // if (action.type === saveQuestionComplete) {
  //   return {
  //     ...state,
  //     questions: [...state.questions.filter(q => q.id !== action.question.id), action.question],
  //     question: action.question,
  //     error: action.error,
  //     isLoading: false
  //   };
  // }

  // if (action.type === deleteQuestionComplete) {
  //   return {
  //   ...state,
  //   questions: [...state.questions.filter(q => q.id !== action.questionId)],
  //   error: action.error,
  //   isLoading: false
  //   };
  // }

  return state;
};
