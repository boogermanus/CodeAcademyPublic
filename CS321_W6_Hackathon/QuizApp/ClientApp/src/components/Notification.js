import React from 'react';
import { amber, green } from '@material-ui/core/colors';
import { makeStyles } from '@material-ui/core/styles';
import Snackbar from '@material-ui/core/Snackbar';
import SnackbarContent from '@material-ui/core/SnackbarContent';
import InfoIcon from '@material-ui/icons/Info';

const useStyles = makeStyles((theme) => ({
  success: {
    backgroundColor: green[600],
  },
  error: {
    backgroundColor: theme.palette.error.dark,
  },
  info: {
    backgroundColor: theme.palette.primary.main,
  },
  warning: {
    backgroundColor: amber[700],
  },
}));

export default ({ isOpen, handleClose, message }) => {
  const classes = useStyles();
  return (
    <Snackbar
      anchorOrigin={{
        vertical: 'bottom',
        horizontal: 'right',
      }}
      open={isOpen}
      autoHideDuration={10000}
      onClose={handleClose}
    >
      <SnackbarContent
        className={classes.warning}
        aria-describedby="client-snackbar"
        message={
          <span id="client-snackbar" className={classes.message}>
            <InfoIcon />
            {message}
          </span>
        }
      />
    </Snackbar>
  );
};
