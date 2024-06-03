using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class VeiculoController : Controller
    {

        private readonly IVeiculoWebApi _webApi;

        public VeiculoController(IVeiculoWebApi webApi)
        {
            _webApi = webApi;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarVeiculos(CancellationToken cancellationToken)
        {
            var veiculos = await _webApi.Listar(cancellationToken);

            return PartialView("Index", veiculos);
        }

        //// GET: VeiculoController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: VeiculoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: VeiculoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: VeiculoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: VeiculoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: VeiculoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: VeiculoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
