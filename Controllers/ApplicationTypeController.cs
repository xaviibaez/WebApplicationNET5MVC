using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNET.Data;
using WebApplicationNET.Models;

namespace WebApplicationNET.Controllers
{
    public class ApplicationTypeController : Controller
    {
        //Get all category from database
        //Incializamos la bbdd en nuestro controller
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Listar de la bbdd
        public IActionResult Index()
        {
            //Lista de categorias mapeadas
            IEnumerable<ApplicationType> objList = _db.ApplicationType;

            //Lo enviamos a la view por parametro
            return View(objList);
        }

        //GET - CREATE Crear de categoria
        public IActionResult Create()
        {
            //No pasamos info porque vamos a crearla
            return View();
        }

        //POST - CREATE Crear de categoria
        [HttpPost]
        //Token de seguridad
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            //Objeto que haremos insert en la bbdd
            _db.ApplicationType.Add(obj);

            //Commit
            _db.SaveChanges();

            //Devolvemos un redirect a la acción Index
            return RedirectToAction("Index");
        }
    }
}
