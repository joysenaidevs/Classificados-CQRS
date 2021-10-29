import React, {useState} from "react";
import { Form, Card, Button, ButtonGroup, Modal, Row, Container, Col, Image } from "react-bootstrap";
import img from '../../Imagens/headset.png';
import img1 from '../../Imagens/notebook.png'
import CadastrarProduto from "../cadastrarProduto";

export const MeusProdutos = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return(
        <>
            <CadastrarProduto/>
            <Form id="form">
                <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                    <Form.Control type="text" placeholder="Buscar produto" />
                    <Button variant="primary" type="submit">
                    Buscar
                    </Button>
                </Form.Group>
            </Form> 

            <h2><p>Produtos Anunciados</p></h2>
            
            <Card style={{ width: '18rem', padding:"15px"}}>
                <Card.Img variant="top" src={img} />
                <Card.Body>
                    <Card.Title>Headset Red Dragon</Card.Title>
                        <Card.Text >
                            R$ 379,00
                        </Card.Text>
                    <ButtonGroup aria-label="Basic example">
                        <Button variant="primary" onClick={handleShow} id="btn-alterar">Alterar</Button>
                        <Button variant="primary" id="btn-delete">Deletar</Button>
                    </ButtonGroup>
                </Card.Body>
            </Card>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title style={{color : "#717DA7"}}>Headset Red Dragon</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                        <Form id="form-cadastrar">
                        <h3><p>Anunciar Produto</p></h3>
                        <Form.Group className="mb-3 form-cadastro" controlId="exampleForm.ControlInput1">
                                <div>
                                    <Form.Label>Nome do Produto</Form.Label>
                                    <Form.Control type="text" placeholder="Nome do Produto" style={{width:"21.7vw"}}/>
                                </div>
                                <div >
                                    <Form.Label style={{marginTop:"2vh"}}>Preço do Produto</Form.Label>
                                    <Form.Control type="number" placeholder="Preço do Produto" style={{width:"21.7vw"}}/>
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
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <ButtonGroup>
                        <Button variant="secondary" onClick={handleClose} id="btn-delete">
                            Cancelar
                        </Button>
                        <Button variant="primary" onClick={handleClose} id="btn-alterar">
                            Reservar
                        </Button>
                    </ButtonGroup>
                </Modal.Footer>
            </Modal>
                
        </>
    )
}
export default MeusProdutos