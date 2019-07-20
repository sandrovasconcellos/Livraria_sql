using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Livraria.BLL;
using Livraria.Entidade;

namespace Livraria.BLL.Teste
{
    [TestClass]
    public class LivroBLLTesteCadastrar
    {
        [TestMethod]
        public void TestCadastrarLivro()
        {
            try
            {
                Livro l = new Livro();
                l.ISBN = "3333333333444";
                l.Autor = "Jose da Couves";
                l.Nome = "Caçada brutal";
                l.Preco = Convert.ToDecimal(12.20);
                l.DtPublicacao = Convert.ToDateTime("01/01/2019");
                LivroBLL lb = new LivroBLL();
                lb.Cadastrar(l);                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }
    }
}
