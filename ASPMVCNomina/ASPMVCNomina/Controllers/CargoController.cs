using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPMVCNomina.NominaData;

namespace ASPMVCNomina.Controllers
{
    public class CargoController : Controller
    {
        private Entities db = new Entities();

        // GET: Cargo
        public async Task<ActionResult> Index()
        {
            return View(await db.Cargoes.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Search()
        {
            ViewBag.Search = true;

            var stringSearch = Request["txtSearch"];
            return View("Index", await db.Cargoes.
                                 Where(x=> x.Nombre.ToLower().
                                 Contains(stringSearch.ToLower())).
                                 ToListAsync());
        }

        // GET: Cargo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = await db.Cargoes.FindAsync(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Estado,Valor_Cargo")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargo.Id_Cargo = db.Cargoes.Max(x => x.Id_Cargo) + 1;
                db.Cargoes.Add(cargo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = await db.Cargoes.FindAsync(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Cargo,Nombre,Estado,Valor_Cargo")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = await db.Cargoes.FindAsync(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cargo cargo = await db.Cargoes.FindAsync(id);
            db.Cargoes.Remove(cargo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
