import { Container, Row, Col } from "react-bootstrap";
import Sidebar from "./components/organisms/Sidebar";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Link } from "./models";
import { Main, Streams } from "./pages";

import "./App.css";
import "bootstrap/dist/css/bootstrap.css";

function App() {
  const navigationLinks: Array<Link> = [
    {
      ref: "/Main",
      name: "Main",
    },
    {
      ref: "/streams",
      name: "Streams",
    },
  ];

  return (
    <Router>
      <Container fluid>
        <Row>
          <Col xs={2} id="sidebar-wrapper">
            <Sidebar navigationLinks={navigationLinks} />
          </Col>
          <Col xs={10} id="page-content-wrapper">
            <Switch>
              <Route path="/Main">
                <Main />
              </Route>
              <Route path="/Streams">
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
