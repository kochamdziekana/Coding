using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class ResultHandler : BaseHandler
    {
        public ResultHandler(IHandler next) : base(next)
        {

        }

        public override void Handle(RequestContext context)
        {
            Console.WriteLine("ResultHandler");

            context.Response.IsSuccessful = true;
            context.Response.Data = "Some kind of an object.";
        }
    }
}
