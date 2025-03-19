using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorAllStar.Context;
using SurvivorAllStar.Entity;
using SurvivorAllStar.Models.Competitors;

namespace SurvivorAllStar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorAllStarDbContext _db;

        public CompetitorsController(SurvivorAllStarDbContext Db)
        {
            _db = Db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var competitorsList = _db.Competitors.Where(x => x.IsDeleted == false).Select(x => new CompetitorListResponse
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
                CategoryId = x.CategoryId
            }).ToList();

            return Ok(competitorsList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var competitor = _db.Competitors.Find(id);

            if (competitor == null || competitor.IsDeleted == true)
            {
                return NotFound("Böyle bir yarışmacı bulunmuyor.");
            }

            var response = new CompetitorDetailResponse
            {
                Id = competitor.Id,
                CreatedDate = competitor.CreatedDate,
                ModifiedDate = competitor.ModifiedDate,
                CategoyId = competitor.CategoryId,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName
            };

            return Ok(response);
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult GetCategory(int categoryId)
        {
            var competitorList = _db.Competitors.Where(x => x.IsDeleted == false && x.CategoryId == categoryId).Select(x => new CompetitorListResponse
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
                CategoryId = x.CategoryId
            }).ToList();

            return Ok(competitorList);
        }

        [HttpPost]
        public IActionResult Create(CompetitorAddRequest data)
        {
            var newCompetitor = new CompetitorEntity
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                CategoryId = data.CategoryId
            };


            _db.Competitors.Add(newCompetitor);
            _db.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CompetitorsUpdateRequest data)
        {
            var competitor = _db.Competitors.Find(id);

            if (competitor == null || competitor.IsDeleted == true)
            {
                return NotFound("Böyle bir yarışmacı bulunmuyor.");
            }

            competitor.FirstName = data.FirstName;
            competitor.LastName = data.LastName;
            competitor.CategoryId = data.CategoryId;
            competitor.ModifiedDate = DateTime.Now.ToUniversalTime();


            _db.Competitors.Update(competitor);
            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _db.Competitors.Find(id);

            if (competitor == null || competitor.IsDeleted == true)
            {
                return NotFound("Böyle bir yarışmacı bulunmuyor.");
            }

            competitor.IsDeleted = true;
            competitor.ModifiedDate = DateTime.Now.ToUniversalTime();

            _db.Competitors.Update(competitor);
            _db.SaveChanges();

            return Ok();
        }
    }
}
