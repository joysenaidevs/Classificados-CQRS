import React from "react";
import { Container, Col, Row } from "react-bootstrap";
import Cadastro from "../../components/cadastro";

export const TelaCadastro = () => {
    return(
        <>
            <Container>
                <Row>
                    <Cadastro/>
                </Row>
            </Container>
        </>
    )
}

export default TelaCadastro