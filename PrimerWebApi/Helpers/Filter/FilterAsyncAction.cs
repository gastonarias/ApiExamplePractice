using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamplePractice.Helpers.Filter
{
    public class FilterAsyncAction : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
