using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibility
{
    public class Program // middleware działa na tej zasadzie mniej więcej
    {
        public static void Main(string[] args)
        {
            var requestContext = new RequestContext()
            {
                Request = new Request
                {
                    EntityId = 101,
                    UserId = 13, // dla  14 jest git
                    UserRole = "User"
                },
                Response = new Response()
            };

            var resultHandler = new ResultHandler(null);                            // łańcuch wywołań
            var validationHandler = new ValidationHandler(resultHandler);           // 
            var authorizationHandler = new AuthorizationHandler(validationHandler); // 

            authorizationHandler.Handle(requestContext);

            Console.WriteLine($"IsSuccessful: {requestContext.Response.IsSuccessful}");
            Console.WriteLine($"Message: {requestContext.Response.Message}");
            Console.WriteLine($"Data: {requestContext.Response.Data}");

        }
    }

    
}