import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { withRouter } from 'react-router-dom'

class Login extends React.Component {
  state = {
    loginModel: {},
  };

  handleClick = () => {
    const { logIn } = this.props;
    var loginModel = { ...this.state.loginModel };
    logIn(loginModel);
  }

  handleChange = (e) => {
    var loginModel = { ...this.state.loginModel };
    loginModel[e.target.name] = e.target.value;
    this.setState({ loginModel });
  };

  render() {
    return (
      <Form>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            type="email"
            name="email"
            id="email"
            placeholder="email"
            onChange={this.handleChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            type="password"
            name="password"
            id="password"
            placeholder="password"
            onChange={this.handleChange}
          />
        </FormGroup>
        <Button onClick={this.handleClick}>Login</Button>{' '}
        <Button tag={Link} to="/">Cancel</Button>
        <p>Don't have an account? <Link to="/register">Sign Up</Link></p>
      </Form>
    );
  }
}

export default withRouter(Login);