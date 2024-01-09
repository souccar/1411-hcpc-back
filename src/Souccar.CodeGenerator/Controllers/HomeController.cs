using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Souccar.CodeGenerator.Models;
using Souccar.hr.Personnel.Employees;
using System.Diagnostics;

namespace Souccar.CodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Back()
        {
            ViewBag.Types = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Services" },
                new SelectListItem { Value = "1", Text = "Localization" },
                new SelectListItem { Value = "2", Text = "Permissions"  },
                new SelectListItem { Value = "3", Text = "DbSet"  },
            };
            return View();
        }

        [HttpPost]
        public IActionResult Back(BackendModel model)
        {
            if (ModelState.IsValid)
            {
                var assembly = typeof(SouccarCoreModule).Assembly;
                switch (model.Type)
                {
                    case GenerateType.Services:
                        {
                            //ModulesBuilder.Generate(assembly, model.Module);
                            break;
                        }
                    case GenerateType.Localization:
                        {
                            //LocalizationBuilder.Generate(assembly, model.Module);
                            break;
                        }
                    case GenerateType.Permissions:
                        {
                            //PermissionsBuilder.Generate(assembly, model.Module);
                            break;
                        }
                    case GenerateType.DbSet:
                        {
                            //PermissionsBuilder.Generate(assembly, model.Module);
                            break;
                        }
                }

                ViewBag.SuccessMessage = "Successfully Generated";
                ModelState.Clear();
            }


            return View("Index");
        }

        public IActionResult Front()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Front(FrontendModel model)
        {
            return View();
        }

        public IActionResult GetModuleEntities(string moduleName)
        {
            var coreAssembly = typeof(SouccarCoreModule).Assembly;
            var entitiesTypes = ModulesBuilder.GetModuleEntities(coreAssembly, moduleName);
            if (!entitiesTypes.Any())
            {
                return Json(new { Success = false });
            }
            var data = entitiesTypes.Select(t => new { Name = t.Name, FullName = t.FullName });
            return Json(new { Entities = data, Success = true }); ;
        }

        public IActionResult Fields(string entity)
        {
            ViewBag.Entity = entity;
            return PartialView();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
