using LMS.Domain.Entities;
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
        HttpClient httpClient = new HttpClient();
        public LookupController(IConfiguration config, IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
            _config = config;
            httpClient.BaseAddress = new Uri(_config.GetValue<string>("APIURL"));
        }
        public async Task<IActionResult> Index()
        {
            List<Lookup> lookup = new();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("lookup");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                lookup = JsonConvert.DeserializeObject<List<Lookup>>(jsonString);
            }
            return View(lookup);
        }

        public async Task<IActionResult> Create()
        {
            var lookup = new Lookup();
            return new JsonResult(new {isValid = true, html = await _viewRenderService.RenderViewToStringAsync("_Create", lookup)});
        }
        
        [HttpPost] 
        public async Task<IActionResult> Create(Lookup lookup)
        {
            lookup.ParentId = 0;
            lookup.CreatedBy = "Rayhan";
            lookup.Created = DateTime.Now;
            lookup.LastModified = DateTime.Now;
            lookup.LastModifiedBy = "rayhan";
            lookup.DevCode = 9;
            var jsonObj = JsonConvert.SerializeObject(lookup);
            var res = await httpClient.PostAsJsonAsync("lookup", lookup);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Lookup? lookup = new();
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"lookup/GetById?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                lookup = JsonConvert.DeserializeObject<Lookup>(jsonString);
            }
            return View(lookup);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Lookup lookup)
        {
            lookup.ParentId = 0;
            lookup.CreatedBy = "Rayhan";
            lookup.Created = DateTime.Now;
            lookup.LastModified = DateTime.Now;
            lookup.LastModifiedBy = "rayhan";
            lookup.DevCode = 9;
            var res = await httpClient.PutAsJsonAsync($"lookup?id={id}", lookup);
            return View();
        }
    }
}
