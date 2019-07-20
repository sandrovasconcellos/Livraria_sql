using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Livraria.Entidade;

namespace Livraria.DAL
{
    public class LivroDAL : Conexao
    {
        public void Cadastrar(Livro l)
        {
            try
            {
                AbrirConexao();

                string sql = "insert into Livro (ISBN, Autor, Nome, Preco, DtPublicacao, ImagemCapa) " +
                             "values(@ISBN, @Autor, @Nome, @Preco, @DtPublicacao, @ImagemCapa)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ISBN", l.ISBN);
                cmd.Parameters.AddWithValue("@Autor", l.Autor);
                cmd.Parameters.AddWithValue("@Nome", l.Nome);
                cmd.Parameters.AddWithValue("@Preco", l.Preco);
                cmd.Parameters.AddWithValue("@DtPublicacao", l.DtPublicacao);
                cmd.Parameters.AddWithValue("@ImagemCapa", l.ImagemCapa);
                
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar o livro. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Alterar(Livro l)
        {
            try
            {
                AbrirConexao();

                string sql = "update Livro set Autor = @Autor, Nome = @Nome, Preco = @Preco, DtPublicacao = @DtPublicacao, " +
                             "ImagemCapa = @ImagemCapa where @ISBN = ISBN";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Autor", l.Autor);
                cmd.Parameters.AddWithValue("@Nome", l.Nome);
                cmd.Parameters.AddWithValue("@Preco", l.Preco);
                cmd.Parameters.AddWithValue("@DtPublicacao", l.DtPublicacao);                
                cmd.Parameters.AddWithValue("@ImagemCapa", l.ImagemCapa);                
                cmd.Parameters.AddWithValue("@ISBN", l.ISBN);

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao alterar o livro. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(string isbn)
        {
            try
            {
                AbrirConexao();

                string sql = "delete Livro where @ISBN = ISBN";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Excluir o livro. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Livro> ConsultarTodos()
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    lista.Add(l);
                }                
                return lista;            
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar todos os livros. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Livro ConsultarPorISBN(string isbn)
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro where isbn = @isbn";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);                  
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    return l;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar livro por ISBN. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Livro> ConsultaPorAtributo(ConsultaAtributosEnum filtro, string descricao)
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro ";

                if (filtro.ToString() == "ISBN")
                {
                    sql += "WHERE ISBN like '%" + descricao + "%'";
                }
                else if (filtro.ToString() == "Nome")
                {
                    sql += "WHERE Nome like '%" + descricao + "%'";
                }
                else if (filtro.ToString() == "Autor")
                {
                    sql += "WHERE Autor like '%" + descricao + "%'";
                }

                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    lista.Add(l);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar livros por atributo. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }         
        }

        public List<Livro> OrdenarPorAtributo(OrdenaAtributoEnum filtro)
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro order by " + filtro;

                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    lista.Add(l);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar na ordenaçao dos livros. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Livro> ConsultarPorDataPublicao(DateTime dtIni, DateTime dtFim)
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro where dtPublicacao between '" + dtIni + "' and '" + dtFim + "'";

                cmd = new SqlCommand(sql, con);               
                dr = cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    lista.Add(l);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar livros data de publicação. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Livro> ConsultarPorPreco(decimal prIni, decimal prFim)
        {
            try
            {
                AbrirConexao();

                string sql = "Select * from Livro where Preco between " + prIni + " and " + prFim;

                cmd = new SqlCommand(sql, con);                
                dr = cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.ISBN = dr["ISBN"].ToString().Trim();
                    l.Autor = dr["Autor"].ToString().Trim();
                    l.Nome = dr["Nome"].ToString().Trim();
                    l.Preco = Convert.ToDecimal(dr["Preco"]);
                    l.DtPublicacao = Convert.ToDateTime(dr["DtPublicacao"]);
                    l.ImagemCapa = dr["ImagemCapa"].ToString().Trim();

                    lista.Add(l);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar livros por preço. \n" + "Descrição: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
