import React, { Component } from 'react';
import { Card, CardBody, CardTitle, CardSubtitle, CardText } from 'reactstrap';

const ApiInfoCard = ({ apiInfo }) => (
  <Card>
    <CardBody>
      <CardTitle>API Call Info</CardTitle>
      <CardSubtitle style={{ color: apiInfo.status >= 400 ? 'red' : 'green' }}>
        {apiInfo.status} {apiInfo.statusText}
      </CardSubtitle>
      <CardText />
      <CardSubtitle>Route</CardSubtitle>
      <CardText>
        {apiInfo.options ? apiInfo.options.method : 'GET'} {apiInfo.route}
      </CardText>
      <CardSubtitle>Headers</CardSubtitle>
      {apiInfo.options && apiInfo.options.headers
        ? Object.keys(apiInfo.options.headers).map((k, i) => (
            <CardText key={i}>
              {k}: {apiInfo.options.headers[k]}
            </CardText>
          ))
        : null}
      <CardSubtitle>Response</CardSubtitle>
    </CardBody>
    <CardBody>
      <pre>{JSON.stringify(apiInfo.data, null, 2)}</pre>
    </CardBody>
  </Card>
);

export class ApiInfo extends Component {
  static displayName = ApiInfo.name;

  componentDidMount() {}

  render() {
    const { apiInfo } = this.props;
    return (
      <React.Fragment>
        {apiInfo.route ? <ApiInfoCard apiInfo={apiInfo} /> : null}
      </React.Fragment>
    );
  }
}
