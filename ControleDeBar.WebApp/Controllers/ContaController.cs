using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class ContaController : Controller
{
    public ViewResult Listar()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        List<Conta> contas = repositorioConta.SelecionarContas();

        ViewBag.Contas = contas;

        return View();
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(Conta conta)
    {
        var db = new ControleDeBarDbContext();
        var repositorioConta = new RepositorioContaEmOrm(db);

        repositorioConta.Inserir(conta);
        
        ViewBag.Mensagem = $"O registro com o ID [{conta.Id}] foi cadastrado com sucesso!";
        ViewBag.Link = "/conta/listar";

		return View("mensagens");
    }

    public ViewResult Editar(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        Conta conta = repositorioConta.SelecionarPorId(id);

        ViewBag.Conta = conta;

        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Conta contaAtualizada, List<Pedido> pedidosRemovidos)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        Conta contaOriginal = repositorioConta.SelecionarPorId(id);

        repositorioConta.AtualizarPedidos(contaAtualizada, pedidosRemovidos);

		ViewBag.Mensagem = $"O registro com o ID {contaOriginal.Id} foi editado com sucesso!";
		ViewBag.Link = "/conta/listar";

		return View();
    }

    public ViewResult Excluir(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        Conta conta = repositorioConta.SelecionarPorId(id);

        ViewBag.Conta = conta;

        return View();
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        Conta conta = repositorioConta.SelecionarPorId(id);

		ViewBag.Mensagem = $"O registro com o ID {conta.Id} foi excluído com sucesso!";
		ViewBag.Link = "/conta/listar";

		return View("mensagens");
    }

    public ViewResult Detalhes(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioConta repositorioConta = new RepositorioContaEmOrm(db);

        Conta conta = repositorioConta.SelecionarPorId(id);

        ViewBag.Conta = conta;

        return View();
    }
}
