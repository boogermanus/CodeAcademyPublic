import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { ApiInfo } from './ApiInfo';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';

const BlogCard = (props) => {
  const blog = props.blog;
  return (
    <Card>
      <CardBody>
        <CardTitle>{blog.name}</CardTitle>
        <CardText style={{ fontStyle: 'italic', fontSize: '8' }}>A blog by {blog.authorName}</CardText>
        <CardText>{blog.description}</CardText>
        <Button tag={Link} to={`/blog/${blog.id}`}>Read Now!</Button>
      </CardBody>
    </Card>
  );
};

export class Home extends Component {
  static displayName = Home.name;

  state = {
    blogs: [],
    apiInfo: {}
  };

  componentDidMount() {
    apiCall('/api/blogs', {
      method: 'GET'
    }).then(res => {
      this.setState({
        blogs: res.data,
        apiInfo: res
      });
    });
  }

  render() {
    const { blogs, apiInfo } = this.state;
    return (
      <React.Fragment>
        {blogs.map((b, i) => (
          <BlogCard blog={b} key={i} />
        ))}
        <ApiInfo apiInfo={apiInfo} />
      </React.Fragment>
    );
  }
}
