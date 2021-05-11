import React, { Component } from 'react';

export class LoginInfo extends Component {
  static displayName = LoginInfo.name;

  render() {
    const { loggedIn, email } = this.props;
    return (
      <div className="text-primary" style={{ textAlign: 'center', width: '60%' }}>
          {loggedIn ? 'Logged in as ' + email : 'You are not logged in.'}
      </div>
    );
  }
}
