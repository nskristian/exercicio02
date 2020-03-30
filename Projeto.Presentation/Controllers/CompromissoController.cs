using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Models;
using Projeto.Data.Entities;
using Projeto.Data.Repository;

namespace Projeto.Presentation.Controllers
{
    public class CompromissoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastrarCompromissoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var compromisso = new Compromisso
                    {
                        Nome = model.Nome,
                        Localidade = model.Localidade,
                        DataHora = model.DataHora,
                        Descricao = model.Descricao
                    };

                    var compromissoRepository = new CompromissoRepository();
                    compromissoRepository.Inserir(compromisso);

                    TempData["Mensagem"] = "Compromisso cadastrado com sucesso!";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }
            }
            return View();
        }

        public IActionResult Consulta()
        {
            var lista = new List<Compromisso>();

            try
            {
                var compromissoRepository = new CompromissoRepository();
                lista = compromissoRepository.Consultar();
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }
            return View(lista);
        }

        public IActionResult Exclusao(int id)
        {
            try
            {
                var compromissoRepository = new CompromissoRepository();
                var compromisso = compromissoRepository.ObterPorID(id);

                if (compromisso != null)
                {
                    compromissoRepository.Excluir(compromisso);

                    TempData["Mensagem"] = "Compromisso: " + compromisso.Nome + " excluido com sucesso!";
                }
                else
                {
                    TempData["Mensagem"] = "Compromisso não encontrado!";
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }
            return RedirectToAction("Consulta");
        }

        public IActionResult Edicao(int id)
        {
            var model = new EditarCompromissoModel();

            try
            {
                var compromissoRepository = new CompromissoRepository();
                var compromisso = compromissoRepository.ObterPorID(id);

                if (compromisso != null)
                {
                    model.IdCompromisso = compromisso.IdCompromisso;
                    model.Nome = compromisso.Nome;
                    model.Localidade = compromisso.Localidade;
                    model.DataHora = compromisso.DataHora;
                    model.Descricao = compromisso.Descricao;
                }
                else
                {
                    TempData["Mensagem"] = "Compromisso não foi encontrado!";
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(EditarCompromissoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var compromisso = new Compromisso();

                    compromisso.IdCompromisso = model.IdCompromisso;
                    compromisso.Nome = model.Nome;
                    compromisso.Localidade = model.Localidade;
                    compromisso.DataHora = model.DataHora;
                    compromisso.Descricao = model.Descricao;

                    var compromissoRepository = new CompromissoRepository();
                    compromissoRepository.Alterar(compromisso);

                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }
            }
            return View();
        }
    }
}