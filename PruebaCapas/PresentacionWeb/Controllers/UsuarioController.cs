using BE;
using PresentacionWeb.ServiceUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        ServiceUsuario.Service1Client serviceUs = new ServiceUsuario.Service1Client();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(serviceUs.getUsuarioAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario = serviceUs.GetlistId(Convert.ToInt32(id));
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                serviceUs.setInsertUs(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario = serviceUs.GetlistId(Convert.ToInt32(id));
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioModel obj)
        {
            try
            {
                serviceUs.setUpdateUs(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario = serviceUs.GetlistId(Convert.ToInt32(id));
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, UsuarioModel obj)
        {
            try
            {
                obj.IdUsuario = Convert.ToInt32(id);
                serviceUs.setDeleteUs(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
