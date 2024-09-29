using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelEngin.DAL;
using TravelEngin.DAL.Models;
using TravelEngin.ViewModels;

namespace TravelEngin.Controllers;

public class TravelController : Controller
{
    private readonly ILogger<TravelController> _logger;

    private readonly TravelEnginDataContext _context;

    public TravelController(ILogger<TravelController> logger, TravelEnginDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        //TODO : show agency dashboard 
        return View();
    }


    // GET: TravelPackages/Create
    public IActionResult CreatePackage()
    {
        // Display the form for creating a new travel package
        return View();
    }

    // POST: TravelPackages/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreatePackage([Bind("Name,Description,Price,Duration")] TravelPackage travelPackage)
    {
        if (ModelState.IsValid)
        {
            // Add the travel package to the database
            travelPackage.CreatedDate = DateTime.Now;
            travelPackage.UpdatedDate = DateTime.Now;
            _context.Add(travelPackage);
            _context.SaveChanges();

            // Redirect to the list of travel packages or details view
            return RedirectToAction(nameof(Index));
        }

        // If the model state is invalid, return the view with validation errors
        return View(travelPackage);
    }

    public IActionResult AddItinerary(int travelPackageId)
    {
        // Find the travel package to ensure it exists
        var travelPackage = _context.TravelPackages.Find(travelPackageId);
        if (travelPackage == null)
        {
            return NotFound();
        }

        // Create a new itinerary object and set the TravelPackageId
        var itinerary = new Itinerary
        {
            TravelPackageId = travelPackageId,
            DayNumber = 1 // Default to Day 1, can be changed in the form
        };

        ViewBag.TravelPackageName = travelPackage.Name;
        return View(itinerary);
    }

    // POST: Itineraries/AddItinerary
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddItinerary([Bind("TravelPackageId,DayNumber,Title,Description,Activities,Accommodation,Meals")] Itinerary itinerary)
    {
        if (ModelState.IsValid)
        {
            // Add the itinerary to the database
            itinerary.CreatedDate = DateTime.Now;
            itinerary.UpdatedDate = DateTime.Now;
            _context.Itineraries.Add(itinerary);
            _context.SaveChanges();

            // Redirect to the details of the travel package the itinerary belongs to
            return RedirectToAction("Details", "TravelPackages", new { id = itinerary.TravelPackageId });
        }

        // If the model state is invalid, return the view with validation errors
        return View(itinerary);
    }








    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
