const setUser = 'SET_USER';
const initialState = { email: '', loggedIn: false };

export const actionCreators = {
  setUser: (user) => async (dispatch, getState) => {
    dispatch({
      type: setUser,
      user
    });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === setUser) {
    return { ...state, ...action.user };
  }

  return state;
};
