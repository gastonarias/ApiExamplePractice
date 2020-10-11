using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamplePractice.Helpers.Filter
{
    public class CustomFilterException : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
