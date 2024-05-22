using learn_basic_csharp_web.Models;
using learn_basic_csharp_web.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace learn_basic_csharp_web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ModelContext _context;

        public UserController(ILogger<UserController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Models.UserVM.Index();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var response = new ResponseBase();
            try
            {
                var model = new Models.UserVM.Add();
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
        public async Task<IActionResult> Save(Models.UserVM.Add input)
        {
            var response = new ResponseBase();
            try
            {
                var save = await Models.UserVM.Save(input);
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
                var model = new Models.UserVM.Edit(Convert.ToInt32(id));
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
        public async Task<IActionResult> Update(Models.UserVM.Edit input)
        {
            var response = new ResponseBase();
            try
            {
                var update = await Models.UserVM.Update(input);
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
        public async Task<IActionResult> Delete(Models.UserVM.Delete input)
        {
            var response = new ResponseBase();
            try
            {
                var delete = await Models.UserVM.Destroy(input);
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
