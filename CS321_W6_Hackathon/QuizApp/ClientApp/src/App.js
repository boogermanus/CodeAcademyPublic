import React, { useEffect, useState } from 'react';
import { Route } from 'react-router';
import { withRouter } from 'react-router-dom';

import TokenHelper from './TokenHelper';
import QuizAPI from './QuizAPI';

import Layout from './components/Layout';
import Home from './components/Home';
import TakeQuiz from './components/TakeQuiz';
import QuestionList from './components/QuestionList';
import QuestionEditor from './components/QuestionEditor';
import Login from './components/Login';
import Register from './components/Register';

const App = ({ history }) => {
  const [viewName, setViewName] = useState('');
  const [user, setUser] = useState({
    loggedIn: false,
    email: '',
  });

  useEffect(() => {
    QuizAPI.verifyToken()
      .then((token) => {
        setUser({
          loggedIn: true,
          email: token.email,
        });
        console.log('token verified');
      })
      .catch((error) => {
        setUser({
          loggedIn: false,
          email: '',
        });
      });
  }, []);

  function logIn(loginModel) {
    return QuizAPI.login(loginModel)
      .then((res) => {
        TokenHelper.setToken(res);
        setUser({
          loggedIn: true,
          email: loginModel.email,
        });
        return user;
      })
      .catch((error) => {
        setUser({
          loggedIn: false,
          email: '',
          error,
        });
      });
  }

  function logOut() {
    TokenHelper.removeToken();
    setUser({
      loggedIn: false,
      email: '',
    });
  }

  function register(registrationModel) {
    return QuizAPI.register(registrationModel)
      .then((res) => {
        history.push('/login');
      })
      .catch((error) => {
        setUser({
          loggedIn: false,
          email: '',
          error,
        });
      });
  }

  return (
    <Layout user={user} logOut={logOut} viewName={viewName}>
      <Route
        exact
        path="/login"
        component={() => <Login user={user} logIn={logIn} />}
      />
      <Route
        exact
        path="/register"
        component={() => <Register user={user} register={register} />}
      />
      <Route exact path="/take-quiz/:quizId" component={TakeQuiz} />
      <Route
        exact
        path="/questions"
        component={() => <QuestionList setViewName={setViewName} />}
      />
      <Route
        exact
        path="/edit-question"
        component={() => (
          <QuestionEditor isNew={true} setViewName={setViewName} />
        )}
      />
      <Route
        exact
        path="/edit-question/:questionId"
        component={() => (
          <QuestionEditor isNew={false} setViewName={setViewName} />
        )}
      />
      <Route
        exact
        path="/quizzes"
        component={() => <Home setViewName={setViewName} />}
      />
      <Route
        exact
        path="/"
        component={() => <Home setViewName={setViewName} />}
      />
    </Layout>
  );
};

export default withRouter(App);
