using Console_Care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class jsonController : Controller
    {
        private readonly Appdbcontext appdbcontext;

        public jsonController(Appdbcontext appdbcontext )
        {
            this.appdbcontext = appdbcontext;
        }
        public IActionResult GetMaterials()
        {
            var materials = appdbcontext.materials
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                  
                }).ToList();

            return Json(materials);
        }
        public async Task<JsonResult> GetPiecePricehome(string name)
        {
            {
                var item = await appdbcontext.materials.FirstOrDefaultAsync(p => p.Name == name);
                if (item != null)
                {
                    return Json(new { price = item.priceForHome });
                }
            }
            return Json(new { price = 0 });
        }

        public async Task<JsonResult> GetPiecePriceps(string name)
        {
            {
                var item = await appdbcontext.materials.FirstOrDefaultAsync(p => p.Name == name);
                if (item != null)
                {
                    return Json(new { price = item.priceForPs });
                }
            }
            return Json(new { price = 0 });
        }

    }
}
