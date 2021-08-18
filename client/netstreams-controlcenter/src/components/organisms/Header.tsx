import React, { FC } from "react";
import { Container, Navbar } from "react-bootstrap";

interface HeaderProps {
  brandRef: string
  brandText: string;
}

export const Header: FC<HeaderProps> = ({ brandText, brandRef }: HeaderProps) => {
  return (
    <Navbar fixed="top" bg="dark" variant="dark">
      <Container fluid>
        <Navbar.Brand href={brandRef}>{brandText}</Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end"></Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
