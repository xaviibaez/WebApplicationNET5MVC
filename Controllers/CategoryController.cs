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
    }
}
