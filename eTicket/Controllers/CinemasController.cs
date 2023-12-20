using eTicket.Data;
using eTicket.Data.Services.IServices;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;
        private readonly ILogger<CinemasController> _logger;

        public CinemasController(ICinemaService service, ILogger<CinemasController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("I am currently within the index action of the Cinemas Controller.");
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(cinema);

                TempData["success"] = "Cinema Created Successfully ";
                return RedirectToAction(nameof(Index));
            }

            TempData["warning"] = "Cinema Not Created, Try again ";
            return View(cinema);
        }

        //Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Cinema not updated, Try again! ";
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            TempData["success"] = "Cinema Updated Successfully  ";
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            TempData["warning"] = "Cinema Delete Successfully  ";
            return RedirectToAction(nameof(Index));
        }
    }
}
