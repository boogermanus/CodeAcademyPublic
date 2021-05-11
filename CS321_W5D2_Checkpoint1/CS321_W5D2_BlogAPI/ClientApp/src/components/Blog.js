import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { Card, CardBody, CardTitle, CardSubtitle, Button } from 'reactstrap';
import { ApiInfo } from './ApiInfo';
import { withRouter } from 'react-router-dom'
import { BlogHeader } from './BlogHeader';

const PostCard = (props) => {
  const { post, onDeleteClick } = props;
  return (
    <Card>
      <CardBody>
        <CardTitle>{post.title}</CardTitle>
        <CardSubtitle>by {post.authorName}{' '}{post.datePublished.substring(0, 10)}</CardSubtitle>
        <Button tag={Link} to={`/blog/${post.blogId}/post/${post.id}`}>
          Read More...
        </Button>{' '}
        <Button onClick={onDeleteClick}>Delete</Button>
      </CardBody>
      <CardBody
        style={{ overflow: 'hidden', textOverflow: 'ellipsis', height: 80 }}
      >
        <div dangerouslySetInnerHTML={{ __html: post.content }} />
      </CardBody>
    </Card>
  );
};

class Blog extends Component {
  static displayName = Blog.name;

  state = {
    blog: {},
    posts: [],
    apiInfo: {},
  };

  componentDidMount() {
    this.fetchPosts();
  }

  fetchPosts = () => {
    const { blogId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}`, {
      method: 'GET',
    }).then((res) => {
      this.setState({
        blog: res.data,
      });
    });
    apiCall(`/api/blogs/${blogId}/posts`).then((res) => {
      this.setState({
        posts: res.data,
        apiInfo: res,
      });
    });
  }

  onDeleteClick = (postId) => {
    const { blogId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}/posts/${postId}`, {
      method: 'DELETE',
    }).then((res) => {
      this.setState({
        apiInfo: res
      });
      if (res.status >= 200 && res.status < 400) {
        this.fetchPosts();
      }
    })
    .catch(ex => {
      console.log(ex);
    });
  };

  render() {
    const { blog, posts, apiInfo } = this.state;
    const route = this.props.location.pathname;
    return (
      <React.Fragment>
        <BlogHeader blog={blog}/>
        <Button tag={Link} to={route + '/new-post'}>New Post</Button>
        {posts.map((p, i) => (
          <PostCard
            post={p}
            key={i}
            onDeleteClick={() => this.onDeleteClick(p.id)}
          />
        ))}
        <ApiInfo apiInfo={apiInfo} />
      </React.Fragment>
    );
  }
}

export default withRouter(Blog);