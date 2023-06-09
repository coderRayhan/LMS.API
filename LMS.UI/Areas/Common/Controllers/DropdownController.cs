using LMS.UI.Areas.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LMS.UI.Areas.Common.Controllers
{
    public class DropdownController : Controller
    {
        HttpClient client = new HttpClient();
        private IConfiguration _configuration;
        public DropdownController(IConfiguration configuration)
        {
            _configuration = configuration;
            client.BaseAddress = new Uri(_configuration["APIURL"]);
        }
        public async Task<List<DropdownViewModel>> GetAllLookups()
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
