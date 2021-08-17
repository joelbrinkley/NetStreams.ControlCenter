import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import { Header } from "./components/molecules";
import Sidebar from "./components/molecules/Sidebar";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Link } from "./components/molecules";
import { Main, Streams } from "./pages";

import "./App.css";
import "bootstrap/dist/css/bootstrap.css";

function App() {
  const navigationLinks: Array<Link> = [
    {
      ref: "/home",
      name: "Home",
    },
    {
      ref: "/streams",
      name: "Streams",
    },
  ];

  return (
    <Router>
      <Container>
        <Row>
          <Header brandText="NetStreams Control Center" />
        </Row>
        <Row>
          <Col xs={2} id="sidebar-wrapper">
            <Sidebar navigationLinks={navigationLinks} />
          </Col>
          <Col xs={10} id="page-content-wrapper">
            <Switch>
              <Route path="/main">
                <Main />
              </Route>
              <Route path="/streams">
                <Streams />
              </Route>
            </Switch>
          </Col>
        </Row>
      </Container>
    </Router>
  );
}

export default App;
