﻿using Entities.LogModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
	//artik bu attributeyi controllerların basinda tanimlayarak her bir action metodu cagirildiginda log alacak.
	public class LogFilterAttribute : ActionFilterAttribute
	{
		private readonly ILoggerService _logger;
		public LogFilterAttribute(ILoggerService logger)
		{
			_logger = logger;
		}
		public override void OnActionExecuting(ActionExecutingContext context) //actiondan (metot) once calisacak
		{
			var log = Log("OnActionExecuting", context.RouteData);
			_logger.LogInfo(log);
		}
		private string Log(string modelName, RouteData routeData)
		{
			var logDetails = new LogDetails
			{
				ModelName = modelName,
				Controller = routeData.Values["controller"],
				Action = routeData.Values["action"],
			};
			if (routeData.Values.Count >= 3) //urldeki anahtar deger sayim 3 ya da daha fazla ise Id degeri vardir? o zaman deger atayalim orn localhost:4554/controller/action/3
				logDetails.Id = routeData.Values["Id"];

			return logDetails.ToString(); //JsonSerializer.Serialize(this);
		}
	}
}
