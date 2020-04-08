using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ncb.WebService.Data;
using ncb.WebService.Models;

namespace ncb.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameController> _logger;
        private readonly GameContext _context;

        public GameController(
            ILogger<GameController> logger,
           GameContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll() => this._context.Categories.ToList();

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var rng = new Random();
            return Enumerable
                .Range(1, 5)
                .Select(index => new Category
                {

                    Name = "Scarecrow" + index,
                    Id = 8 + index,
                    Price = 13.99M + index
                })
                .ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(long id)
        {
            var product = await this._context.Categories.FindAsync(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            this._context.Categories.Add(category);
            await this._context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Category category)
        {
            if (id != category.Id)
            {
                return this.BadRequest();
            }

            this._context.Entry(category).State = EntityState.Modified;
            await this._context.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = await this._context.Categories.FindAsync(id);

            if (category == null)
            {
                return this.NotFound();
            }

            this._context.Categories.Remove(category);
            await this._context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
