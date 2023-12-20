using eTicket.Data;
using eTicket.Data.Services.IServices;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        private readonly ILogger<ProducersController> _logger;

        public ProducersController(IProducersService service, ILogger<ProducersController> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            _logger.LogInformation("I am currently within the Index action of the Producers Controller.");
            return View(allProducers);
        }
        //Get: Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Get: Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Producer not Added, Try again! ";
                return View(producer);
            }

            await _service.AddAsync(producer);
            TempData["success"] = "Producer Added Successfully  ";
            return RedirectToAction(nameof(Index));
        }


        //Get: Producer/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL, FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            { 
                TempData["warning"] = "Producer not updated, Try again! ";
                return View(producer);
            }

            if(id == producer.Id)
            {
                await _service.UpdateAsync(id,producer);

                TempData["success"] = "Producer Updated Successfully  ";
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Get: Producer/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            TempData["warning"] = "Producer Delete Successfully  ";
            return RedirectToAction(nameof(Index));
        }

    }
}
