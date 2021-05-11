import React, { Component } from 'react';

export class BlogHeader extends Component {
  static displayName = BlogHeader.name;

  componentDidMount() {}

  render() {
    const { blog } = this.props;
    return (
      <React.Fragment>
        <h1 style={{ textAlign: 'center'}}>{blog.name}</h1>
        <h5 style={{ textAlign: 'center'}}>A blog by {blog.authorName}</h5>
      </React.Fragment>
    );
  }
}
