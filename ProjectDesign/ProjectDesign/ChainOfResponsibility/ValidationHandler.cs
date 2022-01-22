using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class ValidationHandler : BaseHandler
    {
        public ValidationHandler(IHandler next) : base(next)
        {

        }

        public override void Handle(RequestContext context)
        {
            Console.WriteLine("ValidationHandler");

            if (context.Request.EntityId > 100)
            {
                _next.Handle(context);
                return;
            }

            context.Response.IsSuccessful = false;
            context.Response.Message = "Validation error: EntityId must be grater than 100.";
        }

    }
}
