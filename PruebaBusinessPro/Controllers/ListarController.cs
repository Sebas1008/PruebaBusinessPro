using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;

namespace PruebaBusinessPro.Controllers
{
    public class ListarController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                using (PruebaBusinessProContext ctx = new PruebaBusinessProContext())
                {
                    //ViewBag.Prueba = ctx.Articulos.Include("Proveedor").ToList();

                    var Listar = ctx.Listar.FromSqlRaw("spListarArticulos").ToList();
                    ViewBag.Listar = Listar;
                    return View(ViewBag.Listar);
                    
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        }
    }

