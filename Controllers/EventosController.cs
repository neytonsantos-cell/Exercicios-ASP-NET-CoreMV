using Exercicios_ASP_NET_CoreMVC.Models;
using Exercicios_ASP_NET_CoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Exercicios_ASP_NET_CoreMVC.Controllers
{
    [Route("[controller]")]
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new()
        {
            new Evento { Id = 1, Nome = "Show do BTS", Descricao = "O melhor show do BTS no Brasil.", Local = "São Paulo", DataEvento = new DateTime(2026, 12, 15), QuantidadeVagas = 100, ValorIngresso = 100.00m},
            new Evento { Id = 2, Nome = "Show do Belo", Descricao = "O melhor show do Belo no Brasil.", Local = "Mauá", DataEvento = new DateTime(2026, 11, 23), QuantidadeVagas = 500, ValorIngresso = 150.00m},
            new Evento { Id = 3, Nome = "Show do VIXX", Descricao = "O melhor show do VIXX no Brasil.", Local = "São Caetano do Sul", DataEvento = new DateTime(2027, 03, 22), QuantidadeVagas = 900, ValorIngresso = 200.00m}
        };


        public IActionResult Index()
        {
            return View(_eventos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento);
            }
            evento.Id = _eventos.Max(e => e.Id) + 1;
            _eventos.Add(evento);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }
        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel modelo)
        {
            var consulta = _eventos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(modelo.NomeBusca))
            {
                consulta = consulta.Where(e =>
                    e.Nome.Contains(modelo.NomeBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(modelo.LocalBusca))
            {
                consulta = consulta.Where(e =>
                    e.Local.Contains(modelo.LocalBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (modelo.DataInicial.HasValue)
            {
                consulta = consulta.Where(e => e.DataEvento.Date >= modelo.DataInicial.Value.Date);
            }

            modelo.Resultados = consulta.ToList();
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

    }

}