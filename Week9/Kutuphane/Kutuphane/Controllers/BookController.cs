using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Kutuphane.Controllers
{
    public class BookController : Controller
    {
        public static List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "Kitap 1", AuthorId = 1, Genre = "Roman", PublishDate = new DateTime(2020, 5, 1), ISBN = "123-456-789", CopiesAvailable = 5 },
            new Book { Id = 2, Title = "Kitap 2", AuthorId = 2, Genre = "Bilim Kurgu", PublishDate = new DateTime(2018, 3, 15), ISBN = "987-654-321", CopiesAvailable = 3 },
            new Book { Id = 3, Title = "Kitap 3", AuthorId = 3, Genre = "Tarih", PublishDate = new DateTime(2021, 7, 10), ISBN = "111-222-333", CopiesAvailable = 7 },
            new Book { Id = 4, Title = "Kitap 4", AuthorId = 1, Genre = "Macera", PublishDate = new DateTime(2019, 9, 23), ISBN = "444-555-666", CopiesAvailable = 2 },
            new Book { Id = 5, Title = "Kitap 5", AuthorId = 4, Genre = "Kişisel Gelişim", PublishDate = new DateTime(2022, 1, 5), ISBN = "777-888-999", CopiesAvailable = 10 }
        };

        //-----------------------------------------------------------------------------------------------

        // Kitapların listesini gösterir
        public IActionResult List()
        {

            return View(books);
        }
        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        // Belirli bir kitabın detaylarını gösterir
        public IActionResult Details(int id)
        {
            // Kitap bilgilerini al
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Yazar bilgilerini almak (Eğer kitapta yazar bilgisi varsa)
            var author = AuthorController.authors.FirstOrDefault(a => a.Id == book.AuthorId);

            if (author != null)
            {
                book.AuthorName = author.FullName;  // Yazar adını kitap modeline ekle
            }

            return View(book);
        }


        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        // Yeni bir kitap eklemek için formunu göster

        public IActionResult Create()
        {   
            return View();
        }
        // Yeni kitap ekleme işlemi
        [HttpPost]
        public IActionResult Create(BookAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Genre = model.Genre,
                    PublishDate = model.PublishDate,
                    ISBN = model.ISBN,
                    CopiesAvailable = model.CopiesAvailable
                };

                newBook.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
                books.Add(newBook);

                return RedirectToAction("List");
            }
            return View(model);
        }

        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        // Var olan bir kitabı düzenlemek için form sağlar

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Kitap düzenleme işlemini gerçekleştir
        [HttpPost]
        public IActionResult Edit(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book == null)
            {
                return NotFound();
            }

            // Kitap bilgilerini güncelle
            book.Title = updatedBook.Title;
            book.AuthorId = updatedBook.AuthorId;
            book.Genre = updatedBook.Genre;
            book.PublishDate = updatedBook.PublishDate;
            book.ISBN = updatedBook.ISBN;
            book.CopiesAvailable = updatedBook.CopiesAvailable;

            return RedirectToAction("List"); // Güncellendikten sonra listeye geri dön
        }


        //-----------------------------------------------------------------------------------------------



        //-----------------------------------------------------------------------------------------------


        // Silme işlemi için sadece bu metod gerekecek
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(); // Kitap bulunamazsa hata döner
            }

            books.Remove(book); // Kitap listeden silinir
            return RedirectToAction("List"); // Silme işlemi sonrası kitaplar listelenir
        }



        //-----------------------------------------------------------------------------------------------

    }
}
