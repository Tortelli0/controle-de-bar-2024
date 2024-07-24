using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
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
    }
}
