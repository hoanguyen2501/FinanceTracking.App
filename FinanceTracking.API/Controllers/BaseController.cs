using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public abstract class BaseController<S> : ControllerBase where S : class
    {
        protected ILogger Logger { get; }
        protected IMapper Mapper => HttpContext.RequestServices.GetRequiredService<IMapper>();
        protected S Service => HttpContext.RequestServices.GetRequiredService<S>();

        protected BaseController(ILogger logger) => Logger = logger;

    }
}
