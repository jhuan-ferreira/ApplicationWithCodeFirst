using ApplicationWithCodeFirst.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationWithCodeFirst.Controllers
{
    [AutorizacaoDeAcesso]
    public class BaseController : Controller
    {
        // GET: Base
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
            }

    }
}