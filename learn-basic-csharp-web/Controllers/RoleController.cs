using learn_basic_csharp_web.Models;
using learn_basic_csharp_web.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_basic_csharp_web.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly ModelContext _context;

        public RoleController(ILogger<RoleController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Models.RoleVM.Index();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var response = new ResponseBase();
            try
            {
                var model = new Models.RoleVM.Add();
                return PartialView("_Add", model);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return Json(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(Models.RoleVM.Add input)
        {
            var response = new ResponseBase();
            try
            {
                var save = await Models.RoleVM.Save(input);
                response.Status = true;
                response.Message = "Data berhasil dibuat.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var response = new ResponseBase();
            try
            {
                var model = new Models.RoleVM.Edit(Convert.ToInt32(id));
                return PartialView("_Edit", model);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return Json(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.RoleVM.Edit input)
        {
            var response = new ResponseBase();
            try
            {
                var update = await Models.RoleVM.Update(input);
                response.Status = true;
                response.Message = "Data berhasil diubah.";

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Models.RoleVM.Delete input)
        {
            var response = new ResponseBase();
            try
            {
                var delete = await Models.RoleVM.Destroy(input);
                response.Status = true;
                response.Message = "Data berhasil dihapus.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }
    }
}
