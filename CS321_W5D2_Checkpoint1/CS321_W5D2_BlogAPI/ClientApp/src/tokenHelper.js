class TokenHelper {
    getToken() {
        try {
            var blogToken = JSON.parse(localStorage.getItem('blogToken'));
            return blogToken;                
        } catch (error) {
            console.log("Error retrieving token.", error);
            localStorage.removeItem('blogToken');
            return null;
        }
    }

    setToken(tokenObject) {
        console.log(tokenObject);
        localStorage.setItem('blogToken', JSON.stringify(tokenObject));

    }

    removeToken() {
        localStorage.removeItem('blogToken');
    }
}

export default new TokenHelper();