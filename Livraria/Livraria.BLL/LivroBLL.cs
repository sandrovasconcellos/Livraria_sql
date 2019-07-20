using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;
using Livraria.DAL;
using Livraria.BLL.Especificacoes.LivroEspec;

namespace Livraria.BLL
{
    public class LivroBLL
    {
        public void Cadastrar(Livro l)
        {
            if (ISBNIgualEspec.IsValid(l))
            {
                if (l.ImagemCapa == null)
                {
                    l.ImagemCapa = "";
                }
                LivroDAL ld = new LivroDAL();
                ld.Cadastrar(l);
            }
        }

        public void Alterar(Livro l)
        {
            LivroDAL ld = new LivroDAL();
            Livro resgitroBanco = ld.ConsultarPorISBN(l.ISBN);

            if(resgitroBanco != null)
            {                
                resgitroBanco.ISBN = l.ISBN;
                resgitroBanco.Autor = l.Autor;
                resgitroBanco.Nome = l.Nome;
                resgitroBanco.Preco = l.Preco;
                resgitroBanco.DtPublicacao = l.DtPublicacao;             
                if (l.ImagemCapa == null)
                {
                    resgitroBanco.ImagemCapa = "";
                }
                else
                {
                    resgitroBanco.ImagemCapa = l.ImagemCapa;
                }
                ld.Alterar(l);                
            }            
        }
        
        public void Excluir(string isbn)
        {
            LivroDAL ld = new LivroDAL();
            ld.Excluir(isbn);
        }

        public List<Livro> ConsultarTodos()
        {
            LivroDAL ld = new LivroDAL();
            List<Livro> lista = new List<Livro>();
            lista = ld.ConsultarTodos();

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }

        public Livro ConsultarPorISBN(string isbn)
        {
            LivroDAL ld = new LivroDAL();
            Livro l = ld.ConsultarPorISBN(isbn);

            if (l != null)
            {
                return l;
            }
            else
            {
                throw new Exception("livro não encontrado.");
            }
        }

        public List<Livro> ConsultaPorAtributo(ConsultaAtributosEnum filtro, string descricao)
        {
            LivroDAL ld = new LivroDAL();
            List<Livro> lista = new List<Livro>();
            lista = ld.ConsultaPorAtributo(filtro, descricao);

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }
        public List<Livro> OrdenarPorAtributo(OrdenaAtributoEnum filtro)
        {
            LivroDAL ld = new LivroDAL();
            List<Livro> lista = new List<Livro>();
            lista = ld.OrdenarPorAtributo(filtro);

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }

        public List<Livro> ConsultarPorDataPublicao(DateTime dtIni, DateTime dtFim)
        {
            LivroDAL ld = new LivroDAL();
            List<Livro> lista = new List<Livro>();
            lista = ld.ConsultarPorDataPublicao(dtIni, dtFim);

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }

        public List<Livro> ConsultarPorPreco(decimal prIni, decimal prFim)
        {
            LivroDAL ld = new LivroDAL();
            List<Livro> lista = new List<Livro>();
            lista = ld.ConsultarPorPreco(prIni, prFim);

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }
    }
}
