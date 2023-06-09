using LMS.UI.Areas.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LMS.UI.Pages.Shared.Components.Lookups
{
    public class LookupsViewComponent : ViewComponent
    {
        HttpClient client = new HttpClient();
        private IConfiguration _configuration;
        public LookupsViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            client.BaseAddress = new Uri(_configuration["APIURL"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(string id, string name, int lookupId, string labelClass = "", string label = "", string method = "false")
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.LookupId = lookupId;
            ViewBag.LabelClass = labelClass;
            ViewBag.Method = method;
            ViewBag.Label = label;
            ViewBag.Lookups = await GetLookUps();
            return View();
        }
        private async Task<List<DropdownViewModel>> GetLookUps()
        {
            List<DropdownViewModel> list = new List<DropdownViewModel>();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("Lookup/GetAllLookup");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<DropdownViewModel>>(jsonResult);
            }
            return list;
        }
    }
}
