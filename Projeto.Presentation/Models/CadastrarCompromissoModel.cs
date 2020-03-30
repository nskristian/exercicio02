using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class CadastrarCompromissoModel
    {
        [MaxLength(150, ErrorMessage = "Máximo de {1} caracteres")]
        [MinLength(6,ErrorMessage = "Minimo de {1} caracteres")]
        [Required(ErrorMessage ="Favor informar o nome do compromisso")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage = "Minimo de {1} caracteres")]
        [Required(ErrorMessage ="Favor informar a localidade")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "Favor informar a data e hora")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Favor informar a Descrição")]
        public string Descricao { get; set; }
    }
}
