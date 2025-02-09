using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class MaterialsforEmployeesController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> userManager;

        public MaterialsforEmployeesController(Appdbcontext appdbcontext,UserManager<Appuser> userManager)
        {
            this.appdbcontext = appdbcontext;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            
            var data = new List<MaterialsEmployeesviewmodel>();
            var Realdata= await appdbcontext.EmployeeMaterials.Include(x =>x.Materials).Include(x=>x.Employee).ToListAsync();

            if (Realdata !=null)
            {
                foreach (var item in Realdata)
                {
                    var em = new MaterialsEmployeesviewmodel();
                    em.id=item.id;
                   em.materialsId =  item.materialsId;
                    em.Employeesid = item.Employeesid;
                   em.EmployeesName = item.Employee.name;
                    em.materialName = item.Materials.Name;
                    em.QuantityUsed = item.QuantityUsed;
                    em.Quantities = item.Quantities;
                    em.calcquntityused = em.Quantities - em.QuantityUsed;
                    em.Date = item.Date;
                    data.Add(em);
                }
            }
            return View(data);

        }

        //-------------AddmaterialsEmployee-------
        [HttpGet]
        public IActionResult AddmaterialsEmployee()
        {
            ViewData["NameOfMaterial"] =  appdbcontext.materials.ToList();
            ViewBag.NameOfEmployee =  appdbcontext.Employee.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddmaterialsEmployee(MaterialsEmployeesviewmodel materialsEmployeesviewmodel)
        {
                var data = new Models.EmployeeMaterials();
                
                var material = await appdbcontext.materials.FirstOrDefaultAsync(x=>x.Name== materialsEmployeesviewmodel.materialName);

                var emp =  await appdbcontext.Employee.FirstOrDefaultAsync(x=>x.name == materialsEmployeesviewmodel.EmployeesName);
                if (emp == null)
                {
                    return NotFound();

                }
                data.id=Guid.NewGuid().ToString();
                data.Employeesid = emp.id;
                data.materialsId=material.Id;
                data.Quantities = materialsEmployeesviewmodel.Quantities;
                data.QuantityUsed = 0;
                data.Date=materialsEmployeesviewmodel.Date;
            material.Quantityinstorage = material.Quantity - data.Quantities;
                await appdbcontext.EmployeeMaterials.AddRangeAsync(data);
            appdbcontext.materials.Update(material);
                await appdbcontext.SaveChangesAsync();
                await appdbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        //-------------edit----------------
        [HttpGet]
        public  IActionResult EditmaterialsEmployee(string id )
        {
            var data = appdbcontext.EmployeeMaterials.Include(x=>x.Employee).Include(x=>x.Materials).SingleOrDefault(x=>x.id==id);
            var view = new MaterialsEmployeesviewmodel();
            view.materialName=data.Materials.Name;
            view.EmployeesName=data.Employee.name;
            view.Date=data.Date;
            view.QuantityUsed=data.QuantityUsed;
            view.Quantities=data.Quantities;
            view.Employeesid=data.Employeesid;
            view.materialsId=data.Materials.Id;

            return View(view);
        }
       [HttpPost]
        public async Task<IActionResult> EditmaterialsEmployee(MaterialsEmployeesviewmodel materialsEmployeesviewmodel)
        {
            if (ModelState.IsValid)
            {
                var quant = await appdbcontext.EmployeeMaterials.SingleOrDefaultAsync(x => x.id == materialsEmployeesviewmodel.id);

                    var data = await appdbcontext.EmployeeMaterials.SingleOrDefaultAsync(x => x.id == materialsEmployeesviewmodel.id);
                    data.Quantities = materialsEmployeesviewmodel.Quantities;
                data.QuantityUsed = 0;
                    appdbcontext.EmployeeMaterials.Update(data);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "الموارد المستخدمه اكبر من الموارد المسحوبه");
            }
            return RedirectToAction("EditmaterialsEmployee", ModelState);

        }


        public async Task<IActionResult> Delete(string id)
        {
            var data = await appdbcontext.EmployeeMaterials.FirstOrDefaultAsync(x => x.id == id);
            appdbcontext.Remove(data);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
