using DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PruebaBusinessPro.Controllers
{
    public class ArticulosController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ViewBag.Prueba = ctx.Articulos.Include("Proveedor").ToList();
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
        //Metodo Añadir para invocar la vista
        
        public ActionResult Añadir()
        {
           
            using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
            {
                ViewBag.CmbProveedor = ctx.Proveedor.ToList();
            }
            return View();
        }

        // POST: Productos/Create  Metodo para añadir registros 
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Metodo para guardar los datos en la vista de Articulos 
        public ActionResult Añadir(Articulos Articulo_param)
        {
            try
            {
                if (!ModelState.IsValid)

                    return View();

                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ctx.Articulos.Add(Articulo_param);
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
        public ActionResult Editar(int IdArticulo_param)
        {
            Articulos listar = new Articulos();

            PruebaBusinessProContext ctx = new PruebaBusinessProContext();

            ViewBag.Prueba = ctx.Proveedor.ToList();
      


            listar = ctx.Articulos.ToList()
                .FirstOrDefault(a => a.IdArticulo == IdArticulo_param);

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
        public ActionResult Editar(Articulos Articulo_param)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    ctx.ActualizarArticulos(Articulo_param);
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
        public ActionResult Eliminar(int IdArticulo_param)
        {
            Articulos list = new Articulos();
            PruebaBusinessProContext ctx = new PruebaBusinessProContext();

            list = ctx.Articulos.ToList()
                .FirstOrDefault(a => a.IdArticulo == IdArticulo_param);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                ctx.Articulos.Remove(list);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Productos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int IdArticulos, IFormCollection collection)
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
