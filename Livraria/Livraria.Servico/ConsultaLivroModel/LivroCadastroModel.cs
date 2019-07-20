using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Servico.Models
{
    public class LivroCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o ISBN.")]
        [MinLength(13, ErrorMessage = "Por favor, informe o ISBN com {1} dígitos.")]
        [MaxLength(13, ErrorMessage = "Por favor, informe o ISBN com {1} dígitos.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Por favor, informe o autor.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de publicação.")]
        public DateTime DtPublicacao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a imagem da capa.")]
        public string ImagemCapa { get; set; }
        //public HttpPostedFileBase ImagemCapa { get; set; }
    }
}