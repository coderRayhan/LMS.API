using LMS.Domain.Entities;
using LMS.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LMS.UI.Areas.LMS.Controllers
{
    [Area("LMS")]
    public class LookupDetailController : BaseController<LookupDetailController>
    {
        HttpClient client = new HttpClient();
        private readonly IConfiguration _config;
        public LookupDetailController(IConfiguration config)
        {
            _config = config;
            client.BaseAddress = new Uri(_config.GetValue<string>("APIURL"));
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadAll()
        {
            List<LookupDetail> list = new();
            list = await client.GetFromJsonAsync<List<LookupDetail>>("LookupDetail");
            return PartialView("_LoadAll", list);
        }
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if(id == 0)
            {
                LookupDetail vModel = new();
                return new JsonResult(new {isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vModel)});
            }
            else
            {
                var vModel = await client.GetFromJsonAsync<LookupDetail>($"LookupDetail/GetById?id={id}");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vModel) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEditPost(LookupDetail lookupDetail, int id)
        {
            if(id == 0)
            {
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync<LookupDetail>("LookupDetail/Create", lookupDetail);
                if (responseMessage.IsSuccessStatusCode)
                {
                    await _toast.ToastSuccess("Created");
                    return RedirectToAction("Index");
                }
                return new JsonResult(new { isValid = false });
            }
            else
            {
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync<LookupDetail>("LookupDetail/Update", lookupDetail);
                if (responseMessage.IsSuccessStatusCode)
                {
                    await _toast.ToastSuccess("Update succesfully");
                    return RedirectToAction("Index");
                }
                return new JsonResult(new { isValid = false });
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"LookupDetail/Delete?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                await _toast.ToastSuccess("Delete successful");
                List<LookupDetail> list = await client.GetFromJsonAsync<List<LookupDetail>>("LookupDetail");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_LoadAll", list) });
            }
            await _toast.ToastError(responseMessage.StatusCode.ToString());
            return RedirectToAction("Index");
        }
    }
}
