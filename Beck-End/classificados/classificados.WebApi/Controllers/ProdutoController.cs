 using classificados.Comum;
using classificados.Comum.Commands;
using classificados.Comum.Queries;
using classificados.Dominio.Commands.Produto;
using classificados.Dominio.Entidades;
using classificados.Dominio.Handlers.Produtos;
using classificados.Dominio.Queries.Produto;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace classificados.WebApi.Controllers
{
    /// <summary>
    /// Controlado responsavel pelos Pacotes
    /// </summary>
  

    // rota da API
    [Route("v1/product")]

    // Controlador API
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="command">command de produto</param>
        /// <param name="handle">handle de produto</param>
        /// <returns>retorna um novo produto cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Adimin")]
        public GenericCommandResult Criar(CadastrarProdutoCommand command, [FromServices] CadastrarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Lista todos os produtos existentes
        /// </summary>
        /// <param name="handle">handle de listar produto</param>
        /// <returns>retorna todos os produtos cadastrados</returns>
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarProdutoHandle handle)
        {
            //Criamos uma instancia nova da classe
            ListarProdutoAtivoQuery query = new ListarProdutoAtivoQuery();

            // identifcamos o tipo de usuario autenticado (nas claims)
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            //comparativo pra mostrar somente os ativos para o adm
            if (tipoUsuario.Value.ToString() == EnTipoUsuario.Adimin.ToString())
                query.Ativo = Comum.Enum.EnStatusProduto.Ativo; 

            return (GenericQueryResult)handle.Handler(query);
        }


        /// <summary>
        /// Lista todos os produtos de um determinado usuario
        /// </summary>
        /// <param name="handle">handle do produto</param>
        /// <returns>retorna somente os produtos do usuario</returns>
        [HttpGet("{id}")]
        [Authorize]
        public GenericQueryResult GetMy(Guid id, [FromServices] ListarMeusProdutosHandle handle)
        {
            // instanciamos a classe
            //ListarMeusProdutosQuery query = new ListarMeusProdutosQuery();

            ListarMeusProdutosQuery query = new ListarMeusProdutosQuery();
            query.idUsuario = id;
            query.ToString();
           
            return (GenericQueryResult)handle.Handler(query);



        }

        /// <summary>
        /// Deleta um produto existente
        /// </summary>
        /// <param name="command">command do meu deletar</param>
        /// <param name="handle">handle do meu deletar</param>
        /// <returns>retorna um produto excluido</returns>
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete(ExcluirProdutoCommand command, [FromServices] ExcluirProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="command">command do produto</param>
        /// <param name="handle">handle do produto</param>
        /// <returns>retorna um produto atualizado</returns>
        [HttpPut("{Id}")]
        [Authorize]
        public GenericCommandResult Alterar(AlterarProdutoCommand command, [FromServices] AlterarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [HttpGet("Nome")]
        [Authorize]
        public GenericQueryResult SearchForName([FromServices] BuscarPorNomeHandle handle)
        {
            //Criamos uma instancia nova da classe
            BuscarPorNomeQuery query = new BuscarPorNomeQuery();

            // identifcamos o tipo de usuario autenticado (nas claims)
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            return (GenericQueryResult)handle.Handler(query);
        }

        

    }
}
