using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class AddLojaController : Controller
    {

        public ActionResult Salvar(string nome)
        {
            var teste = "";

            return NoContent();
        }

        // GET: AddLojaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddLojaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddLojaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddLojaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddLojaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddLojaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddLojaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddLojaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
