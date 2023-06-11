using LMS.Domain.Entities;
using LMS.UI.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UEMS.Web.Abstractions;

namespace LMS.UI.Areas.LMS.Controllers
{
    [Area("LMS")]
    public class LookupController : Controller
    {
        private IViewRenderService _viewRenderService;
        private IConfiguration _config;
        private IToastNotification _toast;
        HttpClient httpClient = new HttpClient();
        public LookupController(IConfiguration config, IViewRenderService viewRenderService, IToastNotification toast)
        {
            _viewRenderService = viewRenderService;
            _config = config;
            _toast = toast;
            httpClient.BaseAddress = new Uri(_config.GetValue<string>("APIURL"));
        }
        public async Task<IActionResult> Index()
        {
            Lookup lookup = new();
            lookup.ParentId = 0;
            return View(lookup);
        }

        public async Task<IActionResult> LoadAll()
        {
            List<Lookup> lookup = new();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("lookup");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                lookup = JsonConvert.DeserializeObject<List<Lookup>>(jsonString);
            }
            return PartialView("_LoadAll", lookup);
        }

        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if(id == 0)
            {
                var lookup = new Lookup();
                lookup.ParentId = 0;
                return new JsonResult(new { isValid = true, html = await _viewRenderService.RenderViewToStringAsync("_Create", lookup) });
            }
            else
            {
                Lookup? lookup = new();
                HttpResponseMessage responseMessage = await httpClient.GetAsync($"lookup/GetById?id={id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    lookup = JsonConvert.DeserializeObject<Lookup>(jsonString);
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderService.RenderViewToStringAsync("_Create", lookup) });
            }
        }
        
        [HttpPost] 
        public async Task<IActionResult> CreateOrEditPost(Lookup lookup, int id = 0)
        {
            if(id == 0)
            {
                lookup.Status = "Active";
                lookup.CreatedBy = "Rayhan";
                lookup.Created = DateTime.Now;
                lookup.DevCode = 9;
                var jsonObj = JsonConvert.SerializeObject(lookup);
                var res = await httpClient.PostAsJsonAsync("lookup", lookup);
                if (res.IsSuccessStatusCode)
                {
                    await _toast.ToastSuccess("Saved Successfully");
                }
                return RedirectToAction("Index");
            }
            else
            {
                lookup.LastModified = DateTime.Now;
                lookup.LastModifiedBy = "rayhan";
                lookup.DevCode = 9;
                var res = await httpClient.PutAsJsonAsync($"lookup?id={id}", lookup);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var res = await httpClient.DeleteAsync($"lookup/DeleteAsync?id={id}");
            if(res.IsSuccessStatusCode)
            {
                List<Lookup> lookup = new();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("lookup");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    lookup = JsonConvert.DeserializeObject<List<Lookup>>(jsonString);
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderService.RenderViewToStringAsync("_LoadAll", lookup) });
            }
            return new JsonResult(new { isValid = true });
        }
    }
}
