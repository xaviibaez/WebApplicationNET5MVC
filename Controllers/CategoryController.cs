using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNET.Data;
using WebApplicationNET.Models;

namespace WebApplicationNET.Controllers
{
    public class CategoryController : Controller
    {
        //Get all category from database
        //Incializamos la bbdd en nuestro controller
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Listar de la bbdd
        public IActionResult Index()
        {
            //Lista de categorias mapeadas
            IEnumerable<Category> objList = _db.Category;

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
        public IActionResult Create(Category obj)
        {
            //Recuperamos las validaciones puestas en el Model con este if
            if (ModelState.IsValid)
            {
                //Objeto que haremos insert en la bbdd
                _db.Category.Add(obj);

                //Commit
                _db.SaveChanges();

                //Devolvemos un redirect a la acción Index
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT Editar categoria
        public IActionResult Edit(int? id)
        {
            //Si es null o 0 no existira por tanto no podemos buscarlo.
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //Lo buscamos en la bbdd para editarlo
            var obj = _db.Category.Find(id);
            //Si no lo encuentra devolvemos notFound como previamente.
            if(obj == null)
            {
                return NotFound();
            }

            //Si lo recuperamos lo enviamos por parametro a la view
            return View(obj);
        }

        //POST - EDIT Editar de categoria
        [HttpPost]
        //Token de seguridad
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            //Recuperamos las validaciones puestas en el Model con este if
            if (ModelState.IsValid)
            {
                //Objeto que haremos insert en la bbdd
                _db.Category.Update(obj);

                //Commit
                _db.SaveChanges();

                //Devolvemos un redirect a la acción Index
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
