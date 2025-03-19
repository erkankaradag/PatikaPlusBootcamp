using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorAllStar.Context;
using SurvivorAllStar.Entity;
using SurvivorAllStar.Models.Categories;
using SurvivorAllStar.Models.Competitors;


namespace SurvivorAllStar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorAllStarDbContext _db;

        public CategoriesController(SurvivorAllStarDbContext Db)
        {
            _db = Db;
        }

        [HttpGet]
        public IActionResult GettAll()
        {
            var categoryList = _db.Categories.Where(x => x.IsDeleted == false).Select(x =>
            new CategoryListResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _db.Categories.Include(c => c.Competitors).FirstOrDefault(x => x.Id == id);

            if (category == null || category.IsDeleted == true)
            {
                return NotFound("Böyle bir Kategori bulunmuyor.");
            }

            var response = new CategoryDetailResponse
            {
                Id = category.Id,
                CreatedDate = category.CreatedDate,
                ModifiedDate = category.ModifiedDate,
                Name = category.Name,
                Competitors = category.Competitors.Where(c => c.IsDeleted == false).Select(c => new CompetitorListResponse
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName,
                    CategoryId = c.CategoryId
                }).ToList()
            };

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Create(CategoryCreateRequest data)
        {
            var newCategory = new CategoryEntity
            {
                Name = data.Name
            };

            _db.Categories.Add(newCategory);
            _db.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryUpdateRequest data)
        {
            var category = _db.Categories.Find(id);

            if (category == null || category.IsDeleted == true)
            {
                return NotFound("Böyle bir Kategori bulunmuyor.");
            }

            category.Name = data.Name;
            category.ModifiedDate = DateTime.Now.ToUniversalTime();

            _db.Categories.Update(category);
            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null || category.IsDeleted == true)
            {
                return NotFound("Böyle bir Kategori bulunmuyor.");
            }

            category.IsDeleted = true;
            category.ModifiedDate = DateTime.Now.ToUniversalTime();

            _db.Categories.Update(category);
            _db.SaveChanges();

            return Ok();
        }
    }
}

