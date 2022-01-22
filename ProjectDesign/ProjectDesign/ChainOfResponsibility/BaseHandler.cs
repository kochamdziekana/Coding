using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class BaseHandler : IHandler
    {
        protected IHandler _next; // odwołanie do kolejnego handlera

        protected BaseHandler(IHandler next)
        {
            _next = next;
        }

        public abstract void Handle(RequestContext context);
    }
}
