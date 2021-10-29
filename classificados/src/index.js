import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import reportWebVitals from './reportWebVitals';
import TelaLogin from './pages/TelaLogin';
import ListaProdutos from './pages/ListaProdutos';
import Header from './components/header';
import ProdutosAnunciados from './pages/ProdutosAnunciados';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom' ;
import TelaCadastro from './pages/TelaCadastro';

// const routing = (
//   <Router>
//     <div>
//       <Switch>
//         <Route exact path="/" component={ListaProdutos}/>
//         <Route exact path="/listarprodutos" component={ListaProdutos}/>
//         <Route exact path="/produtosanunciados" component={ProdutosAnunciados}/>
//       </Switch>
//     </div>
//   </Router>
// )

ReactDOM.render(
  <React.StrictMode>
    <Router>
    <div>
      <Switch>
        <Route exact path="/" component={TelaLogin}/>
        <Route exact path="/login" component={TelaLogin}/>
        <Route exact path="/cadastro" component={TelaCadastro}/>
        <Route exact path="/listarprodutos" component={ListaProdutos}/>
        <Route exact path="/anuncios" component={ProdutosAnunciados}/>
      </Switch>
    </div>
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
