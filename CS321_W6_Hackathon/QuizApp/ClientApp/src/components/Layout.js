import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Header from './Header';
// import Footer from './Footer';

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
    flexDirection: 'column',
    minHeight: '100vh',
  },
}));

export default ({ children, logOut, user, viewName }) => {
  const classes = useStyles();
  return (
    <React.Fragment>
      <div className={classes.root}>
        <CssBaseline />
        <Header user={user} logOut={logOut} viewName={viewName} />
        <main>
          <Container>{children}</Container>
        </main>
        {/* <Footer /> */}
      </div>
    </React.Fragment>
  );
};
