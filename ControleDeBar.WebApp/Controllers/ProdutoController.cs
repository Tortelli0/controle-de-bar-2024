using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloProduto;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class ProdutoController : Controller
{
    public ViewResult Listar()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

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
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        repositorioProduto.Inserir(novoProduto);

        ViewBag.Mensagem = $"O registro com o ID {novoProduto.Id} foi cadastrado com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View("mensagens");
    }

    public ViewResult Editar(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        Produto produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Produto produtoAtualizado)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        Produto produtoOriginal = repositorioProduto.SelecionarPorId(id);

        repositorioProduto.Editar(produtoOriginal, produtoAtualizado);

        ViewBag.Mensagem = $"O registro com o ID {produtoOriginal.Id} foi editado com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View();
    }

    public ViewResult Excluir(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        Produto produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        Produto produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Mensagem = $"O registro com o ID {produto.Id} foi excluído com sucesso!";
        ViewBag.Link = "/produto/listar";

        return View("mensagens");
    }

    public ViewResult Detalhes(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmOrm(db);

        Produto produto = repositorioProduto.SelecionarPorId(id);

        ViewBag.Produto = produto;

        return View();
    }
}

