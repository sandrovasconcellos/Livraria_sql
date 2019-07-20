//PROJETO UTILIZANDO OS ESTUDOS DO PROJETO 12 DE 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Entidade
{
    public class Livro
    {
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DtPublicacao { get; set; }
        public string ImagemCapa { get; set; }

        public Livro()
        {
            //vazio
        }

        public Livro(string iSBN, string autor, string nome, decimal preco, DateTime dtPublicacao, string imagemCapa)
        {
            ISBN = iSBN;
            Autor = autor;
            Nome = nome;
            Preco = preco;
            DtPublicacao = dtPublicacao;
            ImagemCapa = imagemCapa;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Autor: {Autor}, Nome: {Nome}, Preço: {Preco}, Data de Publicação: {DtPublicacao}";
        }
    }
}
