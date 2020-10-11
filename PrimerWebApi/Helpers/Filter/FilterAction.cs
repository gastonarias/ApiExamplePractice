using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamplePractice.Helpers.Filter
{
    public class FilterAction : IActionFilter
    {
        private readonly ILogger<FilterAction> logger;

        public FilterAction(ILogger<FilterAction> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.logger.LogInformation("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.logger.LogInformation("OnActionExecuting");
        }
    }
}
