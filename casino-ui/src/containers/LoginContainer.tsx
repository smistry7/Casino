import React from "react"
import { Col, Container, Nav, Navbar, Row } from 'react-bootstrap'

export const NavbarContainer = () => {
    return <>
        <Navbar bg="dark" variant="dark">
            <Container fluid>
                <Navbar.Brand>Cor Blimey Casino</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Item>
                        <Nav.Link href="112">Link 1</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link href="113">Link 2</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link href="114">Link 3</Nav.Link>
                    </Nav.Item>
                </Nav>
            </Container>
        </Navbar>
    </>
}

export const LoginContainer = () => {
    
}