import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { withRouter } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { ApiInfo } from './ApiInfo';
import { BlogHeader } from './BlogHeader';

class NewPost extends Component {
  static displayName = NewPost.name;

  state = {
    apiInfo: {},
    blog: {},
    postModel: {
      title: 'Lorem Ipsum',
      content:
        '<p>Curabitur cum mollis ullamcorper ridiculus nunc, bibendum cubilia mi quis. Nisl nostra ut iaculis porta iaculis vitae litora natoque? Vitae semper magnis purus cubilia ut. Arcu, nulla porta pretium neque libero pulvinar proin nascetur natoque. Donec eleifend metus himenaeos consectetur nec nulla. Vel est fusce fermentum varius quisque lacinia consequat aliquam dignissim cursus? Congue parturient condimentum accumsan sem, lobortis pellentesque integer. Per egestas odio himenaeos. At fermentum vulputate porttitor cubilia vestibulum phasellus iaculis. Arcu per bibendum nibh aptent dictumst posuere netus rhoncus senectus sociis et. Est?</p><p>Scelerisque praesent fermentum enim eu risus elementum, imperdiet sociis libero parturient. Primis quisque at per. Nascetur nam elementum natoque viverra vitae purus egestas non cras aenean. Natoque placerat porta justo posuere ornare dapibus nam pulvinar maecenas. Taciti volutpat cubilia proin cum sociis velit congue egestas suscipit cubilia sapien platea. Nunc facilisi turpis suspendisse convallis.</p><p>Taciti vel at suscipit accumsan mi interdum ipsum tristique. Penatibus blandit placerat a dui eleifend porta gravida eros per dis convallis natoque. Turpis fermentum litora gravida pretium. Eleifend litora sollicitudin pulvinar sagittis, accumsan molestie ridiculus malesuada. Dictumst neque eu consectetur sociis eget, curae; eu ornare.Bibendum, class interdum id eros sagittis nisi ut leo.Duis mollis risus curabitur nulla ridiculus potenti congue ad semper fringilla interdum mollis! Convallis proin aptent, velit arcu gravida.Quisque suscipit vulputate integer? Magnis.</p>',
      commentsAllowed: true,
    },
  };

  componentDidMount() {
    const { blogId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}`, {
      method: 'GET',
    }).then((res) => {
      this.setState({
        blog: res.data,
      });
    });    
  }

  handleClick = () => {
    // const { logIn } = this.props;
    // var loginModel = { ...this.state.loginModel };
    // logIn(loginModel);
    const { history } = this.props;
    const { blogId } = this.props.match.params;
    const { postModel } = this.state;
    
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
        <BlogHeader blog={blog}/>
        <h3>New Post</h3>
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
          <FormGroup check>
            <Label check>
              <Input
                type="checkbox"
                id="commentsAllowed"
                name="commentsAllowed"
                onChange={this.handleChange}
              />{' '}
              Allow Comments
            </Label>
          </FormGroup>{' '}
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
export default withRouter(NewPost);
