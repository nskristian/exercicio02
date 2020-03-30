using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities;

namespace Projeto.Data.Contracts
{
    interface ICompromissoRepository
    {
        void Inserir(Compromisso compromisso);
        void Alterar(Compromisso compromisso);
        void Excluir(Compromisso compromisso);
        List<Compromisso> Consultar();
        Compromisso ObterPorID(int idCompromisso);
    }
}
