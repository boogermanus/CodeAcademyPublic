import TokenHelper from './tokenHelper';

export function apiCall(route, options = {}) {
  //var blogToken = localStorage.getItem('blogToken');
  var blogToken = TokenHelper.getToken();
  options = {
    method: 'GET',
    ...options,
    headers: {
      ...options.headers,
      'Content-Type': 'application/json'
    },
  };
  if (blogToken) {
    options.headers.Authorization = 'Bearer ' + blogToken.token;
  }
  const apiInfo = {
    route: route,
    options: options,
  };
  return fetch(route, options)
  .then(res => {
      apiInfo.status = res.status;
      apiInfo.statusText = res.statusText;
      return res.json();
    })
    .then((data) => {
      apiInfo.data = data;
      if (!apiInfo.ok) {
        throw Error(apiInfo.statusText);
      }
      return apiInfo;
    })
    .catch(ex => {
      return {
        ...apiInfo,
        error: ex
      };
    });
}
