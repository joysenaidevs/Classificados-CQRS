import React,{useState} from "react";
import { Card, Button, Form, Modal, Image, Row, Col, Container} from "react-bootstrap";
import img from '../../Imagens/headset.png';
import img1 from '../../Imagens/notebook.png'
import './style.css'

export const Produtos = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);


    const [produto, setProduto] = useState('');

    

    return(
        <>
            {/* PRODUTOS */}
                <Form id="form">
                    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                        <Form.Control type="text" placeholder="Buscar produto" value={produto} onChange={(event) => {setProduto(event.target.value)}}/>
                        <Button variant="primary" type="submit">
                        Buscar
                        </Button>
                    </Form.Group>
                </Form> 
                
                <Card style={{ width: '18rem', padding:"15px"}}>
                    <Card.Img variant="top" src={img} />
                    <Card.Body>
                        <Card.Title>Headset Red Dragon</Card.Title>
                            <Card.Text >
                                R$ 379,00
                            </Card.Text>
                        <Button variant="primary" onClick={handleShow}>Detalhes</Button>
                    </Card.Body>
                </Card>

                <Card style={{ width: '18rem', padding:"15px"}}>
                    <Card.Img variant="top" src={img1} />
                    <Card.Body>
                        <Card.Title>Notebook Acer Aspire</Card.Title>
                            <Card.Text >
                                R$ 5.599,00
                            </Card.Text>
                        <Button variant="primary" onClick={handleShow}>Detalhes</Button>
                    </Card.Body>
                </Card>
            {/* MODAL */}
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title style={{color : "#717DA7"}}>Headset Red Dragon</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Container>
                        <Row >
                            <Col><Image src={img} thumbnail /></Col>
                            <Col>
                                <h2 style={{fontSize : "20px", color : "#717DA7"}}><p>Headset gamer Red Dragon</p></h2>
                                <p style={{color : "#717DA7"}}>Headset gamer Red Dragon Zeus 2 preto e vermelho</p>
                                <p style={{fontWeight : "700", color : "#717DA7"}}>R$ 379,00</p>
                            </Col>
                        </Row>
                    </Container>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancelar
                    </Button>
                    <Button variant="primary" onClick={handleClose}>
                        Reservar
                    </Button>
                </Modal.Footer>
            </Modal>

        </>
    )
}

export default Produtos