using eTicket.Data;
using eTicket.Data.Services.IServices;
using eTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        private readonly ILogger<ActorsController> _logger;

        public ActorsController(IActorsService service, ILogger<ActorsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            _logger.LogInformation("I am currently within the index action of the Actors Controller.");
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Actor not Added, try again!";
                return View(actor);
            }
            await _service.AddAsync(actor);
            _logger.LogInformation("Actor Added Successfully.");
            TempData["success"] = "Actor Added Successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            _logger.LogInformation("Actor Details");

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Actor not updated, Try again! ";
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            _logger.LogInformation("Actor Update Successfully.");

            TempData["success"] = "Actor Update Successfully ";
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            _logger.LogInformation("Actor Delete Successfully.");

            TempData["warning"] = "Actor Delete Successfully  ";
            return RedirectToAction(nameof(Index));
        }
    }
}
