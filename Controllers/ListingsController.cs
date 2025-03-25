using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using uMarket.Models;
using uMarket.Repository;

namespace uMarket.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingRepository _listingRepository;

        public ListingsController(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        // GET: Listings
        public IActionResult Index()
        {
            return View(_listingRepository.GetAll().ToList());
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListingId,UserId,CategoryId,Title,Description,Price,CreatedAt,IsSold")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                listing.CreatedAt = DateTime.UtcNow;
                await _listingRepository.AddAsync(listing);
                return RedirectToAction(nameof(Index));
            }
            return View(listing);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var listing = await _listingRepository.GetByIdAsync(id.Value);
            if (listing == null) return NotFound();

            return View(listing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListingId,UserId,CategoryId,Title,Description,Price,CreatedAt,IsSold")] Listing listing)
        {
            if (id != listing.ListingId) return NotFound();

            if (ModelState.IsValid)
            {
                await _listingRepository.UpdateAsync(listing);
                return RedirectToAction(nameof(Index));
            }
            return View(listing);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var listing = await _listingRepository.GetByIdAsync(id.Value);
            if (listing == null) return NotFound();

            return View(listing);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _listingRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
