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

namespace IntroToRepositoryMVC.Controllers
{
    public class MoviesController : Controller
    {
        MovieBusinessLogic mbl;
        public MoviesController(IRepository<Movie> movieRepo)
        {
            mbl = new MovieBusinessLogic(movieRepo);
        }

        public ActionResult Details(int id)
        {
            try
            {
                Movie movie = mbl.GetMovie(id);
                return View(movie);
            } catch (InvalidOperationException ex) {
                return NotFound();
            }
        }
    }
}
