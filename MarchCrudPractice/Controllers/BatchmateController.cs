using MarchCrudPractice.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarchCrudPractice.Models;

namespace MarchCrudPractice.Controllers
{
    public class BatchmateController : Controller
    {
        private readonly IBatchmateRepository Repository;
        public BatchmateController(IBatchmateRepository repository)
        {
            Repository = repository;
        
       }
        //-----------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var path = Path.Combine(folderPath, fileName);


            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(stream);
            }
            return Json(new {filePath = "/Upload" + fileName});
        }

        //-----------------------------------------------------------------------------------------

        public IActionResult GetAll()
        {
            var batch = Repository.GetAllBatchmates();
            return View(batch);
        }

      

        public IActionResult GetById(int id)
        {
            var batchmate = Repository.GetBatchmateById(id);
            return View(batchmate);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Batchmates batchmate)
        {
            if (ModelState.IsValid)
            {
                Repository.CreateBatchmates(batchmate);
                return RedirectToAction(nameof(GetAll));
            }
            return View(batchmate);
        }

        public IActionResult Update(int id)
        {
            var btc = Repository.GetBatchmateById(id);
            if (btc == null) return NotFound();
            return View(btc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Batchmates batchmate)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateBatchmates(batchmate);
                return RedirectToAction(nameof(GetAll));
            }
            return View(batchmate);
        }

        public IActionResult Delete(int id)
        {
            var batch = Repository.GetBatchmateById(id);
            if (batch == null) return NotFound();
            return View(batch);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Repository.DeleteBatchmates(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
