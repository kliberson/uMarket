using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using uMarket.Data;
using uMarket.Models;
using uMarket.Repository;


namespace uMarket.Controllers
{
    public class UsersController : Controller
    {
        private readonly MarketContext _context;

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository, MarketContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View(_userRepository.GetAll().ToList());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Email,Password,PhoneNumber,Address")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.InsertAsync(user);
                await _userRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        //Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(Convert.ToInt32(id));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,Password,PhoneNumber,Address")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }


        //Delete
        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(Convert.ToInt32(id));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.GetByIdAsync(Convert.ToInt32(id));
            if (user != null)
            {
                await _userRepository.DeleteAsync(id);
                await _userRepository.SaveAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
