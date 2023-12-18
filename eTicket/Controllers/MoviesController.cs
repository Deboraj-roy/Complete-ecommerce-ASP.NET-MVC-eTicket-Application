using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        { 
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        { 
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString)
                || n.Description.Contains(searchString)).ToList();

                if (filteredResult.Count == 0)
                {
                    //Redirect to Coustom 404 page for filtering

                    //return RedirectToAction("FilterNotFound");

                    return View("FilterNotFound");
                    //return View("NotFound");

                }
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }
/*
        public IActionResult FilterNotFound()
        {
            // You can customize this action to display your custom 404 page for filtering
            return View("FilterNotFound");
        }
*/
        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValuesAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Movie didn't added, Try Again!  ";
                var movieDropdownsData = await _service.GetNewMovieDropdownsValuesAsync();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.AddNewMovieAsync(movie);

                TempData["success"] = "Movie Added Successfully  ";
                return RedirectToAction(nameof(Index));
            }
        }
        
        
        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValuesAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Movie didn't Update, Try Again!  ";
                var movieDropdownsData = await _service.GetNewMovieDropdownsValuesAsync();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.UpdateMovieAsync(movie);

                TempData["success"] = "Movie Updated Successfully  ";
                return RedirectToAction(nameof(Index));
            }
        }


        //Get: Movies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var MoviesDetails = await _service.GetMovieByIdAsync(id);
            if (MoviesDetails == null) return View("NotFound");
            return View(MoviesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MoviesDetails = await _service.GetMovieByIdAsync(id);
            if (MoviesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            TempData["warning"] = "Movie Delete Successfully  ";
            return RedirectToAction(nameof(Index));
        }
    }
}
