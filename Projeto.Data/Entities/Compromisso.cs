using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Compromisso
    {
        public int IdCompromisso { get; set; }
        public String Nome { get; set; }
        public String Localidade { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
    }
}
