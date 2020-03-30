using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.Data.Repository
{
    public class CompromissoRepository : ICompromissoRepository
    {

        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exercicio02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Alterar(Compromisso compromisso)
        {
            var query = "update Compromisso set Nome = @Nome, Localidade = @Localidade, DataHora = @DataHora, Descricao = @Descricao where IdCompromisso = @IdCompromisso";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, compromisso);
            }
        }

        public List<Compromisso> Consultar()
        {
            var query = "select * from Compromisso";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Compromisso>(query).ToList();
            }
        }

        public void Excluir(Compromisso compromisso)
        {
            var query = "delete from Compromisso where IdCompromisso = @IdCompromisso";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, compromisso);
            }
        }

        public void Inserir(Compromisso compromisso)
        {
            var query = "insert into Compromisso(Nome, Localidade, DataHora, Descricao) values (@Nome, @Localidade, @DataHora, @Descricao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, compromisso);
            }
        }

        public Compromisso ObterPorID(int idCompromisso)
        {
            var query = "select * from Compromisso where IdCompromisso = @IdCompromisso";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Compromisso>(query, new { idCompromisso }).FirstOrDefault();
            }
        }
    }
}
