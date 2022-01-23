using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using  System.Data.Entity;
using System.Data.Entity.Validation;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);      

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
             
                return View("MovieForm", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                //init due to security issues

                //Mapper.Map(customer,customerInDb);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

    }
}



//// GET: Movies/Random
//public ActionResult Random()
//{
//    var movie = new Movie() {Name = "Shrek!"};
//    var customers = new List<Customer>
//    {
//        new Customer {Name = "Customer 1"},
//        new Customer {Name = "Customer 2"}
//    };
//    var viewModel = new RandomMovieViewModel
//    {
//        Movie = movie,
//        Customers = customers
//    };
//    return View(viewModel);

//}


//public ActionResult Edit(int id)
//{
//    return Content("Edit: id=" + id);
//}

//public ActionResult Index(int? pageIndex, string sortBy)
//{
//    if (!pageIndex.HasValue)
//    {
//        pageIndex = 1;
//    }

//    if (String.IsNullOrWhiteSpace(sortBy))
//    {
//        sortBy = "Name";
//    }
//    return Content(String.Format("Index : pageIndex={0}&sortBy={1}" ,pageIndex, sortBy));
//}

////[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)")]
//public ActionResult ByReleaseDate(int year,int month)
//{

//    return Content("ByReleaseDate "+year + " / " + month);
//}

//return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
//return Content("movie");
//return HttpNotFound();
// return new EmptyResult()