using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class GarcomController : Controller
{
    public ViewResult Listar()
    {
        var dbContext = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);

        var garcons = repositorioGarcom.SelecionarTodos();

        ViewBag.Garcons = garcons;

        return View();
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(Garcom garcom)
    {
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        repositorioGarcom.Inserir(garcom);

        ViewBag.Mensagem = $"O registro com o ID [{garcom.Id}] foi cadastrado com sucesso!";
        ViewBag.Link = "/garcom/listar";

        return View("mensagens");
    }

    public ViewResult Editar(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioGarcom repositorioGarcom = new RepositorioGarcomEmOrm(db);

        Garcom garcom = repositorioGarcom.SelecionarPorId(id);

        ViewBag.Garcom = garcom;

        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Garcom garcomAtualizado)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioGarcom repositorioGarcom = new RepositorioGarcomEmOrm(db);

        Garcom garcomOriginal = repositorioGarcom.SelecionarPorId(id);

        repositorioGarcom.Editar(garcomOriginal, garcomAtualizado);

        ViewBag.Mensagem = $"O registro com o ID {garcomOriginal.Id} foi editado com sucesso!";
        ViewBag.Link = "/garcom/listar";

        return View("mensagens");
    }

    public ViewResult Excluir(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioGarcom repositorioGarcom = new RepositorioGarcomEmOrm(db);

        Garcom garcom = repositorioGarcom.SelecionarPorId(id);

        ViewBag.Garcom = garcom;

        return View();
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioGarcom repositorioGarcom = new RepositorioGarcomEmOrm(db);

        Garcom garcom = repositorioGarcom.SelecionarPorId(id);

        ViewBag.Mensagem = $"O registro com o ID {garcom.Id} foi excluído com sucesso!";
        ViewBag.Link = "/garcom/listar";

        return View("mensagens");
    }

    public ViewResult Detalhes(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioGarcom repositorioGarcom = new RepositorioGarcomEmOrm(db);

        Garcom garcom = repositorioGarcom.SelecionarPorId(id);

        ViewBag.Garcom = garcom;

        return View();
    }
}