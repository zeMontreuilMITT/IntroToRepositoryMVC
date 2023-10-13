using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models;
using IntroToRepositoryMVC.Models.BusinessLogicLayer;
using IntroToRepositoryMVC.Models.ViewModels;

namespace IntroToRepositoryMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieBusinessLogic _movieBusinessLogic;
        public MoviesController(IRepository<Movie> movieRepo, IRepository<Actor> actorRepo, IRepository<Role> roleRepo)
        {
            _movieBusinessLogic = new MovieBusinessLogic(movieRepo, actorRepo, roleRepo);
        }

        public ActionResult Details(int id)
        {
            try
            {
                Movie movie = _movieBusinessLogic.GetMovie(id);
                return View(movie);
            } catch (InvalidOperationException ex) {
                return NotFound(ex.Message);
            }
        }

        // GET
        public ActionResult CreateRole()
        {
            // what would we want to do to unit test this method?
            CreateRoleVM vm = _movieBusinessLogic.InitializeCreateRoleVM();

            return View(vm);
        }

        // POST
        [HttpPost]
        public ActionResult CreateRole(CreateRoleVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Actor actor = _movieBusinessLogic.GetActor(vm.ActorId);
                    Movie movie = _movieBusinessLogic.GetMovie(vm.MovieId);

                    _movieBusinessLogic.AddToRole(movie, actor, vm.RoleName);

                    return RedirectToAction(nameof(Details), new { id = movie.Id });
                }
                catch (Exception ex)
                {
                    return Problem(detail: ex.Message);
                }
            }

            return Problem("Invalid Role values");
        }
    }
}
