using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class AuthorizationHandler : BaseHandler
    {
        private Dictionary<int, int> entityOwners = new Dictionary<int, int>()
        {
            {100, 13},
            {101, 14}
        };
        public AuthorizationHandler(IHandler next) : base(next)
        {

        }

        public override void Handle(RequestContext context)
        {
            Console.WriteLine("AuthorizationHandler");

            if (context.Request.UserRole == "Admin")
            {
                _next.Handle(context);
                return;
            }

            if(entityOwners.TryGetValue(context.Request.EntityId, out int ownderId))
            {
                if(ownderId == context.Request.UserId)
                {
                    _next.Handle(context);
                    return;
                }
            }

            context.Response.IsSuccessful = false;
            context.Response.Message = "User is not authorized.";
        }
    }
}
