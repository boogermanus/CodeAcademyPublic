import React, { Component } from 'react';
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { LoginInfo } from './LoginInfo';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    const { loggedIn, logOut, email } = this.props;
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              Checkpoint 2 BlogAPI
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <LoginInfo loggedIn={loggedIn} email={email} />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">
                    Home
                  </NavLink>
                </NavItem>
                {loggedIn ? (
                  <NavItem>
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/login"
                      onClick={logOut}
                    >
                      Log Out
                    </NavLink>
                  </NavItem>
                ) : (
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/login">
                      Log In
                    </NavLink>
                  </NavItem>
                )}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
