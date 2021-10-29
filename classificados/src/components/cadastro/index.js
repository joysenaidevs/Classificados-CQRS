import React from "react";
import { Form, Button} from "react-bootstrap";
import "./style.css"
import { useHistory } from "react-router";

export const Cadastro = () => {
    const history = useHistory();
    const EfetuarLogin = () =>{
        history.push("/listarprodutos");
    }
    return(
        <>
            <Form id="form-geral-login" onSubmit={EfetuarLogin}>
                <div className="titulo-login">
                    <h3>{"classificados".toUpperCase()}</h3>
                </div>
                <div class="login-div">
                    <Form.Group className="mb-3 form-login" controlId="formBasicEmail" style={{height:"7vh"}}>
                        <Form.Control type="text" placeholder="Nome" />
                    </Form.Group>

                    <Form.Group className="mb-3 form-login" controlId="formBasicPassword" style={{height:"7vh"}}>
                        <Form.Control type="email" placeholder="Email" />
                    </Form.Group>

                    <Form.Group className="mb-3 form-login" controlId="formBasicPassword" style={{height:"7vh"}}>
                        <Form.Control type="password" placeholder="Senha" />
                    </Form.Group>
                </div>
                <a href="/login" className="link-login">Voltar</a>
                <Button variant="primary" type="submit">
                    Login
                </Button>
            </Form>
        </>
    )
}

export default Cadastro