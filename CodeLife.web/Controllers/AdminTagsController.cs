using CodeLife.web.Data;
using CodeLife.web.Models.Domain;
using CodeLife.web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeLife.web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly CodeLifeDbContext _context;
        public AdminTagsController(CodeLifeDbContext codeLifeDbContext)
        {
                _context = codeLifeDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //mapping AddTagRequest to the Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await _context.Tags.ToListAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);

            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);

            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var existingTag= await _context.Tags.FindAsync(tag.Id);
            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                await _context.SaveChangesAsync();
                //return RedirectToAction("Edit", new { id = editTagRequest.Id });
               return RedirectToAction("List");
            }
            return View("Edit", new {id=editTagRequest.Id});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var tag = await _context.Tags.FindAsync(editTagRequest.Id);
            if (tag != null)
            {
                 _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id=editTagRequest.Id});
        }

    }
}
