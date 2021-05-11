import React, { Component } from 'react';
import { apiCall } from '../apiUtils';
import { ApiInfo } from './ApiInfo';

export class Post extends Component {
  static displayName = Post.name;

  state = {
    post: {},
    comments: [],
    apiInfo: {}
  };

  componentDidMount() {
    const { blogId, postId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}/posts/${postId}`)
    .then((res) => {
      this.setState({
        post: res.data,
        apiInfo: res
      });
    });
  }

  render() {
    const { post, apiInfo } = this.state;
    return (
      <React.Fragment>
        <h1>{post.title}</h1>
        <div dangerouslySetInnerHTML={{ __html: post.content }} />
        <ApiInfo apiInfo={apiInfo}/>
      </React.Fragment>
    );
  }
}
