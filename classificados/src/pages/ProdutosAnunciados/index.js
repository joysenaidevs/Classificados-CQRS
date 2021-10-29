import React from "react";
import MeusProdutos from "../../components/meusProdutos";
import { Row, Container } from "react-bootstrap";
import Header from "../../components/header";


export const ProdutosAnunciados = () => {
    return(
        <>
            <Header />
            <Container>
                <Row>
                    <MeusProdutos />
                </Row>
            </Container>
        </>
    )
}

export default ProdutosAnunciados;