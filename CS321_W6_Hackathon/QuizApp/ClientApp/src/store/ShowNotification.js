const showNotification = 'SHOW_NOTIFICATION';
const initialState = { isNotificationOpen: false };

export const actionCreators = {
  showNotification: (show) => ({ type: showNotification, value: show }),
};

export const reducer = (state, action) => {
  state = state || initialState;
  if (action.type === showNotification) {
    return { ...state, isNotificationOpen: action.value };
  }

  return state;
};
