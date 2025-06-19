using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var listCate = _unitOfWork.Category.GetAll().ToList();
            return Ok(listCate);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? cateDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (cateDb == null)
            {
                return NotFound();
            }

            return Ok(cateDb);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (category.Id == 0)
                return BadRequest("Id không được bằng 0 hoặc null.");

            // Kiểm tra Name
            if (string.IsNullOrWhiteSpace(category.Name))
                return BadRequest("Tên không được để trống.");

            // Kiểm tra trùng tên
            var isDuplicate = await _context.Categories
                .AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());

            if (isDuplicate)
                return BadRequest("Tên Category đã tồn tại.");

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id || id == 0)
                return BadRequest("Id không hợp lệ.");

            if (string.IsNullOrWhiteSpace(category.Name))
                return BadRequest("Tên không được để trống.");

            // Kiểm tra trùng tên với Category khác
            var isDuplicate = await _context.Categories
                .AnyAsync(c => c.Id != id && c.Name.ToLower() == category.Name.ToLower());

            if (isDuplicate)
                return BadRequest("Tên Category đã tồn tại.");

            var existing = await _context.Categories.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}