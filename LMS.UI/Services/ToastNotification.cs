using LMS.UI.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace LMS.UI.Services
{
    public class ToastNotification : IToastNotification
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionary;

        public ToastNotification(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionary)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionary = tempDataDictionary;
        }
        public async Task ToastError(string message)
        {
            await Task.Delay(0);
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionary.GetTempData(httpContext);
            tempData["Message"] = JsonConvert.SerializeObject(new {Status = "Error", Message = message});
        }

        public async Task ToastInfo(string message)
        {
            await Task.Delay(0);
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionary.GetTempData(httpContext);
            tempData["Message"] = JsonConvert.SerializeObject(new {Status = "Info", Message = message});
        }

        public async Task ToastSuccess(string message)
        {
            await Task.Delay(0);
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionary.GetTempData(httpContext);
            tempData["Message"] = JsonConvert.SerializeObject(new { Status = "Success", Message = message});
        }

        public async Task ToastWarning(string message)
        {
            await Task.Delay(0);
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionary.GetTempData(httpContext);
            tempData["Message"] = JsonConvert.SerializeObject(new {Status = "Warning", Message = message});
        }
    }
}
