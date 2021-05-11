import TokenHelper from './TokenHelper';

const fetchAndThrow = async (uri, options) => {
  const response = await fetch(uri, options);
  if (!response.ok) {
    const data = await response.text();
    throw Error(response.statusText + ' ' + data);
  }
  return response;
};

const fetchJson = async (uri, options) => {
  const response = await fetchAndThrow(uri, options);
  return response.json();
};

class QuizApi {
  static getQuestions() {
    const uri = `api/questions`;
    const options = {};
    return fetchJson(uri, options);
  }

  static getQuestion(questionId) {
    const uri = `api/questions/${questionId}`;
    const options = {};
    return fetchJson(uri, options);
  }

  static saveQuestion(question) {
    const token = TokenHelper.getToken();
    const body = JSON.stringify(question);
    let uri, options;
    // new
    if (!question.id) {
      uri = `api/questions`;
      options = {
        method: 'POST',
        body,
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'bearer ' + token.token
        },
      };
    } else {
      // update
      uri = `api/questions/${question.id}`;
      options = {
        method: 'PUT',
        body,
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'bearer ' + token.token
        },
      };
    }

    return fetchJson(uri, options);
  }

  static deleteQuestion(questionId) {
    const token = TokenHelper.getToken();
    const uri = `api/questions/${questionId}`;
    const options = {
      method: 'DELETE',
      headers: {
        'Authorization': 'bearer ' + token.token
      },
  };
    return fetchAndThrow(uri, options);
  }

  static async getQuizzes() {
    
      const uri = `api/quizzes`;
      const options = {};
      return await fetchJson(uri, options);        
  }

  static async getQuiz(quizId) {
    const uri = `api/quizzes/${quizId}`;
    const options = {};
    return await fetchJson(uri, options);
  }

  static async getRandomQuiz() {
    
    const uri = `api/quizzes/random`;
    const options = {};
    return await fetchJson(uri, options);        
  }

  static login(loginInfo) {
    const uri = `api/auth/login`;
    const options = {
      method: 'POST',
      body: JSON.stringify(loginInfo),
      headers: {
        'Content-Type': 'application/json',
      },
    };
    return fetchJson(uri, options);
  }

  static register(registerInfo) {
    const uri = `api/auth/register`;
    const options = {
      method: 'POST',
      body: JSON.stringify(registerInfo),
      headers: {
        'Content-Type': 'application/json',
      },
    };
    return fetchJson(uri, options);
  }

  static verifyToken() {
    const token = TokenHelper.getToken();
    if (!token || !token.token) {
      return Promise.reject('Invalid token.');
    }

    const uri = `api/auth/verify`;
    const options = {
      headers: {
        'Authorization': 'bearer ' + token.token
      }
    };
    return fetchAndThrow(uri, options)
      .then(() => {
        return token;
      });
  }
}

export default QuizApi;
