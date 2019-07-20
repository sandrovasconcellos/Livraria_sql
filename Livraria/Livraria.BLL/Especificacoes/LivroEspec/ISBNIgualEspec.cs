using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;
using Livraria.DAL;
   

namespace Livraria.BLL.Especificacoes.LivroEspec
{
    class ISBNIgualEspec
    {
        public static bool IsValid(Livro l)
        {
            
            LivroDAL ld = new LivroDAL();
            Livro result = ld.ConsultarPorISBN(l.ISBN);

            if (result != null)
            {
                throw new Exception("Já existe livro com esse ISBN.");
            }

            return true;
        }

    }
}
