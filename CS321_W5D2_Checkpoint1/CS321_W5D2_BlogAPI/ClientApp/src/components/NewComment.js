import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { apiCall } from '../apiUtils';
import { ApiInfo } from './ApiInfo';

class NewComment extends Component {
  static displayName = NewComment.name;

  state = {
    apiInfo: {},
    blog: {},
    post: {},
    commentModel: {
      title: '',
      content: ''
    },
  };

  componentDidMount() {
  }

  handleClick = () => {
    // const { logIn } = this.props;
    // var loginModel = { ...this.state.loginModel };
    // logIn(loginModel);
    const { history } = this.props;
    const { blogId } = this.props.match.params;
    const { postModel } = this.state;
    postModel.blogId = blogId;
    apiCall(`/api/blogs/${blogId}/posts`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(postModel),
    }).then((res) => {
      this.setState({
        apiInfo: res,
      });
      if (res.status >= 200 && res.status < 400) {
        history.push(`/blog/${blogId}`);
      }
    });
  };

  handleChange = (e) => {
    var postModel = { ...this.state.postModel };
    postModel[e.target.name] = e.target.value;
    this.setState({ postModel });
  };

  render() {
    const { apiInfo, postModel, blog } = this.state;

    return (
      <React.Fragment>
        <Form>
          <FormGroup>
            <Label for="title">Title</Label>
            <Input
              type="text"
              name="title"
              id="title"
              placeholder="title"
              onChange={this.handleChange}
              value={postModel.title}
            />
          </FormGroup>
          <FormGroup>
            <Label for="content">Content</Label>
            <Input
              type="textarea"
              name="content"
              id="content"
              placeholder="content"
              rows="8"
              onChange={this.handleChange}
              value={postModel.content}
            />
          </FormGroup>
          <Button onClick={this.handleClick}>Save</Button>{' '}
          <Button tag={Link} to="/">
            Cancel
          </Button>
          <ApiInfo apiInfo={apiInfo} />
        </Form>
      </React.Fragment>
    );
  }
}
export default NewComment;
