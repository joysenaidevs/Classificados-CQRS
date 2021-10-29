import React from "react";
import './style.css'
import { Container, Navbar, Nav } from "react-bootstrap";

export const Header = () => {
    return(
        <Navbar bg="light" variant="light">
            <Container>
                <Navbar.Brand href="/listarprodutos">{"classificados".toUpperCase()}</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Link href="/listarprodutos">Produtos</Nav.Link>
                    <Nav.Link href="/anuncios">Anúncios</Nav.Link>
                    <Nav.Link href="/login">Sair</Nav.Link>
                </Nav>
            </Container>
        </Navbar>
    )
}
export default Header