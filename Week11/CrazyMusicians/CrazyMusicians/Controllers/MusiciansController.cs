using CrazyMusicians.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {

        private static List<Musician> _musicians = new List<Musician>()
        {
            new Musician{Id=1, Name="Amet Çalgı", Profession="Ünlü Çalgı Çalar", Feature="Her zaman yanlış nota çalar, ama çok eğlenceli"},

            new Musician{Id=2, Name="Zeynep Melodi", Profession="Popüler Melodi Yazarı", Feature="Şarkıları yanlış anlaşılır ama çok popüler"},

            new Musician{Id=3, Name="Cemil Akor",Profession="Çılgın Akortist", Feature="Akorları sık değişir, ama şaşırtıcı derecede yetenekli"},

            new Musician{Id=4, Name="Fatma Nota", Profession="Sürpriz Nota Üreticisi", Feature="Nota üretirken sürekli sürprizler hazırlar"},

            new Musician{Id=5, Name="Hasan Ritim", Profession="Ritim Canavarı", Feature="Her ritmi kendi tarzında yapari hiç uymaz ama komiktir"},

            new Musician{Id=6, Name="Elif Armoni", Profession="Armoni Ustası", Feature="Armonilerini bazen yanlış çalar, ama çok yaratıcıdır"},

            new Musician{Id=7, Name="Ali Perde", Profession="Perde Uygulayıcı", Feature="Her perdeyi farklı şekilde çalar, her zaman sürprizlidir"},

            new Musician{Id=8, Name="Ayşe Renonans", Profession="Rezonans Uzmanı", Feature="Rezonans konusunda uzman, ama bazen çok gürültülü çıkarır"},

            new Musician{Id=9, Name="Murat Ton", Profession="Tonlama Meraklısı", Feature="Tonlamalarındaki farklılıklar baen komik, ama oldukça ilginç"},

            new Musician{Id=10, Name="Selin Akor", Profession="Akor Sihirbazı", Feature="Akorları değiştirdiğinde bazen sihirli bir hava yaratır"}
        };

        //MEVCUT VERİ LİSTELEME

        [HttpGet]

        public IActionResult GetAll()
        {
            var response = _musicians.Select(x => new MusicianListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Profession = x.Profession,
                Feature = x.Feature,
            }).ToList();
            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
             var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return  NotFound();

            var response = new MusicianListResponse()
            {
                Id=musician.Id,
                Name = musician.Name,
                Profession=musician.Profession,
                Feature = musician.Feature,
            };
            return Ok(response);
        }

        // YENİ EKLEME

        [HttpPost]
        public IActionResult AddMusician([FromBody] MusicianAddRequest request)
        {
            var newMusician = new Musician()
            {
                Id= _musicians.Max(x => x.Id+1),
                Name = request.Name,
                Profession=request.Profession,
                Feature=request.Feature,
            };
            _musicians.Add(newMusician);
            return CreatedAtAction(nameof(Get), new { id = newMusician.Id }, newMusician); 
        }

        //TAMAMEN GÜNCELLEME

        [HttpPut("{id}")]
        public IActionResult UpdateMusician(int id, [FromBody] MusicianUpdateRequest request)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();

            musician.Name = request.Name;
            musician.Profession = request.Profession;
            musician.Feature = request.Feature;

            return NoContent();
        }
        // KISMİ GÜNCELLEME

        [HttpPatch("{id}")]
        public IActionResult ChangeFeature(int id, [FromBody] MusicianFeatureUpdateRequest request)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();

            musician.Feature = request.Feature;
            return NoContent();
        }

        //DELETE İŞLEMİ

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();

            _musicians.Remove(musician);
            return NoContent();
        }

        //FROMQUERY İLE SORGU

        [HttpGet("search")]
        public IActionResult SearchMusicians([FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return BadRequest("Arama terimi boş olamaz.");

            var filteredMusicians = _musicians
                .Where(m => m.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || m.Profession.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!filteredMusicians.Any())
                return NotFound("Arama kriterlerine uygun müzisyen bulunamadı.");

            var response = filteredMusicians.Select(m => new MusicianListResponse
            {
                Id = m.Id,
                Name = m.Name,
                Profession = m.Profession,
                Feature = m.Feature
            }).ToList();

            return Ok(response);
        }
    }
}
