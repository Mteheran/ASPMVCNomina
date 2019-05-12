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
    public class EmpleadoController : Controller
    {
        private Entities db = new Entities();

        // GET: Empleado
        public async Task<ActionResult> Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Cargo);

            var empleadosConTelefono = from e in db.Empleadoes
                                    where e.Telefono != null
                                    select e;

            var empleadoscontelefonoyTipodocumento1 = empleadosConTelefono.Where(x => x.Tipo_De_Documento == 1);

            var queryresult = await empleadosConTelefono.ToListAsync();

            return View(await empleadoes.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleadoes.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cargo = new SelectList(db.Cargoes, "Id_Cargo", "Nombre");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Empleado,Nombre,Apellido,Correo,Telefono,Numero_De_Documento,Tipo_De_Documento,Id_Cargo,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cargo = new SelectList(db.Cargoes, "Id_Cargo", "Nombre", empleado.Id_Cargo);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleadoes.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cargo = new SelectList(db.Cargoes, "Id_Cargo", "Nombre", empleado.Id_Cargo);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Empleado,Nombre,Apellido,Correo,Telefono,Numero_De_Documento,Tipo_De_Documento,Id_Cargo,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cargo = new SelectList(db.Cargoes, "Id_Cargo", "Nombre", empleado.Id_Cargo);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleadoes.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleado empleado = await db.Empleadoes.FindAsync(id);
            db.Empleadoes.Remove(empleado);
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
