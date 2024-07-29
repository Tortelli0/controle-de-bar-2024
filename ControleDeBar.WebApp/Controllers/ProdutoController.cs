using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloProduto;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class ProdutoController : Controller
{
    public ViewResult Listar()
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        ViewBag.Produtos = produtos;

        return View();
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(Produto novoProduto)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        repositorioProduto.Inserir(novoProduto);

        ViewBag.Mensagem = $"O registro com o ID {novoProduto.Id} foi cadastrado com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View("mensagens");
    }

    public ViewResult Editar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Produto produtoAtualizado)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produtoOriginal = repositorioProduto.SelecionarPorId(id);

        repositorioProduto.Editar(produtoOriginal, produtoAtualizado);

        ViewBag.Mensagem = $"O registro com o ID {produtoOriginal.Id} foi editado com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View();
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Mensagem = $"O registro com o ID {produto.Id} foi excluído com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View("mensagens");
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }
}

