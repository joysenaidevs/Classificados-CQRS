import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import Produtos from "../../components/produtos";
import Header from "../../components/header";

export const ListaProdutos = () => {

    return(
        <>
        <Header />
        <Container>
            <Row>
                <Produtos/>
            </Row>
        </Container>
        </>
    )
}

export default ListaProdutos;