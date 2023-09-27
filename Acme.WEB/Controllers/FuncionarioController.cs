using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Acme.WEB;

namespace Acme.WEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private BD_AcmeEntities db = new BD_AcmeEntities();

        // GET: Funcionario
        public ActionResult Index()
        {
            var funcionario = db.Funcionario.Include(f => f.Cargo).Include(f => f.Departamento);
            return View(funcionario.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nome");
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Nome");
            return View();
        }

        // POST: Funcionario/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFuncionario,IdDepartamento,IdCargo,Nome,Cpf,Email,Telefone,Sexo,DtNascimento,DtAdmissao,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Cep,SalarioBruto")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nome", funcionario.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Nome", funcionario.IdDepartamento);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nome", funcionario.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Nome", funcionario.IdDepartamento);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFuncionario,IdDepartamento,IdCargo,Nome,Cpf,Email,Telefone,Sexo,DtNascimento,DtAdmissao,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Cep,SalarioBruto")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nome", funcionario.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Nome", funcionario.IdDepartamento);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            db.Funcionario.Remove(funcionario);
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
    }
}
