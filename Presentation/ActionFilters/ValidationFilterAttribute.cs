using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
	public class ValidationFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context) //controllerdaki action metodu calismadan hemen once calisacak olan metot burasi
		{

			var controller = context.RouteData.Values["controller"]; //urldeki controller ismini verir 
			var action = context.RouteData.Values["action"];        //urldeki action ismini verir

			var parameter = context.ActionArguments.SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value; //actionda dto keywordu gecen bir parametre varsa onu alır

			if (parameter is null)  //eger dto yoksa
			{
				context.Result = new BadRequestObjectResult($"object is null in Controller: {controller} Action: {action}");
				return; //400
			}
		}
	}
}
