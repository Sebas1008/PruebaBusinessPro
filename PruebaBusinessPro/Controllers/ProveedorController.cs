using DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PruebaBusinessPro.Controllers
{
    public class ProveedorController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ViewBag.Prueba = ctx.Proveedor.ToList();
                    return View();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        #region "Añadir"

        // GET: Productos/Create   Metodo para invocar a la vista
        public ActionResult Añadir()
        {
            return View();
        }

        // POST: Productos/Create  Metodo para añadir registros 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Añadir(Proveedor Proveedor_param)
        {
            try
            {
                if (!ModelState.IsValid)

                    return View();

                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ctx.Proveedor.Add(Proveedor_param);
                    ctx.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Editar"
        // GET: Productos/Edit/5
        [HttpGet]
        public ActionResult Editar(int IdProveedor)
        {
            Proveedor listar = new Proveedor();

            PruebaBusinessProContext ctx = new PruebaBusinessProContext();

            listar = ctx.Proveedor.ToList()
                .FirstOrDefault(a => a.IdProveedor == IdProveedor);

            if (listar == null)
            {
                return NotFound();
            }
            else
            {
                return View(listar);
            }
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Proveedor Proveedores_param)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ctx.ActualizarProvedores(Proveedores_param);
                    ctx.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Eliminar" 
        // GET: Productos/Delete/5
        public ActionResult Eliminar(int IdProveedor_param)
        {
            Proveedor list = new Proveedor();
            PruebaBusinessProContext ctx = new PruebaBusinessProContext();

            list = ctx.Proveedor.ToList()
                .FirstOrDefault(a => a.IdProveedor == IdProveedor_param);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                ctx.Proveedor.Remove(list);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Productos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int IdProveedores, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #endregion



    }

}
