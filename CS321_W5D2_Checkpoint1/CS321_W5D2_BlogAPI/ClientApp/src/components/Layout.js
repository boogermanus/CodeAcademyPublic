import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    const { loggedIn, logOut, email } = this.props;
    return (
      <div>
        <NavMenu loggedIn={loggedIn} logOut={logOut} email={email}/>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
