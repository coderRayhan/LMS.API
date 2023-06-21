using AutoMapper;
using LMS.UI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UEMS.Web.Abstractions;

namespace LMS.UI.Controllers
{
    public class BaseController<T> : Controller
    {
        private IMediator _mediatorInstance;
        private ILogger<T> _loggerInstance;
        private IViewRenderService _viewRenderInstance;
        private IMapper _mapperInstance;
        private IToastNotification _toastNotification;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IViewRenderService _viewRenderer => _viewRenderInstance ??= HttpContext.RequestServices.GetService<IViewRenderService>();
        protected IToastNotification _toast => _toastNotification ??= HttpContext.RequestServices.GetService<IToastNotification>();
        protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();

    }
}
