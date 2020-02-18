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
            List<SuperHeroModel> superHeroes = _context.su.ToList();
            return View(superHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details()
        {
            //var superHeroes = _context.su.Where(s => s.Id == Id).FirstOrDefault();
            //return View(superHeroes);

            return RedirectToAction("Index");

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
                heroInDB.AlterEgo = superhero.AlterEgo;
                heroInDB.PrimaryAbility = superhero.PrimaryAbility;
                heroInDB.SecondaryAbility = superhero.SecondaryAbility;
                heroInDB.CatchPhrase = superhero.CatchPhrase;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int Id)
        {
            SuperHeroModel superHero = _context.su.Find(Id);
            return View(superHero);
            
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHeroModel superHero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.su.Remove(superHero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
        }
    }
}