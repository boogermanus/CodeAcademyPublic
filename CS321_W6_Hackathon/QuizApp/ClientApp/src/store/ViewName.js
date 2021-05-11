const setViewName = 'SET_VIEW_NAME';
const initialState = { viewName: '' };

export const actionCreators = {
  setViewName: (viewName) => ({ type: setViewName, viewName }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === setViewName) {
    return { ...state, viewName: action.viewName };
  }

  return state;
};
