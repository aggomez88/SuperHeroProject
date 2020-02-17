using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class SuperHeroesController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperHeroes
        public ActionResult Index()
        {
            var superHeroes = _context.su.ToList();
            return View(superHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int Id)
        {
            var heroInDB = _context.su.Where(c => c.Id == Id).Single();
            return View(heroInDB);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHeroModel superHero = new SuperHeroModel();
            return View(superHero);
        }
        //POST SUPERHERO CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHeroModel newSuperHero)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _context.su.Add(newSuperHero);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newSuperHero);
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _context.su.Where(c => c.Id == id).Single();
            return View(hero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHeroModel superhero)
        {
            try
            {
                // TODO: Add update logic here
                var heroInDB = _context.su.Where(c => c.Id == superhero.Id).Single();
                heroInDB.Name = superhero.Name;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHeroModel collection)
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
    }
}