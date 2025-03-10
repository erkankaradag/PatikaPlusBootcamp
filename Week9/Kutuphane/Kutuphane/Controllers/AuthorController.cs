using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class AuthorController : Controller
    {

        public static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "Ahmet", LastName = "Yılmaz", DateOfBirth = new DateTime(1980, 5, 12) },
            new Author { Id = 2, FirstName = "Mehmet", LastName = "Demir", DateOfBirth = new DateTime(1975, 3, 25) },
            new Author { Id = 3, FirstName = "Ali", LastName = "Can", DateOfBirth = new DateTime(1970, 6, 12) },
            new Author { Id = 4, FirstName = "Ömer", LastName = "Kara", DateOfBirth = new DateTime(1982, 1, 28) }
        };

        // Kitapların listesini gösterir
        public IActionResult List()
        {
            return View(authors);
        }

        // Belirli bir yazarın detaylarını gösterir
        public IActionResult Details(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Yeni bir yazar eklemek için form sağlar
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = authors.Max(a => a.Id) + 1;
                authors.Add(author);
                return RedirectToAction("List");
            }
            return View(author);
        }

        // Var olan bir yazarı düzenlemek için form sağlar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                var existingAuthor = authors.FirstOrDefault(a => a.Id == author.Id);
                if (existingAuthor != null)
                {
                    existingAuthor.FirstName = author.FirstName;
                    existingAuthor.LastName = author.LastName;
                    existingAuthor.DateOfBirth = author.DateOfBirth;
                }
                return RedirectToAction("List");
            }
            return View(author);
        }
        // Yazarı silmek için bir onay sayfası sağlar
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                authors.Remove(author);
            }
            return RedirectToAction("List");
        }




    }
}
