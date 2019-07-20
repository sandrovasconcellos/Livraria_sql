using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Livraria.Entidade;
using Livraria.BLL;
using Livraria.Servico.Models;

namespace Livraria.Servico.Controllers
{
    [RoutePrefix("api/livro")] //URL..
    public class LivroController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(LivroCadastrarModel model)
        {
            //verificar se os dados mda model passaram nas validações..
            if (ModelState.IsValid)
            {
                try
                {
                    Livro l = new Livro();
                    l.ISBN = model.ISBN;
                    l.Autor = model.Autor;
                    l.Nome = model.Nome;
                    l.Preco = model.Preco;
                    l.DtPublicacao = model.DtPublicacao;
                    l.ImagemCapa = model.ImagemCapa;

                    LivroBLL lbll = new LivroBLL();
                    lbll.Cadastrar(l);

                    //retornar status http 200 (sucesso)
                    return Request.CreateResponse(HttpStatusCode.OK, "Livro cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                }

            }

            else
            {
                //retornar status HTTP 400 (Requisição inválida)
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    ModelState.Values.SelectMany(e => e.Errors.Select(s => s.ErrorMessage)));

            }
        }

        [Route("atualizar")]
        [HttpPut] //Put
        public HttpResponseMessage Atualizar(LivroCadastrarModel model)
        {
            //verificar se os dados mda model passaram nas validações..
            if (ModelState.IsValid)
            {
                try
                {
                    LivroBLL lb = new LivroBLL();
                    Livro l = new Livro();
                    l.ISBN = model.ISBN;
                    l.Autor = model.Autor;
                    l.Nome = model.Nome;
                    l.Preco = model.Preco;
                    l.DtPublicacao = model.DtPublicacao;
                    l.ImagemCapa = model.ImagemCapa;
                    lb.Alterar(l);

                    return Request.CreateResponse(HttpStatusCode.OK, "Livro atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                }
               
                
            }

            else
            {
                //retornar status HTTP 400 (Requisição inválida)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(e => e.Errors.Select(s => s.ErrorMessage)));
            }
        }

        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(string isbn)
        {
            try
            {
                LivroBLL lb = new LivroBLL();
                lb.Excluir(isbn);

                return Request.CreateResponse(HttpStatusCode.OK, "Livro excluido com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            
        }

        [Route("consultartodos")]
        [HttpGet] // GET
        public HttpResponseMessage ConsultarTodos()
        {            
            try
            {
                List<LivroConsultarModel> listaModel = new List<LivroConsultarModel>();
                LivroBLL lb = new LivroBLL();
                foreach (Livro l in lb.ConsultarTodos())
                {
                    LivroConsultarModel model = new LivroConsultarModel();
                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = l.DtPublicacao;
                    model.ImagemCapa = l.ImagemCapa;
                    listaModel.Add(model);
                }
                //retornando um status de sucesso contendo a lista..
                return Request.CreateResponse(HttpStatusCode.OK, listaModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);            
            }           
        }

        [Route("consultarporisbn")]
        [HttpGet] //GET
        public HttpResponseMessage ConsultarPorISBN(string isbn)
        {
            try
            {
                LivroBLL lb = new LivroBLL();
                Livro l = lb.ConsultarPorISBN(isbn);
                LivroConsultarModel lModel = new LivroConsultarModel();
                lModel.ISBN = l.ISBN;
                lModel.Autor = l.Autor;
                lModel.Nome = l.Nome;
                lModel.Preco = l.Preco;
                lModel.DtPublicacao = l.DtPublicacao;
                lModel.ImagemCapa = l.ImagemCapa;

                return Request.CreateResponse(HttpStatusCode.OK,lModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
             
            }            
        }

        //ISBN, Autor, Nome, 
        [Route("consultarporatributo")]
        [HttpGet] // GET
        public HttpResponseMessage ConsultarPorAtributo(ConsultaAtributosEnum atributo, string descricao)
        {
            try
            {
                List<LivroConsultarModel> listaModel = new List<LivroConsultarModel>();
                LivroBLL lb = new LivroBLL();
                foreach (Livro l in lb.ConsultaPorAtributo(atributo, descricao))
                {
                    LivroConsultarModel model = new LivroConsultarModel();
                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = l.DtPublicacao;
                    model.ImagemCapa = l.ImagemCapa;
                    listaModel.Add(model);
                }
                //retornando um status de sucesso contendo a lista..
                return Request.CreateResponse(HttpStatusCode.OK, listaModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("ordenarporatributo")]
        [HttpGet] // GET
        public HttpResponseMessage OrdenarPorAtributo(OrdenaAtributoEnum atributo)
        {
            try
            {
                List<LivroConsultarModel> listaModel = new List<LivroConsultarModel>();
                LivroBLL lb = new LivroBLL();
                foreach (Livro l in lb.OrdenarPorAtributo(atributo))
                {
                    LivroConsultarModel model = new LivroConsultarModel();
                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = l.DtPublicacao;
                    model.ImagemCapa = l.ImagemCapa;
                    listaModel.Add(model);
                }
                //retornando um status de sucesso contendo a lista..
                return Request.CreateResponse(HttpStatusCode.OK, listaModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("consultarpordatapublicacao")]
        [HttpGet] // GET
        public HttpResponseMessage ConsultarPorDataPublicao(DateTime dtIni, DateTime dtFim)
        {
            try
            {
                List<LivroConsultarModel> listaModel = new List<LivroConsultarModel>();
                LivroBLL lb = new LivroBLL();
                foreach (Livro l in lb.ConsultarPorDataPublicao(dtIni, dtFim))
                {
                    LivroConsultarModel model = new LivroConsultarModel();
                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = l.DtPublicacao;
                    model.ImagemCapa = l.ImagemCapa;
                    listaModel.Add(model);
                }
                //retornando um status de sucesso contendo a lista..
                return Request.CreateResponse(HttpStatusCode.OK, listaModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [Route("consultarporpreco")]
        [HttpGet] // GET
        public HttpResponseMessage ConsultarPorPreco(decimal prIni, decimal prFim)
        {
            try
            {
                List<LivroConsultarModel> listaModel = new List<LivroConsultarModel>();
                LivroBLL lb = new LivroBLL();
                foreach (Livro l in lb.ConsultarPorPreco(prIni, prFim))
                {
                    LivroConsultarModel model = new LivroConsultarModel();
                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = l.DtPublicacao;
                    model.ImagemCapa = l.ImagemCapa;
                    listaModel.Add(model);
                }
                //retornando um status de sucesso contendo a lista..
                return Request.CreateResponse(HttpStatusCode.OK, listaModel);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
