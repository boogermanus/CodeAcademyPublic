import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class Register extends React.Component {
  state = {
    registrationModel: {},
  };

  handleClick = (e) => {
    const { registrationModel } = this.state;
    e.preventDefault();
    const { register } = this.props;
    register(registrationModel);
  };

  handleChange = (e) => {
    var registrationModel = { ...this.state.registrationModel };
    registrationModel[e.target.name] = e.target.value;
    this.setState({ registrationModel });
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
        <FormGroup>
          <Label for="firstName">First Name</Label>
          <Input
            type="firstName"
            name="firstName"
            id="firstName"
            placeholder="firstName"
            onChange={this.handleChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="lastName">Last Name</Label>
          <Input
            type="lastName"
            name="lastName"
            id="lastName"
            placeholder="lastName"
            onChange={this.handleChange}
          />
        </FormGroup>
        <Button onClick={this.handleClick}>Register</Button>{' '}
        <Button tag={Link} to="/">Cancel</Button>
      </Form>
    );
  }
}
