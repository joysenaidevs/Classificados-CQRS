import React from "react";
import { Form, Button } from "react-bootstrap";
import './style.css'

export const CadastrarProduto = () => {
    return(
        <>
            <Form id="form-cadastrar">
                <h3><p>Anunciar Produto</p></h3>
                <Form.Group className="mb-3 form-cadastro" controlId="exampleForm.ControlInput1">
                    <div className="div-form">
                        <div>
                            <Form.Label>Nome do Produto</Form.Label>
                            <Form.Control type="text" placeholder="Nome do Produto" style={{width:"30vw"}}/>
                        </div>
                        <div style={{marginLeft:"7vw"}}>
                            <Form.Label>Preço do Produto</Form.Label>
                            <Form.Control type="number" placeholder="Preço do Produto" style={{width:"30vw"}}/>
                        </div>
                    </div>
                </Form.Group>
                <Form.Group className="mb-3 form-cadastro" controlId="exampleForm.ControlTextarea1">
                    <Form.Label>Descrição</Form.Label>
                    <Form.Control as="textarea" rows={3} style={{resize : "none", height : "20vh"}}/>
                </Form.Group>
                <Form.Group controlId="formFile " className="mb-3 form-cadastro">
                    <Form.Label>Insira sua imagem</Form.Label>
                    <Form.Control type="file" />
                </Form.Group>
                <div className="btn-formCadastro">
                    <Button variant="primary" type="submit" id="btn-cadastrar">
                        Cadastrar
                    </Button>
                </div>
            </Form>
        </>
    )
}
export default CadastrarProduto