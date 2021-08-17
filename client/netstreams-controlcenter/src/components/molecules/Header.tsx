import React , {FC} from "react";
import { Container, Navbar } from "react-bootstrap";

interface HeaderProps {
  brandText: string
}
export const Header : FC<HeaderProps> = ({brandText}: HeaderProps) => {
  return (
    <Navbar fixed="top" bg="dark" variant="dark">
      <Container fluid>
        <Navbar.Brand href="#home">{brandText}</Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end">
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
