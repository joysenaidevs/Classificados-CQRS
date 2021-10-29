import {React} from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import Login from '../../components/login'
import "./style.css"

export const TelaLogin = () => {
    return(
        <div className="dd">
            <Container>
                <Row>
                    <Login/>
                </Row>
            </Container>
        </div>
    )
}
export default TelaLogin