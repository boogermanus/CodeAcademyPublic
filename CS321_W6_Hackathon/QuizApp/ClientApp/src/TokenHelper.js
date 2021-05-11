const tokenName = 'quizToken';
class TokenHelper {
    getToken() {
        var token = JSON.parse(localStorage.getItem(tokenName));
        return token;
    }

    setToken(tokenObject) {
        localStorage.setItem(tokenName, JSON.stringify(tokenObject));

    }

    removeToken() {
        localStorage.removeItem(tokenName);
    }
}

export default new TokenHelper();