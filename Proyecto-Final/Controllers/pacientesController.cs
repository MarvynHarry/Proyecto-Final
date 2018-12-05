using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Neg;
using proyecto_final.Models;
using proyecto_final.Neg;
using System.Net;

namespace proyecto_final.Controllers
{
    public class pacientesController : Controller
    {
        PacienteNeg objClienteNeg;
        public pacientesController()
        {
      
        }


        private DatabaseEntities db = new DatabaseEntities();



        // GET: pacientes
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "nombre")
            {
                return View(db.paciente.Where(x => x.nombre.Contains(search) || search == null).ToList());
            }
           if (searchBy == "apellido")
            {
                return View(db.paciente.Where(x => x.apellido.Contains(search) || search == null).ToList());
            }
           if (searchBy == "sangre")
            {
                return View(db.paciente.Where(x => x.tipo_sangre.Contains(search) || search == null).ToList());
            }
 
            else { return View(db.paciente.ToList()); }
        }
        


        // GET: pacientes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellido,fecha_naciemiento,telefono,tipo_sangre")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: pacientes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,fecha_naciemiento,telefono,tipo_sangre")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            paciente paciente = db.paciente.Find(id);
            db.paciente.Remove(paciente);
            db.SaveChanges();
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









        public ActionResult Find(long cedula)
        {
            paciente objProducto = new paciente(cedula);
            objClienteNeg.find(objProducto);
            //objClienteNeg.find2(objCliente);
            return View(objProducto);
        }

        [HttpGet]
        public ActionResult BuscarPacientes()
        {
            return View(db.paciente.ToList());

        }
        [HttpPost]
        public ActionResult BuscarPacientes(long txtpaciente, string txtnombre, string ListaCategorias)
        {

            if (txtnombre == "")
            {
                txtnombre = "-1";
            }
            if (txtpaciente == 0)
            {
                txtpaciente = -1;
            }
            if (ListaCategorias == "")
            {
                ListaCategorias = "-1";
            }

      

            paciente objProducto = new paciente();
            objProducto.nombre = txtnombre;
            objProducto.cedula = txtpaciente;
            objProducto.tipo_sangre = ListaCategorias;

            List<paciente> paciente = objClienteNeg.findAllClientes(objProducto);
            
            return View(paciente);
        }

        public void mensajeErrorServidor(paciente objProducto)
        {
            switch (objProducto.Estado)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }

    }
}